using System.IO;

namespace iSukces.SimpleLinux
{
    public class BytesFileContentSource : IFileContentSource
    {
        private BytesFileContentSource(byte[] content)
        {
            _content = content;
        }

        public static BytesFileContentSource FromFile(FileInfo fileFullName)
        {
            return FromFile(fileFullName?.FullName);
        }

        public static BytesFileContentSource FromFile(string fileFullName)
        {
            if (string.IsNullOrEmpty(fileFullName))
                return null;
            if (!File.Exists(fileFullName))
                return null;
            var bytes = File.ReadAllBytes(fileFullName);
            return Make(bytes);
        }

        public static BytesFileContentSource Make(byte[] content)
        {
            if (content is null)
                return null;
            return new BytesFileContentSource(content);
        }

        public byte[] GetBytes()
        {
            return _content;
        }

        public Sha1Code GetSha1()
        {
            return Sha1Code.Compute(_content);
        }

        private readonly byte[] _content;
    }
}