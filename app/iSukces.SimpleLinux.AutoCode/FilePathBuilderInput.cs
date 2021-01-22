using System.IO;

namespace iSukces.SimpleLinux.AutoCode
{
    public class FilePathBuilderInput
    {
        public DirectoryInfo ProjectBaseDir    { get; set; }
        public string RelativeNamespace { get; set; }
        public string ShortFileName     { get; set; }
    }
}