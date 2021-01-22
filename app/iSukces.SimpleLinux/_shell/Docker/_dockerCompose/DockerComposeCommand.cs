using System.Collections.Generic;

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
            /*
            yield return "docker-compose";
            if (Version)
            {
                yield return "-v";
                yield break;
            }

            if (!string.IsNullOrEmpty(File))
            {
                yield return "-f";
                yield return File;
            }

            if (!string.IsNullOrEmpty(ProjectName))
            {
                yield return "-p";
                yield return ProjectName;
            }

            if (Verbose)
                yield return "--verbose";
                */

            //  const string dockerCompose = "docker-compose up -d  --remove-orphans --build";
        }

        /*
        /// <summary>
        ///     An alternate compose file (default: docker-compose.yml)
        /// </summary>
        public string File { get; set; }


        /// <summary>
        ///     An alternate project name (default: directory name)
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        ///     Print version and exit
        /// </summary>
        public bool Version { get; set; }

        public bool Verbose { get; set; }
        */

        public IDockerComposeOption Option { get; set; }
        
        public DockerComposeCommonOptions Common { get; set; } 
    }
}