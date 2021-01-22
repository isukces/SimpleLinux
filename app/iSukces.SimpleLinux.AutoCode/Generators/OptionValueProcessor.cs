using System;
using System.Collections.Generic;
using System.Globalization;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionValueProcessor
    {
        public OptionValueProcessor(Type valueType, Func<string, ITypeNameResolver, string> convert)
        {
            ValueType = valueType;
            Convert   = convert;
        }

        private static string ConvertToInt(string expression, ITypeNameResolver resolver)
        {
            var culture = resolver.GetTypeName<CultureInfo>() + "." + nameof(CultureInfo.InvariantCulture);
            return expression + "." + nameof(expression.ToString) + "(" + culture + ")";
        }

        private static string ConvertToString(string expression, ITypeNameResolver resolver)
        {
            return expression;
        }

        public string GetCondition(string expression)
        {
            if (ValueType == typeof(string))
                return $"!string.IsNullOrEmpty({expression})";
            return $"!({expression} is null)";
        }

        public Type GetPropertyType(Kind kind)
        {
            switch (kind)
            {
                case Kind.Dictionary:
                    return typeof(Dictionary<,>).MakeGenericType(typeof(string), ValueType);
                case Kind.SingleValue:
                    if (ValueType.IsValueType)
                        return typeof(Nullable<>).MakeGenericType(ValueType);
                    if (ValueType.IsClass)
                        return ValueType;
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        public Type                                    ValueType { get; }
        public Func<string, ITypeNameResolver, string> Convert   { get; }

        public static readonly OptionValueProcessor IntProcessor
            = new OptionValueProcessor(typeof(int), ConvertToInt);

        public static readonly OptionValueProcessor StringProcessor
            = new OptionValueProcessor(typeof(string), ConvertToString);
    }


    public enum Kind
    {
        SingleValue,
        Dictionary
    }
}