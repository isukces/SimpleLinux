using iSukces.Code;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal interface ISingleTaskEnumsGeneratorContext
    {
        CsNamespace GetOrCreateNamespace(string itemNamespace);
    }
}