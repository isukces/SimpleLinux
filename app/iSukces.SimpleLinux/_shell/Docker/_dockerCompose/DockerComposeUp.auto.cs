// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
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
            // Detached mode: Run containers in the background, print new container names. Incompatible with --abort-on-container-exit.
            if ((value & DockerComposeUpFlags.Detach) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--detach" : "-d";
            // Produce monochrome output.
            if ((value & DockerComposeUpFlags.NoColor) != 0)
                yield return "--no-color";
            // Pull without printing progress information
            if ((value & DockerComposeUpFlags.QuietPull) != 0)
                yield return "--quiet-pull";
            // Don't start linked services.
            if ((value & DockerComposeUpFlags.NoDeps) != 0)
                yield return "--no-deps";
            // Recreate containers even if their configuration and image haven't changed.
            if ((value & DockerComposeUpFlags.ForceRecreate) != 0)
                yield return "--force-recreate";
            // Recreate dependent containers. Incompatible with --no-recreate.
            if ((value & DockerComposeUpFlags.AlwaysRecreateDeps) != 0)
                yield return "--always-recreate-deps";
            // If containers already exist, don't recreate them. Incompatible with --force-recreate and --renew-anon-volumes.
            if ((value & DockerComposeUpFlags.NoRecreate) != 0)
                yield return "--no-recreate";
            // Don't build an image, even if it's missing.
            if ((value & DockerComposeUpFlags.NoBuild) != 0)
                yield return "--no-build";
            // Don't start the services after creating them.
            if ((value & DockerComposeUpFlags.NoStart) != 0)
                yield return "--no-start";
            // Build images before starting containers.
            if ((value & DockerComposeUpFlags.Build) != 0)
                yield return "--build";
            // Stops all containers if any container was stopped. Incompatible with --detach.
            if ((value & DockerComposeUpFlags.AbortOnContainerExit) != 0)
                yield return "--abort-on-container-exit";
            // Attach to dependent containers.
            if ((value & DockerComposeUpFlags.AttachDependencies) != 0)
                yield return "--attach-dependencies";
            // Recreate anonymous volumes instead of retrieving data from the previous containers.
            if ((value & DockerComposeUpFlags.RenewAnonVolumes) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--renew-anon-volumes" : "-V";
            // Remove containers for services not defined in the Compose file.
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

    public partial struct DockerComposeUpOptions : IDockerComposeOption
    {
        public DockerComposeUpOptions WithAbortOnContainerExit(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.AbortOnContainerExit, value);
            return this;
        }

        public DockerComposeUpOptions WithAlwaysRecreateDeps(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.AlwaysRecreateDeps, value);
            return this;
        }

        public DockerComposeUpOptions WithAttachDependencies(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.AttachDependencies, value);
            return this;
        }

        public DockerComposeUpOptions WithBuild(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.Build, value);
            return this;
        }

        public DockerComposeUpOptions WithDetach(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.Detach, value);
            return this;
        }

        public DockerComposeUpOptions WithForceRecreate(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.ForceRecreate, value);
            return this;
        }

        public DockerComposeUpOptions WithNoBuild(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.NoBuild, value);
            return this;
        }

        public DockerComposeUpOptions WithNoColor(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.NoColor, value);
            return this;
        }

        public DockerComposeUpOptions WithNoDeps(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.NoDeps, value);
            return this;
        }

        public DockerComposeUpOptions WithNoRecreate(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.NoRecreate, value);
            return this;
        }

        public DockerComposeUpOptions WithNoStart(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.NoStart, value);
            return this;
        }

        public DockerComposeUpOptions WithQuietPull(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.QuietPull, value);
            return this;
        }

        public DockerComposeUpOptions WithRemoveOrphans(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.RemoveOrphans, value);
            return this;
        }

        public DockerComposeUpOptions WithRenewAnonVolumes(bool value = true)
        {
            Options = Options.SetOrClear(DockerComposeUpFlags.RenewAnonVolumes, value);
            return this;
        }

        public DockerComposeUpFlags Options { get; set; }

    }

    [Flags]
    public enum DockerComposeUpFlags
    {
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
