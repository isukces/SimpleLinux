using System.Text;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux
{
    public class ScriptFileContentSource : IFileContentSource
    {
        public ScriptFileContentSource(ScriptBuilder content, Encoding encoding = null)
        {
            _content  = content;
            _encoding = encoding ?? Encoding.UTF8;
        }

        public byte[] GetBytes()
        {
            return _encoding.GetBytes(CodeNotNull);
        }

        public Sha1Code GetSha1()
        {
            return Sha1Code.Compute(CodeNotNull, _encoding);
        }

        public override string ToString()
        {
            return CodeNotNull;
        }

        [NotNull]
        private string CodeNotNull
        {
            get { return _content?.GetContentForSeparateScriptFile() ?? string.Empty; }
        }

        private readonly ScriptBuilder _content;
        private readonly Encoding _encoding;
    }
}