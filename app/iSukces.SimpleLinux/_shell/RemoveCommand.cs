using System;
using System.Collections.Generic;
using System.Text;

namespace iSukces.SimpleLinux
{
    public class RemoveCommand : OnelineLinuxCommand
    {
        public override IEnumerable<string> GetItems()
        {
            yield return "rm";
            var flags = GetFlags();
            if (flags != null)
                yield return "-" + flags;
            yield return FileName;
        }

        private string GetFlags()
        {
            var s = new StringBuilder();
            if ((Flags & RemoveCommandFlags.Recursive) != 0) s.Append("r");
            if ((Flags & RemoveCommandFlags.Force) != 0)
                s.Append("f");
            if (s.Length == 0)
                return null;
            return s.ToString();
        }

        public RemoveCommandFlags Flags    { get; set; }
        public string             FileName { get; set; }
    }

    [Flags]
    public enum RemoveCommandFlags
    {
        None,
        Force = 1,
        Directory = 2,
        Recursive = 4
    }
}