using System;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal partial class SingleTaskEnumsGenerator
    {
        private class FluentMethodParameters
        {
            public static FluentMethodParameters Get(ParametrizedOption.OptionValueProcessorKind kind,
                ParametrizedOption.PropInfo propInfo)
            {
                switch (kind)
                {
                    case ParametrizedOption.OptionValueProcessorKind.SingleValue:
                        return new FluentMethodParameters
                        {
                            ValueParameterType = propInfo.PropertyType
                        };
                    case ParametrizedOption.OptionValueProcessorKind.Dictionary:
                        return new FluentMethodParameters
                        {
                            ValueParameterType = propInfo.ElementType,
                            AddKey             = true
                        };
                    case ParametrizedOption.OptionValueProcessorKind.List:
                        return new FluentMethodParameters
                        {
                            ValueParameterType = propInfo.ElementType,
                            IsParam            = true
                        };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public string ValueParameterType { get; set; }
            public bool   AddKey             { get; set; }
            public bool   IsParam            { get; set; }

            public string ValueParameterType2
            {
                get
                {
                    if (IsParam)
                        return ValueParameterType + "[]";
                    return ValueParameterType;
                }
            }
        }
    }
}