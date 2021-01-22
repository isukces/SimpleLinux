using System;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionsCollectionValue
    {
        public string GetCsName()
        {
            var candidate = Parameter?.OtherName?.Camelise();
            if (!string.IsNullOrEmpty(candidate))
                return candidate;
            var name = string.IsNullOrEmpty(LongOption) ? ShortOption : LongOption;
            name= name.Camelise();
            return name ;
        }

        public bool Match(string option)
        {
            return option == LongOptionWithMinus || option == ShortOptionWithMinus;
        }

        public override string ToString()
        {
            var toString = ShortOptionWithMinus.AppendText(LongOptionWithMinus, ", ");
            toString = toString.AppendText(Parameter?.ToString());
            return toString;
        }

        public void UpdateFromParsedOption(string option)
        {
            var optionParts = option.Trim().Split(' ');

            var first = optionParts[0];
            if (first.Contains('='))
            {
                if (optionParts.Length != 1)
                    throw new NotImplementedException();
                var g = first.Split('=');
                AnyWithMinus = g[0];
                AppendOptionPart(g[1]);
            }
            else
            {
                AnyWithMinus = first;
                if (optionParts.Length > 2)
                    throw new NotImplementedException("Unable to parse " + option);
                if (optionParts.Length == 2) AppendOptionPart(optionParts[1]);
            }
        }

        private void AppendOptionPart(string optionPart)
        {
            optionPart = optionPart?.Trim();
            if (string.IsNullOrEmpty(optionPart))
                return;
            var parts = optionPart.Split('=');
            if (parts.Length > 2) throw new NotSupportedException();

            Parameter = parts.Length > 1 
                ? new ParametrizedOption(parts[1].Trim(), parts[0].Trim()) 
                : new ParametrizedOption(parts[0].Trim());
            
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

        public ParametrizedOption Parameter       { get; set; }

        public string FullDescription
        {
            get
            {
                return ToString().AppendText(Description, ": ");
            }
        }

       
    }
}