using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial class DockerComposeCommonOptions
    {
        public IEnumerable<string> GetItems()
        {
            return Options.OptionsToString();
        }
    }
}