// ReSharper disable All
#pragma warning disable 1591
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    partial class ParametrizedOption
    {
        public string Name
        {
            get { return _name; }
            set { _name = value?.Trim() ?? string.Empty; }
        }

        private string _name;

        public string Value
        {
            get { return _value; }
            set { _value = value?.Trim() ?? string.Empty; }
        }

        private string _value;

        public string ValueDescription
        {
            get { return _valueDescription; }
            set { _valueDescription = value?.Trim() ?? string.Empty; }
        }

        private string _valueDescription;

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value?.Trim() ?? string.Empty; }
        }

        private string _propertyName;

    }
}
