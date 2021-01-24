using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public abstract class OnelineLinuxCommand : LinuxCommand, ICommandsPartsProvider
    {
        public override string GetCode()
        {
            var l = new List<string>();
            if (Sudo)
                l.Add("sudo");
            l.AddRange(GetItems());
            {
                var o = Output;
                if (!o.IsEmpty) 
                    l.Add(o.WithOperator(">", ">>"));
            }
            
                
            return string.Join(" ", l);
        }

        public abstract IEnumerable<string> GetItems();
    }
}