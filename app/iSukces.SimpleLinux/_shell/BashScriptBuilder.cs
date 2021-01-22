using System;

namespace iSukces.SimpleLinux
{
    public class BashScriptBuilder : ScriptBuilder
    {
        public static Multiline GetMultiline(int maxLength = 80, string indent = "  ")
        {
            return new Multiline(maxLength, " \\", indent);
        }

        public void Apppend(BashScriptBuilder other)
        {
            var code = other?.CodeBuilder.ToString();
            if (string.IsNullOrEmpty(code))
                return;
            WriteLine(code);
        }

        public void ChMod(string flags, string target)
        {
            WriteLine("chmod " + flags + " " + target);
        }

        public void Chown(string owner, string target)
        {
            WriteLine("chown " + owner + " " + target);
        }

        public void CloseIf()
        {
            Close("fi;");
        }

        public void CreateDirectory(string name, Action<string> otherCode1 = null, Action<string> otherCode2 = null,
            bool sudo = false)
        {
            if (otherCode1 is null && otherCode2 is null)
            {
                var q = string.Format("[ -d {0} ] || {1}mkdir {0}", name, sudo ? "sudo " : "");
                WriteLine(q);
                return;
            }

            // [ -d ~/IOTstack/backups/influxdb/db_old ] || sudo mkdir ~/IOTstack/backups/influxdb/db_old
            OpenIf($"! -d {name}");
            otherCode1?.Invoke(name);
            WriteLine($"mkdir -p {name};");
            otherCode2?.Invoke(name);
            CloseIf();
        }

        public void Echo(LinuxCommand text)
        {
            Echo(text.GetCode());
        }

        public void Echo(string text)
        {
            WriteLine("echo " + text);
        }

        public override string GetContentForSeparateScriptFile()
        {
            const string starting = "#/bin/bash\n";
            return starting + Code;
        }

        public void OpenIf(string condition)
        {
            Open($"if [ {condition.Trim()} ]; then");
        }

        public void StartFile()
        {
            WriteLine("#!/bin/bash");
            WriteLine("");
        }

        public void SudoChMod(string flags, string target)
        {
            WriteLine("sudo chmod " + flags + " " + target);
        }

        public void SudoChown(string owner, string target)
        {
            WriteLine("sudo chown " + owner + " " + target);
        }

        public override string ToString()
        {
            return Code;
        }

        public void WriteComment(string comment)
        {
            WriteLine("# " + comment);
        }


        public void WriteLine(OnelineLinuxCommand x)
        {
            WriteLine(x.GetCode());
        }
    }
}