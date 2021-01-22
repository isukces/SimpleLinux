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

        public Type GetPropertyType(Kind kind)
        {
            switch (kind)
            {
                case Kind.Dictionary:
                    return typeof(Dictionary<,>).MakeGenericType(typeof(string), ValueType);
                case Kind.SingleValue:
                    if (ValueType.IsValueType)
                        return typeof(Nullable<>).MakeGenericType(ValueType);
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        public Type                                    ValueType { get; }
        public Func<string, ITypeNameResolver, string> Convert   { get; }

        public static readonly OptionValueProcessor Integer
            = new OptionValueProcessor(typeof(int), ConvertToInt);
    }

    public class Dictionary<T>
    {
    }

    public enum Kind
    {
        SingleValue,
        Dictionary
    }
}