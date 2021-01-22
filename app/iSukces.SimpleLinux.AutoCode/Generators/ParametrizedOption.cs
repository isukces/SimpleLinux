using System.ComponentModel;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [ImmutableObject(true)]
    public partial class ParametrizedOption
    {
        public ParametrizedOption(string value, string name = null, ValueEncoder encoder = null,
            string valueDescription = null, string otherName=null)
        {
            // --scale SERVICE=NUM
            if (value == "\"*\"")
                value = "optionValue";
            Name             = name?.Trim();
            Value            = value?.Trim();
            Encoder          = encoder;
            ValueDescription = valueDescription;
            OtherName        = otherName;
        }

        public override string ToString()
        {
            var toString = Name;
            if (!string.IsNullOrEmpty(Value))
                toString += "=" + Value;
            return toString;
        }

        public ParametrizedOption WithEncoder(ValueEncoder encoder)
        {
            return new ParametrizedOption(Value, Name, encoder, ValueDescription, OtherName);
        }

        public ParametrizedOption WithValueDescription(string valueDescription)
        {
            return new ParametrizedOption(Value, Name, Encoder, valueDescription, OtherName);
        }

        public ParametrizedOption WithOtherName(string otherName)
        {
            return new ParametrizedOption(Value, Name, Encoder, ValueDescription, otherName);
        }
        public string       Name             { get; }
        public string       Value            { get; }
        public ValueEncoder Encoder          { get; }
        public string       ValueDescription { get; }
        public string       OtherName        { get; }
    }
}