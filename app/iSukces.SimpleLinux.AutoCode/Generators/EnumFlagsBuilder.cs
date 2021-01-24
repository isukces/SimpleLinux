using System;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    /// <summary>
    ///     Helps to create enums with [Flag]
    /// </summary>
    internal class EnumFlagsBuilder
    {
        public EnumFlagsBuilder(CsEnum target, string none = "None")
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
            _target.UnderlyingType =  GetUnderlyingType();
            Value                  *= 2;
        }

        private string GetUnderlyingType()
        {
            if (Value > long.MaxValue)
                return "ulong";
            if (Value > int.MaxValue)
                return "long";
            if (Value > (long)short.MaxValue)
                return "";
            if (Value > byte.MaxValue)
                return "short";
            return "byte";
        }

        public ulong Value { get; private set; } = 1;
        private readonly CsEnum _target;
    }
}