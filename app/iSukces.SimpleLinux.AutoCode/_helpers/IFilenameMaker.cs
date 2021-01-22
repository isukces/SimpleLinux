using System.IO;

namespace iSukces.SimpleLinux.AutoCode
{
    public interface IFilenameMaker
    {
        FileInfo GetFileName(FilePathBuilderInput input);
    }
}