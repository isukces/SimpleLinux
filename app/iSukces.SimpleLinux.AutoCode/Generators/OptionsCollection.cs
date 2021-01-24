using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class OptionsCollection
    {
        public static OptionsCollection Parse(string text, ParserKind parserKind)
        {
            switch (parserKind)
            {
                case ParserKind.Default:
                    return ParseDefault(text);
                case ParserKind.Style1:
                    return ParseStyle1(text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parserKind), parserKind, null);
            }
        }

        private static OptionsCollection ParseStyle1(string text)
        {
            var result = new OptionsCollection();
            var lines  = text.SplitToLines();
            if (lines.Length == 0)
                return result;

            OptionsCollectionValue value = null;
            foreach (var line in lines)
            {
                var n           = line.Trim();
                if (!n.StartsWith('-'))
                {
                    if (value is null)
                        throw new Exception("Description without command");
                    value.Description = value.Description.AppendText(n);
                    continue;
                }
                
                value = new OptionsCollectionValue();
                var slashSeparatedParts = n.Split('/');
                foreach (var option in slashSeparatedParts)
                    value.UpdateFromParsedOption(option, ParserKind.Style1);

                result.Values.Add(value);
            }

            {
                var optionToItem = result.GetMap();
                foreach (var option1 in result.Values)
                {
                    var enumerable = IncompatibleOptions.Parse(option1.Description);
                    foreach (var option2 in enumerable)
                    {
                        var q = optionToItem[option2];
                        result.AddConflict(option1.AnyWithMinus, q.AnyWithMinus);
                    }
                }
            }

            return result;
        }

        private static OptionsCollection ParseDefault(string text)
        {
            var result = new OptionsCollection();
            var lines  = text.SplitToLines();
            if (lines.Length == 0)
                return result;
            var splitColumn = lines.GetSplitColumn();

            OptionsCollectionValue value = null;
            foreach (var line in lines)
            {
                var optionNames = line.Substring(0, splitColumn).Trim();
                var description = line.Substring(splitColumn).Trim();
                if (string.IsNullOrEmpty(optionNames))
                {
                    if (value is null)
                        throw new Exception("Description without command");
                    value.Description = value.Description.AppendText(description);
                    continue;
                }

                value = new OptionsCollectionValue
                {
                    Description = description
                };
                var commaSeparatedParts = optionNames.Split(',');
                foreach (var option in commaSeparatedParts)
                    value.UpdateFromParsedOption(option, ParserKind.Default);

                result.Values.Add(value);
            }

            {
                var optionToItem = result.GetMap();
                foreach (var option1 in result.Values)
                {
                    var enumerable = IncompatibleOptions.Parse(option1.Description);
                    foreach (var option2 in enumerable)
                    {
                        var q = optionToItem[option2];
                        result.AddConflict(option1.AnyWithMinus, q.AnyWithMinus);
                    }
                }
            }

            return result;
        }

        public void AddConflict(string option1, string option2)
        {
            IncompatibleValues.Add(new IncompatibleOptions(option1, option2));
        }

        [CanBeNull]
        public OptionsCollectionValue FindByOption(string option)
        {
            return Values.FirstOrDefault(i => i.Match(option));
        }

        [NotNull]
        public OptionsCollectionValue GetByOption(string option)
        {
            var tmp = FindByOption(option);
            if (tmp is null)
                throw new Exception("unable to find definition for " + option);
            return tmp;
        }


        public IReadOnlyDictionary<string, OptionsCollectionValue> GetMap()
        {
            var dictionary = new Dictionary<string, OptionsCollectionValue>();
            foreach (var i in Values)
            {
                var option = i.LongOptionWithMinus;
                if (!string.IsNullOrEmpty(option))
                    dictionary.Add(option, i);
                option = i.ShortOptionWithMinus;
                if (!string.IsNullOrEmpty(option))
                    dictionary.Add(option, i);
            }

            return dictionary;
        }


        /// <summary>
        ///     Values pairs that can't used in common
        /// </summary>
        [NotNull]
        public IList<IncompatibleOptions> IncompatibleValues { get; } = new List<IncompatibleOptions>();

        public List<OptionsCollectionValue> Values { get; } = new List<OptionsCollectionValue>();
    }

    public enum ParserKind
    {
        Default,
        
        /// <summary>
        /// Like https://www.mit.edu/afs.new/sipb/user/ssen/src/curl-7.11.1/docs/curl.html
        /// - switch names is starting line, separated by /
        /// - arguments in triangle brackets
        /// </summary>
        Style1
    }
}