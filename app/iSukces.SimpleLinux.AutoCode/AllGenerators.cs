using System.Collections.Generic;
using System.Reflection;
using iSukces.Code;
using iSukces.Code.AutoCode;

namespace iSukces.SimpleLinux.AutoCode
{
    /// <summary>
    ///     Aggregating generator
    /// </summary>
    internal class AllGenerators : AutoCodeGenerator
    {
        public AllGenerators() : base(GetFilenameProvider())
        {
        }


        /// <summary>
        ///     Dostarcza providera, który decyduje gdzie zapisywać generowane pliki kody.
        ///     Główny katalog jest znajdowany na podstawie położenia pliku ratmon.sln
        /// </summary>
        /// <returns></returns>
        public static IAssemblyBaseDirectoryProvider GetDirectoryProvider()
        {
            return SlnAssemblyBaseDirectoryProvider.Make<AllGenerators>("SimpleLinux.sln");
        }


        /// <summary>
        ///     Dostarcza providera nazw plików dla kodu
        /// </summary>
        /// <returns></returns>
        private static IAssemblyFilenameProvider GetFilenameProvider()
        {
            var dirProvider = GetDirectoryProvider();
            var prov2       = new SimpleAssemblyFilenameProvider(dirProvider, "-AutoCode-.cs");
            return prov2;
        }

        public static IEnumerable<string> GetFileImportNamespaces()
        {
            yield return "System";
            yield return "System.Collections.Generic";
            yield return "iSukces.SimpleLinux";
            yield return "System.Runtime.CompilerServices";
            yield return "System.Globalization";

        }
        public void Build()
        {
            // var dirProvider = GetDirectoryProvider();
            foreach(var i in GetFileImportNamespaces())
            FileNamespaces.Add(i);
            BeforeSave += (a, eventArgs) =>
            {
                // dodaje nagłówek dla każdego z plików
                eventArgs.File.BeginContent = "#pragma warning disable 1591";
            };
            Assemblies = new[]
            {
                typeof(Sha1Code).Assembly,
                typeof(AllGenerators).Assembly
            };

            foreach (var i in Assemblies)
                Make(i);
            /*
            if (AnyFileSaved)
                throw new RecompileException();
        */
        }

        protected Assembly[] Assemblies { get; private set; }
    }
}