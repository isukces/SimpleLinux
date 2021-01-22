using System.IO;
using System.Text;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class TemplateFilenameMaker : IFilenameMaker
    {
        public TemplateFilenameMaker(string template)
        {
            Template = template;
        }

        private static string Cleanup(string filename)
        {
            var sb         = new StringBuilder();
            var allowslash = true;
            foreach (var c in filename)
                if (c == '/' || c == '\\')
                {
                    if (!allowslash) continue;
                    sb.Append('\\');
                    allowslash = false;
                }
                else
                {
                    sb.Append(c);
                    allowslash = true;
                }

            filename = sb.ToString();
            return filename;
        }

        public FileInfo GetFileName(FilePathBuilderInput input)
        {
            var fileName = string.Format(Template,
                input.ProjectBaseDir.FullName,
                input.RelativeNamespace.Replace(".", "\\"),
                input.ShortFileName);
            fileName = Cleanup(fileName);
            return new FileInfo(fileName);
        }

        public string Template { get; }
    }
}