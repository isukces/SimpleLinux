using System.IO;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class DefaultFilenameMaker : IFilenameMaker
    {
        private DefaultFilenameMaker()
        {
        }


        public static DefaultFilenameMaker Instance
        {
            get { return InstanceHolder.SingleInstance; }
        }

        private sealed class InstanceHolder
        {
            public static readonly DefaultFilenameMaker SingleInstance = new DefaultFilenameMaker();
        }

        public FileInfo GetFileName(FilePathBuilderInput input)
        {
            var p = input.ShortFileName;
            if (!string.IsNullOrEmpty(input.RelativeNamespace))
                p = Path.Combine(input.RelativeNamespace.Replace('.', '\\'), p);
            p = Path.Combine(input.ProjectBaseDir.FullName, p);
            return new FileInfo(p);
        }
    }
}