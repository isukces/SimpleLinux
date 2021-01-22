using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public interface ICommandsPartsProvider
    {
        IEnumerable<string> GetItems();
    }
}