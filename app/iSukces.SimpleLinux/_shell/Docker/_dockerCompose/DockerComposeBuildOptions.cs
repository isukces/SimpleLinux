using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial struct DockerComposeBuildOptions
    {
        public IEnumerable<string> GetItems()
        {
            return Options.OptionsToString();
        }

        public string Name => "build";
    }
}