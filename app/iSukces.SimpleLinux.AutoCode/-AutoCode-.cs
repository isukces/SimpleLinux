// ReSharper disable All
#pragma warning disable 1591
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    partial class ParametrizedOptionBuilder
    {
        public ParametrizedOptionBuilder()
        {
        }

        public ParametrizedOptionBuilder(ParametrizedOption source)
        {
            if (source is null) return;
            Value = source.Value;
            Name = source.Name;
            Encoder = source.Encoder;
            ValueDescription = source.ValueDescription;
            PropertyName = source.PropertyName;
            IsCollection = source.IsCollection;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOption Build()
        {
            return new ParametrizedOption(Value, Name, Encoder, ValueDescription, PropertyName, IsCollection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithEncoder(ParametrizedOption.ValueEncoder newEncoder)
        {
            Encoder = newEncoder;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithIsCollection(bool newIsCollection)
        {
            IsCollection = newIsCollection;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithName(string newName)
        {
            Name = newName;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithPropertyName(string newPropertyName)
        {
            PropertyName = newPropertyName;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithValue(string newValue)
        {
            Value = newValue;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParametrizedOptionBuilder WithValueDescription(string newValueDescription)
        {
            ValueDescription = newValueDescription;
            return this;
        }

        public string Value { get; set; }

        public string Name { get; set; }

        public ParametrizedOption.ValueEncoder Encoder { get; set; }

        public string ValueDescription { get; set; }

        public string PropertyName { get; set; }

        public bool IsCollection { get; set; }

    }
}
