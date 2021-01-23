using System.ComponentModel;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [ImmutableObject(true)]
    public partial class ParametrizedOption
    {
        public ParametrizedOption(string value, string name, ValueEncoder encoder,
            string valueDescription, string propertyName, bool isCollection)
        {
            // --scale SERVICE=NUM
            if (value == "\"*\"")
                value = "optionValue";
            Name             = name?.Trim();
            Value            = value?.Trim();
            Encoder          = encoder;
            ValueDescription = valueDescription;
            PropertyName     = propertyName;
            IsCollection     = isCollection;
        }

        public override string ToString()
        {
            if (IsCollection)
                return Value;
            var toString = Name;
            if (!string.IsNullOrEmpty(Value))
                toString += "=" + Value;
            return toString;
        }

        public ParametrizedOption WithEncoder(ValueEncoder encoder)
        {
            return new ParametrizedOptionBuilder(this)
                .WithEncoder(encoder)
                .Build();
        }

        public ParametrizedOption WithValueDescription(string valueDescription)
        {
            return new ParametrizedOptionBuilder(this)
                .WithValueDescription(valueDescription)
                .Build();
        }

        public string       Name             { get; }
        public string       Value            { get; }
        public ValueEncoder Encoder          { get; }
        public string       ValueDescription { get; }
        public string       PropertyName     { get; }
        public bool         IsCollection     { get; }
    }

    [Auto.BuilderForTypeAttribute(typeof(ParametrizedOption))]
    public sealed partial class ParametrizedOptionBuilder
    {
    }
}