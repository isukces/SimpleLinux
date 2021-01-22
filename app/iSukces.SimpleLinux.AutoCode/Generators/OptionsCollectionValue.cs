using System;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionsCollectionValue
    {
        public string GetEnumValueCode()
        {
            var name = string.IsNullOrEmpty(LongOption) ? ShortOption : LongOption;
            return name.Camelise();
        }

        public override string ToString()
        {
            var toString = ShortOptionWithMinus.Append(LongOptionWithMinus, ", ");
            if (string.IsNullOrEmpty(OptionParameter))
                return toString;
            toString = toString.Append(OptionParameter);
            if (!string.IsNullOrEmpty(OptionParameterValue))
                toString += "=" + OptionParameterValue;
            return toString;
        }

        public void UpdateFromParsedOption(string option)
        {
            var optionParts = option.Trim().Split(' ');
            AnyWithMinus = optionParts[0];
            if (optionParts.Length > 2)
                throw new NotImplementedException("Unable to parse " + option);
            if (optionParts.Length == 2) AppendOptionPart(optionParts[1]);
        }

        private void AppendOptionPart(string optionPart)
        {
            optionPart = optionPart?.Trim();
            if (string.IsNullOrEmpty(optionPart))
                return;
            var parts = optionPart.Split('=');
            OptionParameter = parts[0].Trim();
            if (parts.Length < 2) return;
            OptionParameterValue = parts[1].Trim();
            if (parts.Length > 2) throw new NotSupportedException();
        }

        public string AnyWithMinus
        {
            get
            {
                var lo = LongOptionWithMinus;
                return string.IsNullOrEmpty(lo) ? ShortOptionWithMinus : lo;
            }
            set
            {
                value = value.Trim();
                var trimmed = value.TrimStart('-');
                switch (value.Length - trimmed.Length)
                {
                    case 1:
                        ShortOption = trimmed;
                        break;
                    case 2:
                        LongOption = trimmed;
                        break;
                }
            }
        }

        public string Description { get; set; }
        public string ShortOption { get; set; }
        public string LongOption  { get; set; }

        public string LongOptionWithMinus
        {
            get { return string.IsNullOrEmpty(LongOption) ? null : "--" + LongOption; }
        }

        public string ShortOptionWithMinus
        {
            get { return string.IsNullOrEmpty(ShortOption) ? null : "-" + ShortOption; }
        }

        public string OptionParameter      { get; set; }
        public string OptionParameterValue { get; set; }
    }
}