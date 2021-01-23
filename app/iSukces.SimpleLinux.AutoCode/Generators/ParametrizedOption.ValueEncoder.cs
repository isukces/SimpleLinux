using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    partial class ParametrizedOption
    {
        public class ValueEncoder
        {
            private ValueEncoder(OptionValueType valueType, Func<OptionValueProcessorInput, string> convert,
                string[] enumValues = null)
            {
                ValueType  = valueType;
                Convert    = convert;
                EnumValues = ShellEnumOptions.Make(enumValues);
            }

            public static ValueEncoder EnumProcessor(string[] enumValues)
            {
                return new ValueEncoder(new OptionValueType(null),
                    q =>
                    {
                        return q.Expression + "." + ShellEnumOptionsGenerator.extensionMethodName + "()";
                        //throw new NotSupportedException();
                    },
                    enumValues);
            }

            private static string ConvertToInt(OptionValueProcessorInput src)
            {
                var culture    = src.Resolver.GetTypeName<CultureInfo>() + "." + nameof(CultureInfo.InvariantCulture);
                var expression = src.Expression;
                switch (src.Kind)
                {
                    case OptionValueProcessorKind.SingleValue:
                        return expression + "." + nameof(expression.ToString) + "(" + culture + ")";
                        break;
                    case OptionValueProcessorKind.Dictionary:
                        return expression + "." + nameof(expression.ToString) + "(" + culture + ")";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(src.Kind), src.Kind, null);
                }
            }

            private static string ConvertToString(OptionValueProcessorInput src)
            {
                return src.Expression;
            }


            private static bool IsCollectionType(Type def)
            {
                return def == typeof(List<>)
                       || def == typeof(IReadOnlyList<>)
                       || def == typeof(IList<>)
                       || def == typeof(IReadOnlyCollection<>)
                       || def == typeof(ICollection<>);
            }

            public string GetCondition(string expression, bool isCollection)
            {
                var type = ValueType.FixedType;
                if (type == typeof(string)) return $"!string.IsNullOrEmpty({expression})";
                if (isCollection)
                {
                    var def = type.GetGenericTypeDefinition();
                    if (IsCollectionType(def))
                        return $"!({expression} is null) && {expression}.Count > 0";
                }

                return $"!({expression} is null)";
            }

            public PropInfo GetPropertyTypeName(OptionValueProcessorKind kind, ITypeNameResolver res,
                NamespaceAndName enumTypeName)
            {
                var    v = ValueType.FixedType;
                string elementName;
                if (v != null)
                {
                    switch (kind)
                    {
                        case OptionValueProcessorKind.List:
                        case OptionValueProcessorKind.Dictionary:
                            elementName = res.GetTypeName(v);
                            break;
                        case OptionValueProcessorKind.SingleValue:
                            if (v.IsValueType)
                                v = typeof(Nullable<>).MakeGenericType(v);
                            elementName = res.GetTypeName(v);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                    }
                }
                else
                {
                    var suffix = kind == OptionValueProcessorKind.SingleValue ? "?" : ";";
                    elementName = res.GetTypeName(enumTypeName) + suffix;
                }

                var tqq = new PropInfo(elementName);

                switch (kind)
                {
                    case OptionValueProcessorKind.Dictionary:
                        return tqq.MakeDict(res);
                    case OptionValueProcessorKind.SingleValue:
                        return tqq;
                    case OptionValueProcessorKind.List:
                        return tqq.MakeList(res);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                }
            }

            public ShellEnumOptions EnumValues { get; }

            public OptionValueType                         ValueType { get; }
            public Func<OptionValueProcessorInput, string> Convert   { get; }


            public static readonly ValueEncoder IntEncoder
                = new ValueEncoder(OptionValueType.Make<int>(), ConvertToInt);

            public static readonly ValueEncoder StringEncoder
                = new ValueEncoder(OptionValueType.Make<string>(), ConvertToString);

            public class PropInfo
            {
                public PropInfo(string propertyType)
                {
                    PropertyType = propertyType;
                    ElementType  = propertyType;
                }

                public PropInfo MakeDict(ITypeNameResolver resolver)
                {
                    var type = resolver.GetTypeName<IDictionary<int, int>>().Split('<').First();
                    var init = resolver.GetTypeName<Dictionary<int, int>>().Split('<').First();
                    PropertyInit = $"new {init}<string, {ElementType}>()";
                    PropertyType = $"{type}<string, {ElementType}>";
                    return this;
                }

                public PropInfo MakeList(ITypeNameResolver resolver)
                {
                    var type = resolver.GetTypeName<IList<int>>().Split('<').First();
                    var init = resolver.GetTypeName<List<int>>().Split('<').First();
                    PropertyInit = $"new {init}<{ElementType}>()";
                    PropertyType = $"{type}<{ElementType}>";
                    return this;
                }

                public string ElementType { get; }

                public string PropertyType { get; set; }

                public string PropertyInit { get; set; }
            }
        }
    }
}