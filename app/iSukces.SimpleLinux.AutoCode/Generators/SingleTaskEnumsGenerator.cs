using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal interface ISingleTaskEnumsGeneratorContext
    {
        CsNamespace GetOrCreateNamespace(string itemNamespace);
    }

    internal class SingleTaskEnumsGenerator
    {
        private SingleTaskEnumsGenerator(ISingleTaskEnumsGeneratorContext context, EnumsGeneratorItem item)
        {
            _item    = item;
            _context = context;
            _lazyMyStruct = new Lazy<CsClass>(() =>
            {
                var res = MyNamespace.GetOrCreateClass(MyStructName);
                res.IsPartial = true;
                res.Kind      = CsNamespaceMemberKind.Struct;
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
                var argItemNames = new[] {first.GetEnumValueCode(), second.GetEnumValueCode()};
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
                var cw   = new CsCodeWriter();
                cw.WriteLine($"Options = Options.{SetOrClearMethod}({mask}, value);");
                //cw.SingleLineIf("value", $"Options |= {mask};", $"Options &= ~{mask};");
                cw.WriteLine("return this;");

                var m = MyStruct.AddMethod("With" + enumItem.EnumName, MyStructName).WithBody(cw);
                m.AddParam("value", "bool").ConstValue = "true";
            }
        }

        private void CreateCode()
        {
            var parts = _item.OwnerClasses;

            MyStruct.IsPartial = true;
            MyStruct.Kind      = CsNamespaceMemberKind.Struct;
            Struct_AddOptionsProperty();
            var conflictsCodeMethod = Extensions_CheckConflictsCode(_item);

            const string preferLongNameVariable = "preferLongNames";

            var code = new CsCodeWriter();
            code.WriteLine("// generator : " + GetType().Name);
            if (!string.IsNullOrEmpty(conflictsCodeMethod))
                code.WriteLine($"{conflictsCodeMethod}({valueVariable});");
            var flagValue = 1;

            foreach (var option in _item.Options.Values.Where(q => string.IsNullOrEmpty(q.OptionParameter)))
            {
                var enumItem = new CsEnumItem(option.GetEnumValueCode())
                {
                    Description  = option.Description,
                    EncodedValue = flagValue.ToInv()
                };
                var stringValue = GetStringValue(preferLongNameVariable, option, ExtensionsClass);
                if (!string.IsNullOrEmpty(option.Description))
                    code.WriteLine("// " + option.Description);
                var condition = GetEnumCondition(valueVariable, MyEnum, enumItem);
                code.SingleLineIf(condition, $"yield return {stringValue};");

                MyEnum.Items.Add(enumItem);

                MyStruct_AddWithMethod(enumItem, flagValue == 1);
                flagValue *= 2;
            }

            {
                var m = ExtensionsClass
                    .AddMethod("OptionsToString", MyNamespace.GetTypeName<IEnumerable<string>>())
                    .WithStatic()
                    .WithBody(code);
                m.AddParam(valueVariable, MyEnumTypeName).UseThis = true;
                m.AddParam<OptionPreference>(preferLongNameVariable, ExtensionsClass).ConstValue =
                    ExtensionsClass.GetEnumValueCode(OptionPreference.Short);
            }

            MyEnum.WithAttribute(new CsAttribute(MyNamespace.GetTypeName<FlagsAttribute>()));
            AddEnumToOutput(parts, MyNamespace, MyEnum);
        }

        private void Struct_AddOptionsProperty()
        {
            MyStruct.AddProperty("Options", MyEnumTypeName)
                .WithNoEmitField()
                .WithMakeAutoImplementIfPossible();
            foreach (var i in _item.ImplementedInterfaces)
                MyStruct.ImplementedInterfaces.Add(MyNamespace.GetTypeName(i));
        }

        private string MyStructName   => _item.EnumName + "Options";
        private string MyEnumTypeName => _item.EnumName + "Flags";

        private CsClass MyStruct => _lazyMyStruct.Value;

        private CsNamespace MyNamespace => _lazyMyNamespace.Value;

        private CsEnum MyEnum => _lazyMyEnum.Value;

        private CsClass ExtensionsClass => _lazyExtensionsClass.Value;

        private readonly ISingleTaskEnumsGeneratorContext _context;
        private readonly EnumsGeneratorItem _item;
        private readonly Lazy<CsClass> _lazyMyStruct;
        private readonly Lazy<CsNamespace> _lazyMyNamespace;
        private readonly Lazy<CsClass> _lazyExtensionsClass;
        private readonly Lazy<CsEnum> _lazyMyEnum;
        private const string SetOrClearMethod = "SetOrClear";
        private const string valueVariable = "value";
    }
}