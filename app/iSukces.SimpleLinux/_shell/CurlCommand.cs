using System;
using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public partial class CurlCommand : OnelineLinuxCommand
    {
        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        public CurlCommand(string url)
        {
            Url = url;
        }

        public override IEnumerable<string> GetItems()
        {
            yield return "curl";
            foreach (var i in this.GetCodeItems(OptionPreference.Short))
                yield return i;
        }
    }
}