using System.ComponentModel;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [ImmutableObject(true)]
    public partial class ParametrizedOption
    {
        public ParametrizedOption(string otherName, string value, string name = null, ValueEncoder encoder = null,
            string valueDescription = null)
        {
            // --scale SERVICE=NUM
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
            return new ParametrizedOption(OtherName, Value, Name, encoder, ValueDescription);
        }

        public ParametrizedOption WithValueDescription(string valueDescription)
        {
            return new ParametrizedOption(OtherName, Value, Name, Encoder, valueDescription);
        }

        public ParametrizedOption WithOtherName(string otherName)
        {
            return new ParametrizedOption(otherName, Value, Name, Encoder, ValueDescription);
        }
        public string       Name             { get; }
        public string       Value            { get; }
        public ValueEncoder Encoder          { get; }
        public string       ValueDescription { get; }
        public string       OtherName        { get; }
    }
}