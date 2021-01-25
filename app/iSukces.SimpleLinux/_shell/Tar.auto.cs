// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux
{
    public partial class TarCommand
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -z, --gzip: Filter the archive through gzip(1).
            if ((Flags & TarFlags.Gzip) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--gzip" : "-z";
            // -Z, --compress: Filter the archive through compress(1).
            if ((Flags & TarFlags.Compress) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--compress" : "-Z";
            // -v: Verbose
            if ((Flags & TarFlags.Verbose) != 0)
                yield return "-v";
            // -f =tar-archive: Archive
            if (!string.IsNullOrEmpty(ArchiveFileName))
            {
                yield return "-f";
                yield return ArchiveFileName.ShellQuote();
            }
        }

        /// <summary>
        /// -f =tar-archive: Archive
        /// </summary>
        /// <param name="tarArchive"></param>
        public TarCommand WithArchiveFileName(string tarArchive)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ArchiveFileName = tarArchive;
            return this;
        }

        /// <summary>
        /// -Z, --compress: Filter the archive through compress(1).
        /// </summary>
        /// <param name="value"></param>
        public TarCommand WithCompress(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(TarFlags.Compress, value);
            return this;
        }

        /// <summary>
        /// -z, --gzip: Filter the archive through gzip(1).
        /// </summary>
        /// <param name="value"></param>
        public TarCommand WithGzip(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(TarFlags.Gzip, value);
            return this;
        }

        /// <summary>
        /// -v: Verbose
        /// </summary>
        /// <param name="value"></param>
        public TarCommand WithVerbose(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(TarFlags.Verbose, value);
            return this;
        }

        public TarFlags Flags { get; set; }

        /// <summary>
        /// -f =tar-archive: Archive
        /// </summary>
        public string ArchiveFileName { get; set; }

    }

    public static partial class TarExtensions
    {
        public static void CheckConflicts(this TarFlags value)
        {
            var flagsFilter = TarFlags.Compress | TarFlags.Gzip;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options --compress and --gzip can't be used together");
        }

        public static IEnumerable<string> OptionsToString(this TarFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            CheckConflicts(value);
            // -z, --gzip: Filter the archive through gzip(1).
            if ((value & TarFlags.Gzip) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--gzip" : "-z";
            // -Z, --compress: Filter the archive through compress(1).
            if ((value & TarFlags.Compress) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--compress" : "-Z";
            // -v: Verbose
            if ((value & TarFlags.Verbose) != 0)
                yield return "-v";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TarFlags SetOrClear(this TarFlags current, TarFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    [Flags]
    public enum TarFlags: byte
    {
        None = 0,
        /// <summary>
        /// -z, --gzip: Filter the archive through gzip(1).
        /// </summary>
        Gzip = 1,
        /// <summary>
        /// -Z, --compress: Filter the archive through compress(1).
        /// </summary>
        Compress = 2,
        /// <summary>
        /// -v: Verbose
        /// </summary>
        Verbose = 4
    }
}
