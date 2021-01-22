using System;
using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public class CurlCommand : OnelineLinuxCommand
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
            if (Silent)
            {
                yield return "-s";
                if (Silent2)
                    yield return "-S";
            }

            if (!string.IsNullOrEmpty(OutputFile))
            {
                yield return "-o";
                yield return OutputFile;
            }

            if (!string.IsNullOrEmpty(Url))
                yield return Url;
            else
                throw new Exception("Url is empty");
        }

        public string OutputFile { get; set; }
        public string Url        { get; }
        public bool   Silent     { get; set; }
        public bool   Silent2    { get; set; }
    }
}