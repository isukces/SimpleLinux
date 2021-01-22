using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial class DockerComposeUpOptions
    {
        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public string Name => "up";
    }
}