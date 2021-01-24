namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class StringPropertyGenerator: Code.AutoCode.Generators.SingleClassGeneratorMultiple<StringPropertyAttribute>
    {
        protected override void GenerateInternal()
        {
         
            var c = Class;
            foreach (var i in Attributes)
            {
                var prop = c.AddProperty(i.Name, "string");
                prop.OwnSetter             = prop.PropertyFieldName + " = value?.Trim() ?? string.Empty;";
                prop.OwnGetterIsExpression = true;
                prop.ConstValue            = "string.Empty";
            }
        }
    }
}