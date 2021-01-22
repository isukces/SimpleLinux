using System.Collections.Generic;
using System.Reflection;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.CodeWrite;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    /// <summary>
    ///     Tworzy metody zamiany enumów ładnych na swaggerowe
    /// </summary>
    internal class EnumsGenerator : IAssemblyAutoCodeGenerator
    {
        public EnumsGenerator(IAssemblyBaseDirectoryProvider assemblyBaseDirectoryProvider)
        {
            _assemblyBaseDirectoryProvider = assemblyBaseDirectoryProvider;
        }

        public void AssemblyEnd(Assembly assembly, IAutoCodeGeneratorContext context)
        {
        }

        public void AssemblyStart(Assembly assembly, IAutoCodeGeneratorContext context)
        {
            var projectDir = _assemblyBaseDirectoryProvider.GetBaseDirectory(assembly);

            foreach (var item in ItemsToCreate)
            {
                if (item.TargetAssembly != assembly)
                    continue;
                var csFile = new CsFile();
                foreach (var ns in AllGenerators.GetFileImportNamespaces())
                    csFile.AddImportNamespace(ns);
                var privContext = new MyWrappedContext(csFile);
                SingleTaskEnumsGenerator.CreateCode(privContext, item);
                var fileToSave = item.GetFileName(projectDir);
                if (csFile.SaveIfDifferent(fileToSave.FullName))
                    context.FileSaved(fileToSave);
            }
        }

        public EnumsGenerator WithAssembly(Assembly assembly)
        {
            _currentTargetAssembly = assembly;
            return this;
        }


        public EnumsGeneratorItem WithEnum(string typeName, string s)
        {
            var tmp = new EnumsGeneratorItem
            {
                TypeName       = typeName,
                Options        = OptionsCollection.Parse(s),
                TargetAssembly = _currentTargetAssembly
            };
            ItemsToCreate.Add(tmp);
            return tmp;
        }

        public EnumsGenerator WithTargetAssembly<T>()
        {
            return WithAssembly(typeof(T).Assembly);
        }


        public IList<EnumsGeneratorItem> ItemsToCreate { get; } = new List<EnumsGeneratorItem>();
        private readonly IAssemblyBaseDirectoryProvider _assemblyBaseDirectoryProvider;

        private SingleTaskEnumsGenerator stat;
        private Assembly _currentTargetAssembly;

        private class MyWrappedContext : ISingleTaskEnumsGeneratorContext
        {
            public MyWrappedContext(CsFile file)
            {
                _file = file;
            }


            public CsNamespace GetOrCreateNamespace(string name)
            {
                return _file.GetOrCreateNamespace(name);
            }

            private readonly CsFile _file;
        }
    }
}