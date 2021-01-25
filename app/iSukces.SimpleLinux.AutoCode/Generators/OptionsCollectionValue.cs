using System;
using System.Text.RegularExpressions;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionsCollectionValue
    {
        public string GetCsName()
        {
            if (!string.IsNullOrEmpty(ForceCsName))
                return ForceCsName;
            var candidate = Parameter?.PropertyName?.Camelise(true);
            if (!string.IsNullOrEmpty(candidate))
                return candidate;
            var name = string.IsNullOrEmpty(LongOption) ? ShortOption : LongOption;
            name = name.Replace(".", "");
            name = name.Camelise();
            return name;
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

        public void UpdateFromParsedOption(string option, ParserKind parserKind)
        {
            switch (parserKind)
            {
                case ParserKind.Style1:
                {
                    var m = Style1OptionParserRegex.Match(option);
                    if (!m.Success)
                        throw new Exception("Invalid format");
                    var name = m.Groups[1].Value.Trim();
                    if (name.StartsWith("$"))
                    {
                        this.ForceCsName = name.Substring(1).Camelise();
                        return;

                    }
                        else
                    AnyWithMinus = name;
                    var a = m.Groups[2].Value;
                    var b = m.Groups[3].Value;
                    AppendOptionPart(a, b);
                    break;
                }
                case ParserKind.Default:
                {
                    var optionParts = option.Trim().Split(' ');
                    optionParts = TextLinesUtils.SplitBySpace(option, true);
                    var first = optionParts[0];
                    if (first.StartsWith("$"))
                    {
                        ForceCsName = first.Substring(1).Camelise();
                        return;
                    }

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
                        if (optionParts.Length == 2)
                            AppendOptionPart(optionParts[1]);
                    }

                    break;
                }
            }
        }

        private void AppendOptionPart(string optionPart)
        {
            optionPart = optionPart?.Trim();
            if (string.IsNullOrEmpty(optionPart))
                return;
            var parts = optionPart.Split('=');
            if (parts.Length > 2) throw new NotSupportedException();
            AppendOptionPart(parts[0], parts.Length < 2 ? null : parts[1]);
        }

        private void AppendOptionPart(string first, string second)
        {
            first  = first?.Trim();
          
            if (string.IsNullOrEmpty(first))
                return;
            
            second = second?.Trim();
            string forceCsName = null;
            if (first.StartsWith("$"))
            {
                first       = first.Substring(1);
                forceCsName = first.Camelise();
            }
            
            if (second!= null && second.StartsWith("$"))
            {
                second      = second.Substring(1);
                forceCsName = second.Camelise();
            }

            if (string.IsNullOrEmpty(second))
                Parameter = new ParametrizedOption(first);
            else
                Parameter = new ParametrizedOption(second, first);
            if (!string.IsNullOrEmpty(forceCsName))
                ForceCsName = forceCsName;
        }

        public string ForceCsName { get; set; }

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

        public string FullDescription => ToString().AppendText(Description, ": ");

        private static readonly Regex Style1OptionParserRegex =
            new Regex(Style1OptionParserFilter, RegexOptions.Multiline | RegexOptions.Compiled);

        private const string Style1OptionParserFilter = @"([^<]*)(?:\s*<([^>=]*)(?:=([^>=]+))?>)?";
    }
}