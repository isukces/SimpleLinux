using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class ShellEnumOptions
    {
        private ShellEnumOptions([NotNull] IReadOnlyList<ShellEnumOptionsItem> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public static ShellEnumOptions Make(string[] enumValues)
        {
            if (enumValues == null || enumValues.Length == 0)
                return null;
            return new ShellEnumOptions(enumValues.Select(a => a.Trim()).Distinct()
                .Select(q => new ShellEnumOptionsItem(q)).ToArray());
        }

        public IReadOnlyList<ShellEnumOptionsItem> Items { get; }

        public class ShellEnumOptionsItem
        {
            public ShellEnumOptionsItem(string linuxValue)
            {
                LinuxValue = linuxValue;
            }

            public string LinuxValue { get; }
            public string CsValue    => LinuxValue.ToLower().FirstUpper();
        }
    }
}