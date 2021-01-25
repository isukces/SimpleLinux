using System;
using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal class Program
    {
        private static EnumsGenerator GetEnumsGenerator()
        {
            var enumsGenerator = new EnumsGenerator(AllGenerators.GetDirectoryProvider())
                .WithTargetAssembly<Sha1Code>();

            UseraddSetup.Add(enumsGenerator);
            TarSetup.Add(enumsGenerator);
            CurlSetup.Add(enumsGenerator);
            UnzipSetup.Add(enumsGenerator);
            DockerComposeSetup.Add(enumsGenerator);
            return enumsGenerator;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Create autocode");

            var gen = new AllGenerators();
            gen.WithGenerator<StringPropertyGenerator>()
                .WithGenerator(GetEnumsGenerator())
                .WithGenerator<Code.AutoCode.Generators.BuilderForTypeGenerator>();
            gen.Build();
            
        }
    }
}