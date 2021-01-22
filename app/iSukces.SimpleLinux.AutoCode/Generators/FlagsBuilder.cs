using System;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    /// <summary>
    ///     Helps to create enums with [Flag]
    /// </summary>
    internal class FlagsBuilder
    {
        public FlagsBuilder(CsEnum target, string none = "None")
        {
            _target = target;
            if (!string.IsNullOrEmpty(none))
                _target.Items.Add(new CsEnumItem(none)
                {
                    EncodedValue = "0"
                });
        }

        public void AddFlagsAttribute(ITypeNameResolver resolver)
        {
            _target.WithAttribute(new CsAttribute(resolver.GetTypeName<FlagsAttribute>()));
        }

        public void Append(CsEnumItem enumItem)
        {
            enumItem.EncodedValue = Value.ToInv();
            _target.Items.Add(enumItem);
            Value *= 2;
        }

        public int Value { get; private set; } = 1;
        private readonly CsEnum _target;
    }
}