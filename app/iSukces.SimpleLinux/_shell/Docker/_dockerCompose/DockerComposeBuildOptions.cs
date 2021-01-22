using System.Collections.Generic;

namespace iSukces.SimpleLinux.Docker
{
    public partial class DockerComposeBuildOptions
    {
        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public string Name => "build";
    }
}