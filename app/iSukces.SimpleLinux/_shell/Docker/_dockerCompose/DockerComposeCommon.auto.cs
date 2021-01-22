// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
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

    }

    public partial class DockerComposeCommonOptions : ICommandsPartsProvider
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // --verbose: Show more output
            if ((Options & DockerComposeCommonFlags.Verbose) != 0)
                yield return "--verbose";
            // --no-ansi: Do not print ANSI control characters
            if ((Options & DockerComposeCommonFlags.NoAnsi) != 0)
                yield return "--no-ansi";
            // -v, --version: Print version and exit
            if ((Options & DockerComposeCommonFlags.Version) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--version" : "-v";
            // --tls: Use TLS; implied by --tlsverify
            if ((Options & DockerComposeCommonFlags.Tls) != 0)
                yield return "--tls";
            // --tlsverify: Use TLS and verify the remote
            if ((Options & DockerComposeCommonFlags.Tlsverify) != 0)
                yield return "--tlsverify";
            // --skip-hostname-check: Don't check the daemon's hostname against the name specified in the client certificate
            if ((Options & DockerComposeCommonFlags.SkipHostnameCheck) != 0)
                yield return "--skip-hostname-check";
            // --compatibility: If set, Compose will attempt to convert deploy keys in v3 files to their non-Swarm equivalent
            if ((Options & DockerComposeCommonFlags.Compatibility) != 0)
                yield return "--compatibility";
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public DockerComposeCommonOptions WithCompatibility(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.Compatibility, value);
            return this;
        }

        public DockerComposeCommonOptions WithNoAnsi(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.NoAnsi, value);
            return this;
        }

        public DockerComposeCommonOptions WithSkipHostnameCheck(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.SkipHostnameCheck, value);
            return this;
        }

        public DockerComposeCommonOptions WithTls(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.Tls, value);
            return this;
        }

        public DockerComposeCommonOptions WithTlsverify(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.Tlsverify, value);
            return this;
        }

        public DockerComposeCommonOptions WithVerbose(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.Verbose, value);
            return this;
        }

        public DockerComposeCommonOptions WithVersion(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeCommonFlags.Version, value);
            return this;
        }

        public DockerComposeCommonFlags Options { get; set; }

    }

    [Flags]
    public enum DockerComposeCommonFlags
    {
        None = 0,
        Verbose = 1,
        NoAnsi = 2,
        Version = 4,
        Tls = 8,
        Tlsverify = 16,
        SkipHostnameCheck = 32,
        Compatibility = 64
    }
}
