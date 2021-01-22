// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.Docker
{
    public static partial class DockerComposeConfigExtensions
    {
        public static IEnumerable<string> OptionsToString(this DockerComposeConfigFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            // --resolve-image-digests: Pin image tags to digests.
            if ((value & DockerComposeConfigFlags.ResolveImageDigests) != 0)
                yield return "--resolve-image-digests";
            // --no-interpolate: Don't interpolate environment variables.
            if ((value & DockerComposeConfigFlags.NoInterpolate) != 0)
                yield return "--no-interpolate";
            // -q, --quiet: Only validate the configuration, don't print anything.
            if ((value & DockerComposeConfigFlags.Quiet) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--quiet" : "-q";
            // --services: Print the service names, one per line.
            if ((value & DockerComposeConfigFlags.Services) != 0)
                yield return "--services";
            // --volumes: Print the volume names, one per line.
            if ((value & DockerComposeConfigFlags.Volumes) != 0)
                yield return "--volumes";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DockerComposeConfigFlags SetOrClear(this DockerComposeConfigFlags current, DockerComposeConfigFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    public partial class DockerComposeConfigOptions : IDockerComposeOption
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // --resolve-image-digests: Pin image tags to digests.
            if ((Flags & DockerComposeConfigFlags.ResolveImageDigests) != 0)
                yield return "--resolve-image-digests";
            // --no-interpolate: Don't interpolate environment variables.
            if ((Flags & DockerComposeConfigFlags.NoInterpolate) != 0)
                yield return "--no-interpolate";
            // -q, --quiet: Only validate the configuration, don't print anything.
            if ((Flags & DockerComposeConfigFlags.Quiet) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--quiet" : "-q";
            // --services: Print the service names, one per line.
            if ((Flags & DockerComposeConfigFlags.Services) != 0)
                yield return "--services";
            // --volumes: Print the volume names, one per line.
            if ((Flags & DockerComposeConfigFlags.Volumes) != 0)
                yield return "--volumes";
            // --hash =servicesOrWild: Print the service config hash, one per line. Set "service1,service2" for a list of specified services or use the wildcard symbol to display all services.
            if (!string.IsNullOrEmpty(Hash))
            {
                yield return "--hash";
                yield return Hash;
            }
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        /// <summary>
        /// --hash =servicesOrWild: Print the service config hash, one per line. Set "service1,service2" for a list of specified services or use the wildcard symbol to display all services.
        /// </summary>
        /// <param name="servicesorwild">services</param>
        public DockerComposeConfigOptions WithHash(string servicesorwild)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Hash = servicesorwild;
            return this;
        }

        public DockerComposeConfigOptions WithNoInterpolate(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeConfigFlags.NoInterpolate, value);
            return this;
        }

        public DockerComposeConfigOptions WithQuiet(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeConfigFlags.Quiet, value);
            return this;
        }

        public DockerComposeConfigOptions WithResolveImageDigests(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeConfigFlags.ResolveImageDigests, value);
            return this;
        }

        public DockerComposeConfigOptions WithServices(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeConfigFlags.Services, value);
            return this;
        }

        public DockerComposeConfigOptions WithVolumes(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:344
            Flags = Flags.SetOrClear(DockerComposeConfigFlags.Volumes, value);
            return this;
        }

        public DockerComposeConfigFlags Flags { get; set; }

        /// <summary>
        /// --hash =servicesOrWild: Print the service config hash, one per line. Set "service1,service2" for a list of specified services or use the wildcard symbol to display all services.
        /// </summary>
        public string Hash { get; set; }

        public string Name
        {
            get { return "config"; }
        }

    }

    [Flags]
    public enum DockerComposeConfigFlags
    {
        None = 0,
        ResolveImageDigests = 1,
        NoInterpolate = 2,
        Quiet = 4,
        Services = 8,
        Volumes = 16
    }
}
