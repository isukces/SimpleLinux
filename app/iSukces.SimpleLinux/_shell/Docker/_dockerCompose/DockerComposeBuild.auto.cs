// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.Docker
{
    public static partial class DockerComposeBuildExtensions
    {
        public static IEnumerable<string> OptionsToString(this DockerComposeBuildFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            // --compress: Compress the build context using gzip.
            if ((value & DockerComposeBuildFlags.Compress) != 0)
                yield return "--compress";
            // --force-rm: Always remove intermediate containers.
            if ((value & DockerComposeBuildFlags.ForceRm) != 0)
                yield return "--force-rm";
            // --no-cache: Do not use cache when building the image.
            if ((value & DockerComposeBuildFlags.NoCache) != 0)
                yield return "--no-cache";
            // --no-rm: Do not remove intermediate containers after a successful build.
            if ((value & DockerComposeBuildFlags.NoRm) != 0)
                yield return "--no-rm";
            // --parallel: Build images in parallel.
            if ((value & DockerComposeBuildFlags.Parallel) != 0)
                yield return "--parallel";
            // --pull: Always attempt to pull a newer version of the image.
            if ((value & DockerComposeBuildFlags.Pull) != 0)
                yield return "--pull";
            // -q, --quiet: Don't print anything to `STDOUT`.
            if ((value & DockerComposeBuildFlags.Quiet) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--quiet" : "-q";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DockerComposeBuildFlags SetOrClear(this DockerComposeBuildFlags current, DockerComposeBuildFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    public partial class DockerComposeBuildOptions : IDockerComposeOption
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // --compress: Compress the build context using gzip.
            if ((Options & DockerComposeBuildFlags.Compress) != 0)
                yield return "--compress";
            // --force-rm: Always remove intermediate containers.
            if ((Options & DockerComposeBuildFlags.ForceRm) != 0)
                yield return "--force-rm";
            // --no-cache: Do not use cache when building the image.
            if ((Options & DockerComposeBuildFlags.NoCache) != 0)
                yield return "--no-cache";
            // --no-rm: Do not remove intermediate containers after a successful build.
            if ((Options & DockerComposeBuildFlags.NoRm) != 0)
                yield return "--no-rm";
            // --parallel: Build images in parallel.
            if ((Options & DockerComposeBuildFlags.Parallel) != 0)
                yield return "--parallel";
            // --pull: Always attempt to pull a newer version of the image.
            if ((Options & DockerComposeBuildFlags.Pull) != 0)
                yield return "--pull";
            // -q, --quiet: Don't print anything to `STDOUT`.
            if ((Options & DockerComposeBuildFlags.Quiet) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--quiet" : "-q";
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public DockerComposeBuildOptions WithCompress(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.Compress, value);
            return this;
        }

        public DockerComposeBuildOptions WithForceRm(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.ForceRm, value);
            return this;
        }

        public DockerComposeBuildOptions WithNoCache(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.NoCache, value);
            return this;
        }

        public DockerComposeBuildOptions WithNoRm(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.NoRm, value);
            return this;
        }

        public DockerComposeBuildOptions WithParallel(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.Parallel, value);
            return this;
        }

        public DockerComposeBuildOptions WithPull(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.Pull, value);
            return this;
        }

        public DockerComposeBuildOptions WithQuiet(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeBuildFlags.Quiet, value);
            return this;
        }

        public DockerComposeBuildFlags Options { get; set; }

        public string Name
        {
            get { return "build"; }
        }

    }

    [Flags]
    public enum DockerComposeBuildFlags
    {
        None = 0,
        Compress = 1,
        ForceRm = 2,
        NoCache = 4,
        NoRm = 8,
        Parallel = 16,
        Pull = 32,
        Quiet = 64
    }
}
