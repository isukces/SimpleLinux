using System.Collections.Generic;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.Docker
{
    public class DockerComposeCommand : OnelineLinuxCommand
    {
        public override IEnumerable<string> GetItems()
        {
            yield return "docker-compose";
            foreach (var i in Common.GetItems())
                yield return i;
            yield return Option.Name;
            foreach (var i in Option.GetItems())
                yield return i;
        }

        public IDockerComposeOption Option { get; set; }

        [NotNull]
        public DockerComposeCommonOptions Common
        {
            get => _common;
            set => _common = value ?? new DockerComposeCommonOptions();
        }

        private DockerComposeCommonOptions _common = new DockerComposeCommonOptions();
    }
}