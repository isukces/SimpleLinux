using System;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple = true)]
    public class StringPropertyAttribute:Attribute
    {
        public StringPropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
            
    }
}