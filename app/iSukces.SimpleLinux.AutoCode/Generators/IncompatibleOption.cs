using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public sealed class IncompatibleOptions : IEquatable<IncompatibleOptions>
    {
        public IncompatibleOptions([NotNull] string value1, [NotNull] string value2)
        {
            if (value1 == null)
                throw new ArgumentNullException(nameof(value1));

            if (value2 == null)
                throw new ArgumentNullException(nameof(value2));

            var compare = StringComparer.Ordinal.Compare(value1, value2);
            if (compare == 0)
                throw new ArgumentException("Both options have the same value");
            if (compare > 0)
                AutocodeExtensions.Swap(ref value1, ref value2);
            Value1 = value1;
            Value2 = value2;
        }

        public static bool operator ==(IncompatibleOptions left, IncompatibleOptions right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IncompatibleOptions left, IncompatibleOptions right)
        {
            return !Equals(left, right);
        }

        public static IEnumerable<string> Parse(string x)
        {
            if (string.IsNullOrEmpty(x))
                yield break;
            var m = IncompatibleParserRegex.Match(x);
            while (m.Success)
            {
                yield return m.Groups[1].Value;
                var t = m.Groups[2].Value;
                if (!string.IsNullOrEmpty(t))
                    yield return t;

                m = m.NextMatch();
            }
        }

        public bool Equals(IncompatibleOptions other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value1 == other.Value1 && Value2 == other.Value2;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is IncompatibleOptions other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value1, Value2);
        }

        public override string ToString()
        {
            return Value1 + " and " + Value2;
        }

        public string Value1 { get; }
        public string Value2 { get; }

        private static readonly Regex IncompatibleParserRegex =
            new Regex(IncompatibleParserFilter, RegexOptions.Multiline | RegexOptions.Compiled);

        const string IncompatibleParserFilter = @"Incompatible\s+with\s*(-+[^\s\.]+)(?:\s+and\s*(-+[^\s\.]+))?";
    }
}