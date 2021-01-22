using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial struct DockerComposeCommonOptions
    {
        public IEnumerable<string> GetItems()
        {
            return Options.OptionsToString();
        }
    }
}