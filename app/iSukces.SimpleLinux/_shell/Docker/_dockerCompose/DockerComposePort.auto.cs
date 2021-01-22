// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.Docker
{
    public static partial class DockerComposePortExtensions
    {
        public static string ToLinuxValue(this DockerComposePortProtocolValues value)
        {
            // generator : ShellEnumOptionsGenerator.MakeExtensionMethod:35
            switch (value)
            {
                case DockerComposePortProtocolValues.Tcp: return "tcp";
                case DockerComposePortProtocolValues.Udp: return "udp";
                default: throw new NotSupportedException();
            }
        }

    }

    public partial class DockerComposePortOptions : IDockerComposeOption
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // --protocol =proto: tcp or udp [default: tcp]
            if (!(Protocol is null))
            {
                yield return "--protocol";
                yield return Protocol.Value.ToLinuxValue();
            }
            // --index =index: index of the container if there are multiple instances of a service [default: 1]
            if (!(Index is null))
            {
                yield return "--index";
                yield return Index.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public IEnumerable<string> GetItems()
        {
            return GetCodeItems();
        }

        /// <summary>
        /// --index =index: index of the container if there are multiple instances of a service [default: 1]
        /// </summary>
        /// <param name="index"></param>
        public DockerComposePortOptions WithIndex(int index)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Index = index;
            return this;
        }

        /// <summary>
        /// --protocol =proto: tcp or udp [default: tcp]
        /// </summary>
        /// <param name="proto"></param>
        public DockerComposePortOptions WithProtocol(DockerComposePortProtocolValues proto)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Protocol = proto;
            return this;
        }

        /// <summary>
        /// --protocol =proto: tcp or udp [default: tcp]
        /// </summary>
        public DockerComposePortProtocolValues? Protocol { get; set; }

        /// <summary>
        /// --index =index: index of the container if there are multiple instances of a service [default: 1]
        /// </summary>
        public int? Index { get; set; }

        public string Name
        {
            get { return "port"; }
        }

    }

    public enum DockerComposePortProtocolValues
    {
        Tcp,
        Udp
    }
}
