// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.Docker
{
    public static partial class DockerComposeCommonExtensions
    {
        public static IEnumerable<string> OptionsToString(this DockerComposeCommonFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            // --verbose: Show more output
            if ((value & DockerComposeCommonFlags.Verbose) != 0)
                yield return "--verbose";
            // --no-ansi: Do not print ANSI control characters
            if ((value & DockerComposeCommonFlags.NoAnsi) != 0)
                yield return "--no-ansi";
            // -v, --version: Print version and exit
            if ((value & DockerComposeCommonFlags.Version) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--version" : "-v";
            // --tls: Use TLS; implied by --tlsverify
            if ((value & DockerComposeCommonFlags.Tls) != 0)
                yield return "--tls";
            // --tlsverify: Use TLS and verify the remote
            if ((value & DockerComposeCommonFlags.Tlsverify) != 0)
                yield return "--tlsverify";
            // --skip-hostname-check: Don't check the daemon's hostname against the name specified in the client certificate
            if ((value & DockerComposeCommonFlags.SkipHostnameCheck) != 0)
                yield return "--skip-hostname-check";
            // --compatibility: If set, Compose will attempt to convert deploy keys in v3 files to their non-Swarm equivalent
            if ((value & DockerComposeCommonFlags.Compatibility) != 0)
                yield return "--compatibility";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DockerComposeCommonFlags SetOrClear(this DockerComposeCommonFlags current, DockerComposeCommonFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

        public static string ToLinuxValue(this DockerComposeCommonLogLevelValues value)
        {
            // generator : ShellEnumOptionsGenerator.MakeExtensionMethod:35
            switch (value)
            {
                case DockerComposeCommonLogLevelValues.Debug: return "DEBUG";
                case DockerComposeCommonLogLevelValues.Info: return "INFO";
                case DockerComposeCommonLogLevelValues.Warning: return "WARNING";
                case DockerComposeCommonLogLevelValues.Error: return "ERROR";
                case DockerComposeCommonLogLevelValues.Critical: return "CRITICAL";
                default: throw new NotSupportedException();
            }
        }

    }

    public partial class DockerComposeCommonOptions : ICommandsPartsProvider
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // --verbose: Show more output
            if ((Flags & DockerComposeCommonFlags.Verbose) != 0)
                yield return "--verbose";
            // --no-ansi: Do not print ANSI control characters
            if ((Flags & DockerComposeCommonFlags.NoAnsi) != 0)
                yield return "--no-ansi";
            // -v, --version: Print version and exit
            if ((Flags & DockerComposeCommonFlags.Version) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--version" : "-v";
            // --tls: Use TLS; implied by --tlsverify
            if ((Flags & DockerComposeCommonFlags.Tls) != 0)
                yield return "--tls";
            // --tlsverify: Use TLS and verify the remote
            if ((Flags & DockerComposeCommonFlags.Tlsverify) != 0)
                yield return "--tlsverify";
            // --skip-hostname-check: Don't check the daemon's hostname against the name specified in the client certificate
            if ((Flags & DockerComposeCommonFlags.SkipHostnameCheck) != 0)
                yield return "--skip-hostname-check";
            // --compatibility: If set, Compose will attempt to convert deploy keys in v3 files to their non-Swarm equivalent
            if ((Flags & DockerComposeCommonFlags.Compatibility) != 0)
                yield return "--compatibility";
            // -f, --file =FILE: Specify an alternate compose file (default: docker-compose.yml)
            if (!string.IsNullOrEmpty(File))
            {
                yield return "--file";
                yield return File;
            }
            // -p, --project-name =NAME: Specify an alternate project name (default: directory name)
            if (!string.IsNullOrEmpty(ProjectName))
            {
                yield return "--project-name";
                yield return ProjectName;
            }
            // --log-level =LEVEL: Set log level (DEBUG, INFO, WARNING, ERROR, CRITICAL)
            if (!(LogLevel is null))
            {
                yield return "--log-level";
                yield return LogLevel.Value.ToLinuxValue();
            }
            // -H, --host =HOST: Daemon socket to connect to
            if (!string.IsNullOrEmpty(Host))
            {
                yield return "--host";
                yield return Host;
            }
            // --tlscacert =CA_PATH: Trust certs signed only by this CA
            if (!string.IsNullOrEmpty(Tlscacert))
            {
                yield return "--tlscacert";
                yield return Tlscacert;
            }
            // --tlscert =CLIENT_CERT_PATH: Path to TLS certificate file
            if (!string.IsNullOrEmpty(Tlscert))
            {
                yield return "--tlscert";
                yield return Tlscert;
            }
            // --tlskey =TLS_KEY_PATH: Path to TLS key file
            if (!string.IsNullOrEmpty(Tlskey))
            {
                yield return "--tlskey";
                yield return Tlskey;
            }
            // --project-directory =PATH: Specify an alternate working directory (default: the path of the Compose file)
            if (!string.IsNullOrEmpty(ProjectDirectory))
            {
                yield return "--project-directory";
                yield return ProjectDirectory;
            }
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public DockerComposeCommonOptions WithCompatibility(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.Compatibility, value);
            return this;
        }

        /// <summary>
        /// -f, --file =FILE: Specify an alternate compose file (default: docker-compose.yml)
        /// </summary>
        /// <param name="file">alternate compose file</param>
        public DockerComposeCommonOptions WithFile(string file)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            File = file;
            return this;
        }

        /// <summary>
        /// -H, --host =HOST: Daemon socket to connect to
        /// </summary>
        /// <param name="host">daemon socket to connect to</param>
        public DockerComposeCommonOptions WithHost(string host)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Host = host;
            return this;
        }

        /// <summary>
        /// --log-level =LEVEL: Set log level (DEBUG, INFO, WARNING, ERROR, CRITICAL)
        /// </summary>
        /// <param name="level"></param>
        public DockerComposeCommonOptions WithLogLevel(DockerComposeCommonLogLevelValues? level)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            LogLevel = level;
            return this;
        }

        public DockerComposeCommonOptions WithNoAnsi(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.NoAnsi, value);
            return this;
        }

        /// <summary>
        /// --project-directory =PATH: Specify an alternate working directory (default: the path of the Compose file)
        /// </summary>
        /// <param name="path">alternate working directory</param>
        public DockerComposeCommonOptions WithProjectDirectory(string path)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ProjectDirectory = path;
            return this;
        }

        /// <summary>
        /// -p, --project-name =NAME: Specify an alternate project name (default: directory name)
        /// </summary>
        /// <param name="name">alternate project name</param>
        public DockerComposeCommonOptions WithProjectName(string name)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ProjectName = name;
            return this;
        }

        public DockerComposeCommonOptions WithSkipHostnameCheck(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.SkipHostnameCheck, value);
            return this;
        }

        public DockerComposeCommonOptions WithTls(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.Tls, value);
            return this;
        }

        /// <summary>
        /// --tlscacert =CA_PATH: Trust certs signed only by this CA
        /// </summary>
        /// <param name="caPath">Trust certs signed only by this CA</param>
        public DockerComposeCommonOptions WithTlscacert(string caPath)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Tlscacert = caPath;
            return this;
        }

        /// <summary>
        /// --tlscert =CLIENT_CERT_PATH: Path to TLS certificate file
        /// </summary>
        /// <param name="clientCertPath">Path to TLS certificate file</param>
        public DockerComposeCommonOptions WithTlscert(string clientCertPath)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Tlscert = clientCertPath;
            return this;
        }

        /// <summary>
        /// --tlskey =TLS_KEY_PATH: Path to TLS key file
        /// </summary>
        /// <param name="tlsKeyPath">Path to TLS key file</param>
        public DockerComposeCommonOptions WithTlskey(string tlsKeyPath)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Tlskey = tlsKeyPath;
            return this;
        }

        public DockerComposeCommonOptions WithTlsverify(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.Tlsverify, value);
            return this;
        }

        public DockerComposeCommonOptions WithVerbose(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.Verbose, value);
            return this;
        }

        public DockerComposeCommonOptions WithVersion(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:398
            Flags = Flags.SetOrClear(DockerComposeCommonFlags.Version, value);
            return this;
        }

        public DockerComposeCommonFlags Flags { get; set; }

        /// <summary>
        /// -f, --file =FILE: Specify an alternate compose file (default: docker-compose.yml)
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// -p, --project-name =NAME: Specify an alternate project name (default: directory name)
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// --log-level =LEVEL: Set log level (DEBUG, INFO, WARNING, ERROR, CRITICAL)
        /// </summary>
        public DockerComposeCommonLogLevelValues? LogLevel { get; set; }

        /// <summary>
        /// -H, --host =HOST: Daemon socket to connect to
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// --tlscacert =CA_PATH: Trust certs signed only by this CA
        /// </summary>
        public string Tlscacert { get; set; }

        /// <summary>
        /// --tlscert =CLIENT_CERT_PATH: Path to TLS certificate file
        /// </summary>
        public string Tlscert { get; set; }

        /// <summary>
        /// --tlskey =TLS_KEY_PATH: Path to TLS key file
        /// </summary>
        public string Tlskey { get; set; }

        /// <summary>
        /// --project-directory =PATH: Specify an alternate working directory (default: the path of the Compose file)
        /// </summary>
        public string ProjectDirectory { get; set; }

    }

    [Flags]
    public enum DockerComposeCommonFlags
    {
        None = 0,
        /// <summary>
        /// --verbose: Show more output
        /// </summary>
        Verbose = 1,
        /// <summary>
        /// --no-ansi: Do not print ANSI control characters
        /// </summary>
        NoAnsi = 2,
        /// <summary>
        /// -v, --version: Print version and exit
        /// </summary>
        Version = 4,
        /// <summary>
        /// --tls: Use TLS; implied by --tlsverify
        /// </summary>
        Tls = 8,
        /// <summary>
        /// --tlsverify: Use TLS and verify the remote
        /// </summary>
        Tlsverify = 16,
        /// <summary>
        /// --skip-hostname-check: Don't check the daemon's hostname against the name specified in the client certificate
        /// </summary>
        SkipHostnameCheck = 32,
        /// <summary>
        /// --compatibility: If set, Compose will attempt to convert deploy keys in v3 files to their non-Swarm equivalent
        /// </summary>
        Compatibility = 64
    }

    public enum DockerComposeCommonLogLevelValues
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical
    }
}
