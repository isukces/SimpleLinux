using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    partial class ParametrizedOption
    {
        public class OptionValueProcessorInput
        {
            public OptionValueProcessorInput(string expression,
                OptionValueProcessorKind kind,
                ITypeNameResolver resolver)
            {
                Expression = expression;
                Kind       = kind;
                Resolver   = resolver;
            }

            public string                   Expression { get; }
            public OptionValueProcessorKind Kind       { get; }
            public ITypeNameResolver        Resolver   { get; }
        }
    }
}