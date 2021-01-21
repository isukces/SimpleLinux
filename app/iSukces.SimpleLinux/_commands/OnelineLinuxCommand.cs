using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public abstract class OnelineLinuxCommand : LinuxCommand
    {
        public override string GetCode()
        {
            var l = new List<string>();
            if (Sudo)
                l.Add("sudo");
            l.AddRange(GetItems());
            return string.Join(" ", l);
        }

        protected abstract IEnumerable<string> GetItems();
    }
}