using System;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public partial class ParametrizedOption
    {
        public class OptionValueType
        {
            public OptionValueType(Type fixedType)
            {
                FixedType = fixedType;
            }

            public static OptionValueType Make<T>()
            {
                return new OptionValueType(typeof(T));
            }

            public string GetTypeName(CsClass str, NamespaceAndName valueEnumTypeName)
            {
                if (FixedType != null)
                    return str.GetTypeName(FixedType);
                return str.GetTypeName(valueEnumTypeName);
            }

            public Type FixedType { get; }
        }
    }
}