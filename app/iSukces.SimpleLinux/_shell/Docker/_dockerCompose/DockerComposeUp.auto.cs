// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.Docker
{
    public static partial class DockerComposeUpExtensions
    {
        public static void CheckConflicts(this DockerComposeUpFlags value)
        {
            var flagsFilter = DockerComposeUpFlags.AbortOnContainerExit | DockerComposeUpFlags.Detach;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options --abort-on-container-exit and --detach can't be used together");
            flagsFilter = DockerComposeUpFlags.AlwaysRecreateDeps | DockerComposeUpFlags.NoRecreate;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options --always-recreate-deps and --no-recreate can't be used together");
            flagsFilter = DockerComposeUpFlags.ForceRecreate | DockerComposeUpFlags.NoRecreate;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options --force-recreate and --no-recreate can't be used together");
            flagsFilter = DockerComposeUpFlags.NoRecreate | DockerComposeUpFlags.RenewAnonVolumes;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options --no-recreate and --renew-anon-volumes can't be used together");
        }

        public static IEnumerable<string> OptionsToString(this DockerComposeUpFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            CheckConflicts(value);
            // -d, --detach: Detached mode: Run containers in the background, print new container names. Incompatible with --abort-on-container-exit.
            if ((value & DockerComposeUpFlags.Detach) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--detach" : "-d";
            // --no-color: Produce monochrome output.
            if ((value & DockerComposeUpFlags.NoColor) != 0)
                yield return "--no-color";
            // --quiet-pull: Pull without printing progress information
            if ((value & DockerComposeUpFlags.QuietPull) != 0)
                yield return "--quiet-pull";
            // --no-deps: Don't start linked services.
            if ((value & DockerComposeUpFlags.NoDeps) != 0)
                yield return "--no-deps";
            // --force-recreate: Recreate containers even if their configuration and image haven't changed.
            if ((value & DockerComposeUpFlags.ForceRecreate) != 0)
                yield return "--force-recreate";
            // --always-recreate-deps: Recreate dependent containers. Incompatible with --no-recreate.
            if ((value & DockerComposeUpFlags.AlwaysRecreateDeps) != 0)
                yield return "--always-recreate-deps";
            // --no-recreate: If containers already exist, don't recreate them. Incompatible with --force-recreate and --renew-anon-volumes.
            if ((value & DockerComposeUpFlags.NoRecreate) != 0)
                yield return "--no-recreate";
            // --no-build: Don't build an image, even if it's missing.
            if ((value & DockerComposeUpFlags.NoBuild) != 0)
                yield return "--no-build";
            // --no-start: Don't start the services after creating them.
            if ((value & DockerComposeUpFlags.NoStart) != 0)
                yield return "--no-start";
            // --build: Build images before starting containers.
            if ((value & DockerComposeUpFlags.Build) != 0)
                yield return "--build";
            // --abort-on-container-exit: Stops all containers if any container was stopped. Incompatible with --detach.
            if ((value & DockerComposeUpFlags.AbortOnContainerExit) != 0)
                yield return "--abort-on-container-exit";
            // --attach-dependencies: Attach to dependent containers.
            if ((value & DockerComposeUpFlags.AttachDependencies) != 0)
                yield return "--attach-dependencies";
            // -V, --renew-anon-volumes: Recreate anonymous volumes instead of retrieving data from the previous containers.
            if ((value & DockerComposeUpFlags.RenewAnonVolumes) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--renew-anon-volumes" : "-V";
            // --remove-orphans: Remove containers for services not defined in the Compose file.
            if ((value & DockerComposeUpFlags.RemoveOrphans) != 0)
                yield return "--remove-orphans";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DockerComposeUpFlags SetOrClear(this DockerComposeUpFlags current, DockerComposeUpFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    public partial class DockerComposeUpOptions : IDockerComposeOption
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -d, --detach: Detached mode: Run containers in the background, print new container names. Incompatible with --abort-on-container-exit.
            if ((Flags & DockerComposeUpFlags.Detach) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--detach" : "-d";
            // --no-color: Produce monochrome output.
            if ((Flags & DockerComposeUpFlags.NoColor) != 0)
                yield return "--no-color";
            // --quiet-pull: Pull without printing progress information
            if ((Flags & DockerComposeUpFlags.QuietPull) != 0)
                yield return "--quiet-pull";
            // --no-deps: Don't start linked services.
            if ((Flags & DockerComposeUpFlags.NoDeps) != 0)
                yield return "--no-deps";
            // --force-recreate: Recreate containers even if their configuration and image haven't changed.
            if ((Flags & DockerComposeUpFlags.ForceRecreate) != 0)
                yield return "--force-recreate";
            // --always-recreate-deps: Recreate dependent containers. Incompatible with --no-recreate.
            if ((Flags & DockerComposeUpFlags.AlwaysRecreateDeps) != 0)
                yield return "--always-recreate-deps";
            // --no-recreate: If containers already exist, don't recreate them. Incompatible with --force-recreate and --renew-anon-volumes.
            if ((Flags & DockerComposeUpFlags.NoRecreate) != 0)
                yield return "--no-recreate";
            // --no-build: Don't build an image, even if it's missing.
            if ((Flags & DockerComposeUpFlags.NoBuild) != 0)
                yield return "--no-build";
            // --no-start: Don't start the services after creating them.
            if ((Flags & DockerComposeUpFlags.NoStart) != 0)
                yield return "--no-start";
            // --build: Build images before starting containers.
            if ((Flags & DockerComposeUpFlags.Build) != 0)
                yield return "--build";
            // --abort-on-container-exit: Stops all containers if any container was stopped. Incompatible with --detach.
            if ((Flags & DockerComposeUpFlags.AbortOnContainerExit) != 0)
                yield return "--abort-on-container-exit";
            // --attach-dependencies: Attach to dependent containers.
            if ((Flags & DockerComposeUpFlags.AttachDependencies) != 0)
                yield return "--attach-dependencies";
            // -V, --renew-anon-volumes: Recreate anonymous volumes instead of retrieving data from the previous containers.
            if ((Flags & DockerComposeUpFlags.RenewAnonVolumes) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--renew-anon-volumes" : "-V";
            // --remove-orphans: Remove containers for services not defined in the Compose file.
            if ((Flags & DockerComposeUpFlags.RemoveOrphans) != 0)
                yield return "--remove-orphans";
            // -t, --timeout =TIMEOUT: Use this timeout in seconds for container shutdown when attached or when containers are already running. (default: 10)
            if (!(Timeout is null))
            {
                yield return "--timeout";
                yield return Timeout.Value.ToString(CultureInfo.InvariantCulture);
            }
            // --exit-code-from =SERVICE: Return the exit code of the selected service container. Implies --abort-on-container-exit.
            if (!string.IsNullOrEmpty(ExitCodeFrom))
            {
                yield return "--exit-code-from";
                yield return ExitCodeFrom;
            }
            // --scale SERVICE=NUM: Scale SERVICE to NUM instances. Overrides the `scale` setting in the Compose file if present.
            foreach(var pair in Scale)
            {
                yield return "--scale";
                var value = pair.Value.ToString(CultureInfo.InvariantCulture);
                yield return $"{pair.Key}={value}";
            }
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        public DockerComposeUpOptions WithAbortOnContainerExit(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.AbortOnContainerExit, value);
            return this;
        }

        public DockerComposeUpOptions WithAlwaysRecreateDeps(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.AlwaysRecreateDeps, value);
            return this;
        }

        public DockerComposeUpOptions WithAttachDependencies(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.AttachDependencies, value);
            return this;
        }

        public DockerComposeUpOptions WithBuild(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.Build, value);
            return this;
        }

        public DockerComposeUpOptions WithDetach(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.Detach, value);
            return this;
        }

        /// <summary>
        /// --exit-code-from =SERVICE: Return the exit code of the selected service container. Implies --abort-on-container-exit.
        /// </summary>
        /// <param name="service">service name</param>
        public DockerComposeUpOptions WithExitCodeFrom(string service)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ExitCodeFrom = service;
            return this;
        }

        public DockerComposeUpOptions WithForceRecreate(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.ForceRecreate, value);
            return this;
        }

        public DockerComposeUpOptions WithNoBuild(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.NoBuild, value);
            return this;
        }

        public DockerComposeUpOptions WithNoColor(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.NoColor, value);
            return this;
        }

        public DockerComposeUpOptions WithNoDeps(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.NoDeps, value);
            return this;
        }

        public DockerComposeUpOptions WithNoRecreate(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.NoRecreate, value);
            return this;
        }

        public DockerComposeUpOptions WithNoStart(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.NoStart, value);
            return this;
        }

        public DockerComposeUpOptions WithQuietPull(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.QuietPull, value);
            return this;
        }

        public DockerComposeUpOptions WithRemoveOrphans(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.RemoveOrphans, value);
            return this;
        }

        public DockerComposeUpOptions WithRenewAnonVolumes(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeUpFlags.RenewAnonVolumes, value);
            return this;
        }

        /// <summary>
        /// --scale SERVICE=NUM: Scale SERVICE to NUM instances. Overrides the `scale` setting in the Compose file if present.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="num"></param>
        public DockerComposeUpOptions WithScale(string service, int num)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Scale[service] = num;
            return this;
        }

        /// <summary>
        /// -t, --timeout =TIMEOUT: Use this timeout in seconds for container shutdown when attached or when containers are already running. (default: 10)
        /// </summary>
        /// <param name="timeout">timeout in seconds</param>
        public DockerComposeUpOptions WithTimeout(int timeout)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Timeout = timeout;
            return this;
        }

        public DockerComposeUpFlags Flags { get; set; }

        /// <summary>
        /// -t, --timeout =TIMEOUT: Use this timeout in seconds for container shutdown when attached or when containers are already running. (default: 10)
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// --exit-code-from =SERVICE: Return the exit code of the selected service container. Implies --abort-on-container-exit.
        /// </summary>
        public string ExitCodeFrom { get; set; }

        /// <summary>
        /// --scale SERVICE=NUM: Scale SERVICE to NUM instances. Overrides the `scale` setting in the Compose file if present.
        /// </summary>
        public Dictionary<string,int> Scale { get; set; } = new Dictionary<string,int>();

        public string Name
        {
            get { return "up"; }
        }

    }

    [Flags]
    public enum DockerComposeUpFlags
    {
        None = 0,
        Detach = 1,
        NoColor = 2,
        QuietPull = 4,
        NoDeps = 8,
        ForceRecreate = 16,
        AlwaysRecreateDeps = 32,
        NoRecreate = 64,
        NoBuild = 128,
        NoStart = 256,
        Build = 512,
        AbortOnContainerExit = 1024,
        AttachDependencies = 2048,
        RenewAnonVolumes = 4096,
        RemoveOrphans = 8192
    }
}
