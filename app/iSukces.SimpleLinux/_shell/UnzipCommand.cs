using System.Collections.Generic;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux
{
    public class UnzipCommand : OnelineLinuxCommand
    {
        public UnzipCommand(string fileName)
        {
            FileName = fileName;
        }

        public override IEnumerable<string> GetItems()
        {
            yield return "unzip";
            foreach (var i in _options.GetCodeItems())
                yield return i;
            if (!string.IsNullOrEmpty(FileName))
                yield return FileName;
        }

        public string FileName { get; }

        [NotNull]
        public UnzipOptions Options
        {
            get => _options;
            set => _options = value ?? new UnzipOptions();
        }

        private UnzipOptions _options = new UnzipOptions();
    }
}