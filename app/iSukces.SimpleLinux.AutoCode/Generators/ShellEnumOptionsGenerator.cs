using System;
using iSukces.Code;
using iSukces.Code.Interfaces;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal class ShellEnumOptionsGenerator
    {
        public ShellEnumOptionsGenerator(string shortTypeName, CsNamespace targetNamespace,
            [CanBeNull] ShellEnumOptions enumOptions)
        {
            ShortTypeName   = shortTypeName;
            TargetNamespace = targetNamespace;
            EnumOptions     = enumOptions;
        }

        public void MakeEnumIfNecessary()
        {
            if (EnumOptions is null)
                return;
            var en = new CsEnum(ShortTypeName);
            foreach (var i in EnumOptions.Items)
                en.Items.Add(new CsEnumItem(i.CsValue));
            TargetNamespace.AddEnum(en);
        }

        public void MakeExtensionMethod(CsClass target)
        {
            if (EnumOptions is null)
                return;

            var paramValue = target.GetTypeName(TypeName);

            var writer = CsCodeWriter.Create<ShellEnumOptionsGenerator>();
            writer.Open("switch (value)");
            foreach (var i in EnumOptions.Items)
            {
                var line = $"case {paramValue}.{i.CsValue}: return {i.LinuxValue.CsEncode()};";
                writer.WriteLine(line);
            }

            var notSupportedException = target.GetTypeName<NotSupportedException>();
            writer.WriteLine($"default: throw new {notSupportedException}();");
            writer.Close();

            var parameter = new CsMethodParameter("value", paramValue)
            {
                UseThis = target.IsStatic
            };

            target.AddMethod(extensionMethodName, "string")
                .WithBody(writer)
                .WithStatic()
                .WithParameter(parameter);
        }

        public string      ShortTypeName   { get; }
        public CsNamespace TargetNamespace { get; }

        [CanBeNull]
        public ShellEnumOptions EnumOptions { get; }

        public NamespaceAndName TypeName => new NamespaceAndName(TargetNamespace.Name, ShortTypeName);
        public bool             HasEnum  => !(EnumOptions is null);

        public const string extensionMethodName = "ToLinuxValue";
    }
}