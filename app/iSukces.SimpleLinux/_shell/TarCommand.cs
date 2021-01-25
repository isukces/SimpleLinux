using System;
using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public partial class TarCommand : OnelineLinuxCommand
    {
        public TarCommand(TarOperation operation)
        {
            Operation = operation;
        }

        public override IEnumerable<string> GetItems()
        {
            yield return "tar";
            yield return TarOperationExtension.ToLinuxString(Operation);
            foreach (var i in GetCodeItems())
                yield return i;
            if (string.IsNullOrEmpty(FilelistSourceFile))
            {
                yield return "-T";
                yield return FilelistSourceFile;
            }

            foreach(var i in Files)
                yield return i;
        }

        public TarOperation Operation { get; set; }

        public List<string> Files { get; } = new List<string>();

        /// <summary>
        /// -T, --files-from=FILE
        /// </summary>
        public string FilelistSourceFile { get; set; }
    }

    public static class TarOperationExtension
    {
        public static string ToLinuxString(TarOperation operation)
        {
            switch (operation)
            {
                case TarOperation.AppendArchive: return "-A";
                case TarOperation.Create: return "-c";
                case TarOperation.Diff: return "-d";
                case TarOperation.List: return "-t";
                case TarOperation.AppendFiles: return "-r";
                case TarOperation.Update: return "-u";
                case TarOperation.Extract: return "-x";
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
    }

    public enum TarOperation
    {
        AppendArchive,
        Create,
        Diff,
        List,
        AppendFiles,
        Update,
        Extract
    }
}