// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux
{
    public static partial class UnzipExtensions
    {
        public static IEnumerable<string> OptionsToString(this UnzipFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            // -o: Overwrite existing files without prompting.
            if ((value & UnzipFlags.Overwrite) != 0)
                yield return "-o";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnzipFlags SetOrClear(this UnzipFlags current, UnzipFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    public partial class UnzipOptions
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -o: Overwrite existing files without prompting.
            if ((Flags & UnzipFlags.Overwrite) != 0)
                yield return "-o";
            // -x exclude: An optional list of archive members to be excluded from processing.
            if (!(X is null) && X.Count > 0)
            {
                yield return "-x";
                foreach (var xItem in X)
                    yield return xItem.ShellQuote();
            }
            // -d =output-directory: An optional directory to which to extract files.
            if (!string.IsNullOrEmpty(OutputDirectory))
            {
                yield return "-d";
                yield return OutputDirectory.ShellQuote();
            }
        }

        /// <summary>
        /// -x exclude: An optional list of archive members to be excluded from processing.
        /// </summary>
        /// <param name="exclude">Items to exclude</param>
        public UnzipOptions WithAppendX(string[] exclude)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            if (!(exclude is null) && exclude.Length > 0)
                foreach (var tmp in exclude)
                    X.Add(tmp);
            return this;
        }

        /// <summary>
        /// -d =output-directory: An optional directory to which to extract files.
        /// </summary>
        /// <param name="outputDirectory">Output directory</param>
        public UnzipOptions WithOutputDirectory(string outputDirectory)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            OutputDirectory = outputDirectory;
            return this;
        }

        /// <summary>
        /// -o: Overwrite existing files without prompting.
        /// </summary>
        /// <param name="value"></param>
        public UnzipOptions WithOverwrite(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UnzipFlags.Overwrite, value);
            return this;
        }

        public UnzipFlags Flags { get; set; }

        /// <summary>
        /// -x exclude: An optional list of archive members to be excluded from processing.
        /// </summary>
        public IList<string> X { get; set; } = new List<string>();

        /// <summary>
        /// -d =output-directory: An optional directory to which to extract files.
        /// </summary>
        public string OutputDirectory { get; set; }

    }

    [Flags]
    public enum UnzipFlags: byte
    {
        None = 0,
        /// <summary>
        /// -o: Overwrite existing files without prompting.
        /// </summary>
        Overwrite = 1
    }
}
