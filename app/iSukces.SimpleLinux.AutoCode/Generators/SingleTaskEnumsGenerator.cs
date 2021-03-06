﻿using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal partial class SingleTaskEnumsGenerator
    {
        private SingleTaskEnumsGenerator(ISingleTaskEnumsGeneratorContext context, EnumsGeneratorItem item)
        {
            _item    = item;
            _context = context;
            _lazyMyStruct = new Lazy<CsClass>(() =>
            {
                var res = MyNamespace.GetOrCreateClass(OptionsClassName);
                res.IsPartial = true;
                return res;
            });
            _lazyMyNamespace = new Lazy<CsNamespace>(() => _context.GetOrCreateNamespace(_item.Namespace));
            _lazyMyEnum      = new Lazy<CsEnum>(() => new CsEnum(MyEnumTypeName));
            _lazyExtensionsClass = new Lazy<CsClass>(() =>
            {
                var extensionsClass = MyNamespace.GetOrCreateClass(_item.EnumName + "Extensions")
                    .WithStatic();
                extensionsClass.IsPartial = true;
                return extensionsClass;
            });
        }

        public static void CreateCode(ISingleTaskEnumsGeneratorContext context, EnumsGeneratorItem item)
        {
            var stat = new SingleTaskEnumsGenerator(context, item);
            stat.CreateCode();
        }

        private static void AddEnumToOutput(string[] parts, CsNamespace ns, CsEnum en)
        {
            if (!parts.Any())
            {
                ns.AddEnum(en);
                return;
            }

            CsClass cl = null;

            foreach (var ii in parts)
            {
                CsClass newClass;
                if (cl is null)
                    newClass = ns.GetOrCreateClass(ii);
                else
                    newClass = cl.GetOrCreateNested(ii);

                cl = newClass;
            }

            throw new NotSupportedException("Need nested enum which is not supported by isukces.code yet");
        }

        private static string GetEnumCondition(string variableName, CsEnum csEnum, CsEnumItem enumItem)
        {
            var mask = GetMask(csEnum, enumItem);
            return $"({variableName} & {mask}) != 0";
        }


        private static string GetMask(CsEnum csEnum, params CsEnumItem[] enumItem)
        {
            return GetMask(csEnum, enumItem.Select(a => a.EnumName).ToArray());
        }

        private static string GetMask(CsEnum csEnum, params string[] enumItem)
        {
            var q = enumItem.Distinct().Select(enumName => $"{csEnum.Name}.{enumName}");
            return string.Join(" | ", q);
        }

        private static string GetStringValue(string chooseLongNameVariableName,
            OptionsCollectionValue option, ITypeNameResolver resolver)
        {
            var longVersion  = option.LongOptionWithMinus;
            var shortVersion = option.ShortOptionWithMinus;
            if (string.IsNullOrEmpty(longVersion))
                return shortVersion.CsEncode();
            if (string.IsNullOrEmpty(shortVersion))
                return longVersion.CsEncode();
            var conditions = chooseLongNameVariableName + " == " + resolver.GetEnumValueCode(OptionPreference.Long);
            return string.Format("{0} ? {1} : {2}", conditions,
                longVersion.CsEncode(),
                shortVersion.CsEncode());
        }

        private void AddGetCodeItemsMethod()
        {
            if (!apps.Any()) return;
            var target              = MyStruct;
            var optionsToStringCode = new CsCodeWriter();
            for (var index = 0; index < apps.Count; index++)
            {
                if (index > 0)
                    optionsToStringCode.WriteLine();
                var action = apps[index];
                action(optionsToStringCode, target);
            }

            var m = target
                .AddMethod("GetCodeItems", MyNamespace.GetTypeName<IEnumerable<string>>())
                .WithBody(optionsToStringCode);

            m.AddParam<OptionPreference>(preferLongNameVariable, ExtensionsClass).ConstValue =
                ExtensionsClass.GetEnumValueCode(OptionPreference.Short);
        }

        private void CreateCode()
        {
            var hasEnum = CreateEnumAndConversionMethods();
            if (hasEnum)
                Struct_AddOptionsProperty();

            foreach (var i in _item.ImplementedInterfaces)
                MyStruct.ImplementedInterfaces.Add(MyNamespace.GetTypeName(i));

            CreateNamedParameters();
            AddGetCodeItemsMethod();

            foreach (var action in _item.CustomCreators)
                action(MyStruct);
        }

        private bool CreateEnumAndConversionMethods()
        {
            var parts               = _item.OwnerClasses;
            var conflictsCodeMethod = Extensions_CheckConflictsCode(_item);

            var optionsToStringCode = new CsCodeWriter();
            optionsToStringCode.WriteLine("// generator : " + GetType().Name);
            if (!string.IsNullOrEmpty(conflictsCodeMethod))
                optionsToStringCode.WriteLine($"{conflictsCodeMethod}({valueVariable});");
            var fb = new EnumFlagsBuilder(MyEnum);
            fb.AddFlagsAttribute(MyNamespace);

            var enumSource = from q in _item.Options.Values
                where string.IsNullOrEmpty(q.Parameter?.Value)
                select q;
            var generate = false;
            foreach (var option in enumSource)
            {
                generate = true;
                var enumItem = new CsEnumItem(option.GetCsName())
                {
                    Description = option.FullDescription,
                };
                var stringValue = GetStringValue(preferLongNameVariable, option, ExtensionsClass);
                optionsToStringCode.WriteDescriptionComment(option);
                var condition = GetEnumCondition(valueVariable, MyEnum, enumItem);
                optionsToStringCode.SingleLineIf(condition, $"yield return {stringValue};");
                MyStruct_AddWithMethod(enumItem, fb.Value == 1);

                fb.Append(enumItem);

                {
                    apps.Add((w, r) =>
                    {
                        var stringValue = GetStringValue(preferLongNameVariable, option, ExtensionsClass);
                        w.WriteDescriptionComment(option);
                        var condition = GetEnumCondition(flagsPropertyName, MyEnum, enumItem);
                        w.SingleLineIf(condition, $"yield return {stringValue};");
                    });
                }
            }

            if (!generate)
                return false;
            {
                var m = ExtensionsClass
                    .AddMethod("OptionsToString", MyNamespace.GetTypeName<IEnumerable<string>>())
                    .WithStatic()
                    .WithBody(optionsToStringCode);
                m.AddParam(valueVariable, MyEnumTypeName).UseThis = true;
                m.AddParam<OptionPreference>(preferLongNameVariable, ExtensionsClass).ConstValue =
                    ExtensionsClass.GetEnumValueCode(OptionPreference.Short);
            }

            AddEnumToOutput(parts, MyNamespace, MyEnum);
            return true;
        }

        private void CreateNamedParameters()
        {
            foreach (var option in _item.Options.Values)
            {
                var p = option.Parameter;
                if (string.IsNullOrEmpty(p?.Value) || p.Encoder is null)
                    continue;

                var str = MyStruct;

                var kind = string.IsNullOrEmpty(p.Name)
                    ? ParametrizedOption.OptionValueProcessorKind.SingleValue
                    : ParametrizedOption.OptionValueProcessorKind.Dictionary;
                if (p.IsCollection)
                    kind = ParametrizedOption.OptionValueProcessorKind.List;

                var cre = new ShellEnumOptionsGenerator(_item.EnumName + option.GetCsName() + "Values", MyNamespace,
                    p.Encoder?.EnumValues);
                cre.MakeEnumIfNecessary();
                cre.MakeExtensionMethod(ExtensionsClass);

                var propInfo = p.Encoder.GetPropertyTypeName(kind, str, cre.TypeName);

                var prop = str.AddProperty(option.GetCsName(),
                        propInfo.PropertyType)
                    .WithNoEmitField()
                    .WithMakeAutoImplementIfPossible();
                prop.ConstValue  = propInfo.PropertyInit;
                prop.Description = option.FullDescription;
                {
                    var key           = p.Name?.ToLower();
                    var value         = p.Value.Camelise(true).FirstLower();
                    var setExpression = prop.Name;

                    var methodName = "With" + prop.Name;
                    var cs         = CsCodeWriter.Create<SingleTaskEnumsGenerator>();
                    {
                        switch (kind)
                        {
                            case ParametrizedOption.OptionValueProcessorKind.SingleValue:
                                cs.WriteLine($"{setExpression} = {value};");
                                break;
                            case ParametrizedOption.OptionValueProcessorKind.Dictionary:
                                cs.WriteLine($"{setExpression}[{key}] = {value};");
                                break;
                            case ParametrizedOption.OptionValueProcessorKind.List:
                                cs.WriteLine($"if ({value.CodeHasElements("Length")})");
                                cs.IncIndent();
                                cs.SingleLineForeach("tmp", value, $"{setExpression}.Add(tmp);");
                                cs.DecIndent();
                                methodName = "WithAppend" + prop.Name;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    cs.WriteLine("return this;");
                    var fluentMethod = str.AddMethod(methodName, str.Name)
                        .WithBody(cs);

                    var fmParams = FluentMethodParameters.Get(kind, propInfo);
                    if (fmParams.AddKey)
                        fluentMethod.AddParam<string>(key, str);
                    var par = fluentMethod.AddParam(value, fmParams.ValueParameterType2);
                    par.Description          = p.ValueDescription;
                    fluentMethod.Description = prop.Description;
                }

                switch (kind)
                {
                    case ParametrizedOption.OptionValueProcessorKind.List:
                    {
                        if (cre.HasEnum)
                            throw new NotSupportedException();
                        apps.Add((cc, re) =>
                        {
                            cc.WriteDescriptionComment(option);
                            var condition = prop.Name.CodeHasElements();
                            cc.Open($"if ({condition})");
                            {
                                var tmp = prop.Name.FirstLower() + "Item";
                                cc.WriteLine($"yield return {option.AnyWithMinus.CsEncode()};");
                                var input      = new ParametrizedOption.OptionValueProcessorInput(tmp, kind, re);
                                var expression = p.Encoder.Convert(input);
                                cc.SingleLineForeach(tmp, prop.Name, $"yield return {expression};");
                            }
                            cc.Close();
                        });
                    }
                        break;
                    case ParametrizedOption.OptionValueProcessorKind.Dictionary:
                    {
                        if (cre.HasEnum)
                            throw new NotSupportedException();
                        apps.Add((cc, re) =>
                        {
                            cc.WriteDescriptionComment(option);
                            cc.Open("foreach(var pair in " + prop.Name + ")");
                            cc.WriteLine("yield return " + option.AnyWithMinus.CsEncode() + ';');
                            var input      = new ParametrizedOption.OptionValueProcessorInput("pair.Value", kind, re);
                            var expression = p.Encoder.Convert(input);
                            if (p.IsCollection)
                                throw new NotSupportedException();
                            cc.WriteLine($"var value = {expression};");
                            cc.WriteLine("yield return $\"{pair.Key}={value}\";");
                            cc.Close();
                        });
                    }
                        break;
                    case ParametrizedOption.OptionValueProcessorKind.SingleValue:
                    {
                        apps.Add((cc, resolver) =>
                        {
                            cc.WriteDescriptionComment(option);
                            var condition = p.Encoder.GetCondition(prop.Name, kind);
                            cc.Open($"if ({condition})");
                            {
                                cc.WriteLine("yield return " + option.AnyWithMinus.CsEncode() + ';');
                                var ex = prop.Name;
                                if (prop.Type.EndsWith("?"))
                                    ex += ".Value";
                                var input      = new ParametrizedOption.OptionValueProcessorInput(ex, kind, resolver);
                                var expression = p.Encoder.Convert(input);
                                if (p.IsCollection)
                                    cc.SingleLineForeach("tmp", expression, "yield return tmp;");
                                else
                                    cc.WriteLine($"yield return {expression};");
                            }
                            cc.Close();
                        });
                    }
                        break;
                }
            }
        }

        private string Extensions_CheckConflictsCode(EnumsGeneratorItem item)
        {
            var conflicts = item.Options.IncompatibleValues.Where(a => a != null).ToArray();
            if (conflicts.Length == 0)
                return null;
            var code = new CsCodeWriter();
            // check conflicts
            var optionToItem = item.Options.GetMap();

            var filter = new CodeVariable("flagsFilter");

            var duplicates = new HashSet<string>();
            foreach (var conflict in conflicts)
            {
                var first        = optionToItem[conflict.Value1];
                var second       = optionToItem[conflict.Value2];
                var argItemNames = new[] {first.GetCsName(), second.GetCsName()};
                if (argItemNames[0] == argItemNames[1])
                    throw new Exception("Both options means the same");

                if (!duplicates.Add(argItemNames[0] + "," + argItemNames[1]))
                    continue;

                filter.Expression = GetMask(MyEnum, argItemNames);
                var errorMessage = string.Format("options {0} can't be used together",
                        string.Join(" and ", first.AnyWithMinus, second.AnyWithMinus))
                    .CsEncode();

                code.WriteLine(filter.GetCodeAndMarkAsDeclared());
                code.SingleLineIf($"({valueVariable} & {filter.Name}) == {filter.Name}",
                    "throw new Exception(" + errorMessage + ");");
            }

            var m = ExtensionsClass
                .AddMethod("CheckConflicts", "void")
                .WithStatic()
                .WithBody(code);
            m.AddParam(valueVariable, MyEnum.Name).UseThis = true;
            return m.Name;
        }

        private void MyStruct_AddWithMethod(CsEnumItem enumItem, bool isFirst)
        {
            if (isFirst)
            {
                var          cw            = new CsCodeWriter();
                const string maskVariable  = "value";
                const string modifiedValue = "current";
                cw.SingleLineIf("add", $"return {modifiedValue} | {maskVariable};",
                    $"return {modifiedValue} & ~{maskVariable};");
                var m = ExtensionsClass
                    .AddMethod(SetOrClearMethod, MyEnumTypeName)
                    .WithBody(cw)
                    .WithStatic();
                m.AddAggressiveInlining(ExtensionsClass);
                m.AddParam(modifiedValue, MyEnumTypeName).UseThis = true;
                m.AddParam(maskVariable, MyEnumTypeName);
                m.AddParam("add", "bool");
            }

            {
                var mask = GetMask(MyEnum, enumItem.EnumName);
                var cw   = CsCodeWriter.Create<SingleTaskEnumsGenerator>();
                cw.WriteLine($"{flagsPropertyName} = {flagsPropertyName}.{SetOrClearMethod}({mask}, value);");
                cw.WriteLine("return this;");
                var m = MyStruct.AddMethod("With" + enumItem.EnumName, OptionsClassName)
                    .WithBody(cw);
                m.AddParam("value", "bool").ConstValue = "true";
                m.Description                          = enumItem.Description;
            }
        }

        private void Struct_AddOptionsProperty()
        {
            MyStruct.AddProperty(flagsPropertyName, MyEnumTypeName)
                .WithNoEmitField()
                .WithMakeAutoImplementIfPossible();
        }

        private string OptionsClassName => _item.Names.OptionsContainerClassName;
        private string MyEnumTypeName   => _item.EnumName + "Flags";

        private CsClass MyStruct => _lazyMyStruct.Value;

        private CsNamespace MyNamespace => _lazyMyNamespace.Value;

        private CsEnum MyEnum => _lazyMyEnum.Value;

        private CsClass ExtensionsClass => _lazyExtensionsClass.Value;

        private readonly List<Action<CsCodeWriter, ITypeNameResolver>> apps =
            new List<Action<CsCodeWriter, ITypeNameResolver>>();

        private readonly ISingleTaskEnumsGeneratorContext _context;
        private readonly EnumsGeneratorItem _item;
        private readonly Lazy<CsClass> _lazyMyStruct;
        private readonly Lazy<CsNamespace> _lazyMyNamespace;
        private readonly Lazy<CsClass> _lazyExtensionsClass;
        private readonly Lazy<CsEnum> _lazyMyEnum;
        private const string flagsPropertyName = "Flags";
        private const string preferLongNameVariable = "preferLongNames";
        private const string SetOrClearMethod = "SetOrClear";
        private const string valueVariable = "value";
    }
}