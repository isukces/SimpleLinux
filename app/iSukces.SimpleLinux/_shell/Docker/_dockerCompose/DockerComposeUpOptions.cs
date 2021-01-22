using System;
using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial struct DockerComposeUpOptions
    {
        public IEnumerable<string> GetItems()
        {
            return Options.OptionsToString();
        }

        public string Name => "up";
    }
}