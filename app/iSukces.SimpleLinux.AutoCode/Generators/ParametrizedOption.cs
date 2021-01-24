using System.ComponentModel;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [ImmutableObject(false)]
    [StringProperty("Name")]
    [StringProperty("Value")]
    [StringProperty("ValueDescription")]
    [StringProperty("PropertyName")]
    public partial class ParametrizedOption
    {

        public ParametrizedOption(string value, string name=null)
        {
            // --scale SERVICE=NUM
            if (value == "\"*\"")
                value = "optionValue";
            Name             = name?.Trim();
            Value            = value?.Trim();
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
            Encoder = encoder;
            return this;
        }

        public ParametrizedOption WithValueDescription(string valueDescription)
        {
            ValueDescription = valueDescription;
            return this;
        }
 
        public ValueEncoder Encoder          { get; set; }
 
        public bool         IsCollection     { get; set; }
    }
}