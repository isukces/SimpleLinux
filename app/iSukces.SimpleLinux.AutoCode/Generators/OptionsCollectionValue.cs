using System;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionsCollectionValue
    {
        public string GetCsName()
        {
            var name = string.IsNullOrEmpty(LongOption) ? ShortOption : LongOption;
            return name.Camelise();
        }

        public bool Match(string option)
        {
            return option == LongOptionWithMinus || option == ShortOptionWithMinus;
        }

        public override string ToString()
        {
            var toString = ShortOptionWithMinus.Append(LongOptionWithMinus, ", ");
            toString = toString.Append(Parameter?.ToString());
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
            if (parts.Length > 2) throw new NotSupportedException();
            Parameter = new ParametrizedOption(
                parts[0].Trim(),
                parts.Length > 1 ? parts[1].Trim() : null,
                null);
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

        public string LongOptionWithMinus => string.IsNullOrEmpty(LongOption) ? null : "--" + LongOption;

        public string ShortOptionWithMinus => string.IsNullOrEmpty(ShortOption) ? null : "-" + ShortOption;

        public ParametrizedOption Parameter { get; set; }
    }
}