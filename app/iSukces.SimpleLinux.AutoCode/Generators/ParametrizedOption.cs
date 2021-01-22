using System.ComponentModel;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [ImmutableObject(true)]
    public class ParametrizedOption
    {
        public ParametrizedOption(string value, string name=null, OptionValueProcessor encoder = null)
        {
            // --scale SERVICE=NUM
            Name    = name?.Trim();
            Value   = value?.Trim();
            Encoder = encoder;
        }

        public override string ToString()
        {
            var toString = Name;
            if (!string.IsNullOrEmpty(Value))
                toString += "=" + Value;
            return toString;
        }

        public ParametrizedOption WithEncoder(OptionValueProcessor encoder)
        {
            return new ParametrizedOption(Value, Name, encoder);
        }


        public string               Name    { get; }
        public string               Value   { get; }
        public OptionValueProcessor Encoder { get; }
    }
}