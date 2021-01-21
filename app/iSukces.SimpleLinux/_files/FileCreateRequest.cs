using System;
using System.Globalization;
using System.Text;

namespace iSukces.SimpleLinux
{
    public class FileCreateRequest : IFileCreateRequest
    {
        public FileCreateRequest(LinuxFile file, byte[] content)
            : this(file, BytesFileContentSource.Make(content))
        {
        }

        public FileCreateRequest(LinuxFile file, ScriptBuilder content, Encoding encoding = null)
            : this(file, new ScriptFileContentSource(content, encoding))
        {
        }

        public FileCreateRequest(LinuxFile file, IFileContentSource content)
        {
            File    = file;
            Content = content;
        }

        public FileCreateRequest(LinuxFile file, string content, Encoding encoding = null)
        {
            File    = file;
            Content = new StringFileContentSource(content, encoding);
        }

        public Sha1Code GetSha1()
        {
            var c1 = File.FullName.CreateSha1();
            var c2 = Content?.GetSha1();
            var c3 = LastWriteTime?.Ticks.ToString(CultureInfo.InvariantCulture) ?? "";
            return (c1.Base64 + c2?.Base64 + c3).CreateSha1();
        }

        public LinuxFile          File          { get; }
        public IFileContentSource Content       { get; }
        public DateTimeOffset?    LastWriteTime { get; set; }
    }
}