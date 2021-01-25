using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace iSukces.SimpleLinux.Docker
{
    public class DockerfileScriptBuilder : ScriptBuilder
    {
        public void Copy(string code)
        {
            WriteLine("COPY " + code);
        }

        public void Expose(int i)
        {
            WriteLine($"EXPOSE {i.ToString(CultureInfo.InvariantCulture)}");
        }

        public DockerfileScriptBuilder From(string imageName)
        {
            WriteLine("FROM " + imageName);
            return this;
        }

        public DockerfileScriptBuilder Run(string code)
        {
            WriteLine("RUN " + code);
            return this;
        }

        public void Volume(string dirName)
        {
            dirName = $"\"{dirName}\"";
            WriteLine($"VOLUME [{dirName}]");
        }

        public void Volume(IEnumerable<LinuxFileBase> dirs)
        {
            var v = JsonConvert.SerializeObject(dirs.Select(a => a.FullName));
            WriteLine("VOLUME v");
        }
    }
}