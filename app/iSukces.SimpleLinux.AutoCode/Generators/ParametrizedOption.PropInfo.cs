using System.Collections.Generic;
using System.Linq;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    partial class ParametrizedOption
    {
        public class PropInfo
        {
            public PropInfo(string propertyType)
            {
                PropertyType = propertyType;
                ElementType  = propertyType;
            }

            public PropInfo MakeDict(ITypeNameResolver resolver)
            {
                var type = resolver.GetTypeName<IDictionary<int, int>>().Split('<').First();
                var init = resolver.GetTypeName<Dictionary<int, int>>().Split('<').First();
                PropertyInit = $"new {init}<string, {ElementType}>()";
                PropertyType = $"{type}<string, {ElementType}>";
                return this;
            }

            public PropInfo MakeList(ITypeNameResolver resolver)
            {
                var type = resolver.GetTypeName<IList<int>>().Split('<').First();
                var init = resolver.GetTypeName<List<int>>().Split('<').First();
                PropertyInit = $"new {init}<{ElementType}>()";
                PropertyType = $"{type}<{ElementType}>";
                return this;
            }

            public string ElementType { get; }

            public string PropertyType { get; set; }

            public string PropertyInit { get; set; }
        }
    }
}