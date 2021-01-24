// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if ((Flags & DockerComposeBuildFlags.Compress) != 0)
                yield return "--compress";
            // --force-rm: Always remove intermediate containers.
            if ((Flags & DockerComposeBuildFlags.ForceRm) != 0)
                yield return "--force-rm";
            // --no-cache: Do not use cache when building the image.
            if ((Flags & DockerComposeBuildFlags.NoCache) != 0)
                yield return "--no-cache";
            // --no-rm: Do not remove intermediate containers after a successful build.
            if ((Flags & DockerComposeBuildFlags.NoRm) != 0)
                yield return "--no-rm";
            // --parallel: Build images in parallel.
            if ((Flags & DockerComposeBuildFlags.Parallel) != 0)
                yield return "--parallel";
            // --pull: Always attempt to pull a newer version of the image.
            if ((Flags & DockerComposeBuildFlags.Pull) != 0)
                yield return "--pull";
            // -q, --quiet: Don't print anything to `STDOUT`.
            if ((Flags & DockerComposeBuildFlags.Quiet) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--quiet" : "-q";
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        /// <summary>
        /// --compress: Compress the build context using gzip.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithCompress(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.Compress, value);
            return this;
        }

        /// <summary>
        /// --force-rm: Always remove intermediate containers.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithForceRm(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.ForceRm, value);
            return this;
        }

        /// <summary>
        /// --no-cache: Do not use cache when building the image.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithNoCache(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.NoCache, value);
            return this;
        }

        /// <summary>
        /// --no-rm: Do not remove intermediate containers after a successful build.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithNoRm(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.NoRm, value);
            return this;
        }

        /// <summary>
        /// --parallel: Build images in parallel.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithParallel(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.Parallel, value);
            return this;
        }

        /// <summary>
        /// --pull: Always attempt to pull a newer version of the image.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithPull(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.Pull, value);
            return this;
        }

        /// <summary>
        /// -q, --quiet: Don't print anything to `STDOUT`.
        /// </summary>
        /// <param name="value"></param>
        public DockerComposeBuildOptions WithQuiet(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(DockerComposeBuildFlags.Quiet, value);
            return this;
        }

        public DockerComposeBuildFlags Flags { get; set; }

        public string Name
        {
            get { return "build"; }
        }

    }

    [Flags]
    public enum DockerComposeBuildFlags: byte
    {
        None = 0,
        /// <summary>
        /// --compress: Compress the build context using gzip.
        /// </summary>
        Compress = 1,
        /// <summary>
        /// --force-rm: Always remove intermediate containers.
        /// </summary>
        ForceRm = 2,
        /// <summary>
        /// --no-cache: Do not use cache when building the image.
        /// </summary>
        NoCache = 4,
        /// <summary>
        /// --no-rm: Do not remove intermediate containers after a successful build.
        /// </summary>
        NoRm = 8,
        /// <summary>
        /// --parallel: Build images in parallel.
        /// </summary>
        Parallel = 16,
        /// <summary>
        /// --pull: Always attempt to pull a newer version of the image.
        /// </summary>
        Pull = 32,
        /// <summary>
        /// -q, --quiet: Don't print anything to `STDOUT`.
        /// </summary>
        Quiet = 64
    }
}
