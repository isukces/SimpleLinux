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
    }

    public partial class UnzipOptions
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -x excludeList: An optional list of archive members to be excluded from processing.
            if (!(Exclude is null) && Exclude.Count > 0)
            {
                yield return "-x";
                foreach(var excludeItem in Exclude)
                {
                    yield return excludeItem;
                }
            }
        }

        /// <summary>
        /// -x excludeList: An optional list of archive members to be excluded from processing.
        /// </summary>
        /// <param name="excludelist">Items to exclude</param>
        public UnzipOptions WithExclude(string[] excludelist)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            if (excludelist != null)
                foreach(var tmp in excludelist)
                    Exclude.Add(tmp);
            return this;
        }

        /// <summary>
        /// -x excludeList: An optional list of archive members to be excluded from processing.
        /// </summary>
        public IList<string> Exclude { get; set; } = new List<string>();

    }
}
