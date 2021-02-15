using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace iSukces.SimpleLinux.Docker
{
    public class DockerfileScriptBuilder : ScriptBuilder
    {
        public DockerfileScriptBuilder Copy(string code)
        {
            WriteLine("COPY " + code);
            return this;
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

        public DockerfileScriptBuilder Run(params string[] codes)
        {
            var code = string.Join(" && ", codes);
            return Run(code);
        }

        public DockerfileScriptBuilder Run(OnelineLinuxCommand code)
        {
            WriteLine("RUN " + code.GetCode());
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
            WriteLine("VOLUME "+v);
        }

        public DockerfileScriptBuilder WithApkUpdate()
        {
            const string cmd = "apk";
            Run(cmd + " update", cmd + " upgrade", "apk add bash", "rm -rf /var/cache/apk/*");
            return this;
        }

        public DockerfileScriptBuilder WithAptGetUpdate()
        {
            const string cmd = "apt-get";
            Run(cmd + " update", cmd + " upgrade -y", cmd+" install bash", "rm -rf /var/cache/apt/*");
            return this;
        }

        public DockerfileScriptBuilder WorkDir(string workdir)
        {
            WriteLine("WORKDIR " + workdir);
            return this;
        }
    }
}