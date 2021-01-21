using System.Collections.Generic;
using System.Text;

namespace iSukces.SimpleLinux
{
    public class Multiline
    {
        public Multiline(int maxLength, string continuator, string indent)
        {
            _maxLength   = maxLength;
            _continuator = continuator;
            _indent      = indent;
        }


        public void Add(string text)
        {
            _items.Add(text);
        }

        public void Add(IEnumerable<string> texts)
        {
            _items.AddRange(texts);
        }

        public IEnumerable<string> GetLines(IEnumerable<string> items, string whiteChar = " ")
        {
            var sb       = new StringBuilder();
            var addSpace = false;
            foreach (var i in items)
            {
                var c = sb.Length + 1 + i.Length;

                if (c > _maxLength)
                {
                    yield return sb.ToString();
                    sb.Clear();
                    sb.Append(_indent);
                    addSpace = false;
                }

                if (addSpace)
                    sb.Append(whiteChar);
                sb.Append(i);
                addSpace = true;
            }

            yield return sb.ToString();
        }

        public string Make(IEnumerable<string> items)
        {
            var sb   = new StringBuilder();
            var line = -1;
            foreach (var i in GetLines(items))
            {
                line++;
                if (line > 0)
                {
                    sb.Append(_continuator);
                    sb.Append("\n");
                }

                sb.Append(i);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Make(_items);
        }

        private readonly int _maxLength;
        private readonly string _continuator;
        private readonly string _indent;

        private readonly List<string> _items = new List<string>();
    }
}