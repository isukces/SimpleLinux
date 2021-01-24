using System.Linq;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class EnumsGeneratorItemNames
    {
        private EnumsGeneratorItemNames(string typeName)
        {
            TypeName = typeName;
            {
                var parts = TypeName.Split('+');
                var f     = parts.First().Split('.');
                var l     = parts.Last().Split('.');

                RelativeNamespace = string.Join(".", f.SkipLast(1));
                ShortFileName     = l.Last() + ".auto.cs";
            }
            {
                var parts = TypeName.Split('+');
                var n     = parts.Last();
                parts    = n.Split('.');
                EnumName = parts.Last();
            }

            OptionsContainerClassName = EnumName + "Options";
        }

        public static implicit operator EnumsGeneratorItemNames(string typeName)
        {
            return new EnumsGeneratorItemNames(typeName);
        }
        
        
        public string OptionsContainerClassName { get; set; }

        public string EnumName { get; set; }

        public string TypeName { get; set; }

        public string ShortFileName { get; set; }

        public string RelativeNamespace { get; set; }


        public string[] OwnerClasses
        {
            get
            {
                var parts = TypeName.Split('+');
                var result = parts.Take(parts.Length - 1)
                    .Select(a =>
                    {
                        var q = a.Split('.');
                        return q.Last();
                    }).ToArray();
                return result;
            }
        }
    }
}