using System;
using System.Collections.Generic;
using System.Globalization;
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

            public string GetCondition(string expression)
            {
                if (ValueType.FixedType == typeof(string))
                    return $"!string.IsNullOrEmpty({expression})";
                return $"!({expression} is null)";
            }

            public string GetPropertyTypeName(OptionValueProcessorKind kind, ITypeNameResolver res,
                NamespaceAndName enumTypeName)
            {
                var v = ValueType.FixedType;
                if (v != null)
                    switch (kind)
                    {
                        case OptionValueProcessorKind.Dictionary:
                        {
                            v = typeof(Dictionary<,>).MakeGenericType(typeof(string), v);
                            return res.GetTypeName(v);
                        }
                        case OptionValueProcessorKind.SingleValue:
                            if (v.IsValueType)
                                v = typeof(Nullable<>).MakeGenericType(v);
                            return res.GetTypeName(v);
                        default:
                            throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                    }

                var suffix = kind == OptionValueProcessorKind.SingleValue ? "?" : ";";
                return res.GetTypeName(enumTypeName) + suffix;
            }

            public ShellEnumOptions EnumValues { get; }

            public OptionValueType                         ValueType { get; }
            public Func<OptionValueProcessorInput, string> Convert   { get; }


            public static readonly ValueEncoder IntEncoder
                = new ValueEncoder(OptionValueType.Make<int>(), ConvertToInt);

            public static readonly ValueEncoder StringEncoder
                = new ValueEncoder(OptionValueType.Make<string>(), ConvertToString);
        }
    }
}