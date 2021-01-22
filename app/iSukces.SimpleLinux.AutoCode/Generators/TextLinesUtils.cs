using System.Collections.Generic;
using System.Linq;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal static class TextLinesUtils
    {
        public static string[] SplitToLines(this string text)
        {
            var lines = text.Split('\r', '\n')
                //.Where(a => a.Trim().Length > 0)
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .ToArray();
            return lines;
        }

        public static int GetSplitColumn(this string[] lines)
        {
            var dictionary = new Dictionary<int, int>();
            var spacesAtBegin = lines.Select(a =>
            {
                var b = a.TrimStart();
                return a.Length - b.Length;
            }).Min();
            foreach (var text in lines)
                for (var colIdx = spacesAtBegin+1; colIdx < text.Length; colIdx++)
                {
                    if (text[colIdx] == ' ') continue;
                    if (  text[colIdx - 1] != ' ') continue;
                    dictionary.TryGetValue(colIdx, out var cnt);
                    dictionary[colIdx] = cnt + 1;
                }

            var tmp = dictionary.OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToArray();
            var maximumLinesWithTheSamePossibleSplit = tmp[0].Value;
            var splitColumns = tmp.Where(a => a.Value == maximumLinesWithTheSamePossibleSplit)
                .Select(a=>a.Key)
                .ToArray();
            if (splitColumns.Length == 1)
                return splitColumns[0];
            return splitColumns[1];
        }
    }
}