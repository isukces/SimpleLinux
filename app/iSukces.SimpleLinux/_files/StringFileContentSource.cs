using System.Text;

namespace iSukces.SimpleLinux
{
    public class StringFileContentSource : IFileContentSource
    {
        public StringFileContentSource(string content, Encoding encoding = null)
        {
            _content  = content ?? string.Empty;
            _encoding = encoding ?? Encoding.UTF8;
        }

        public byte[] GetBytes()
        {
            return _encoding.GetBytes(_content);
        }

        public Sha1Code GetSha1()
        {
            return Sha1Code.Compute(_content, _encoding);
        }

        private readonly string _content;
        private readonly Encoding _encoding;
    }
}