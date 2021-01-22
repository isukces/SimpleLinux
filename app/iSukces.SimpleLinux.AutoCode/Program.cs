using System;
using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal class Program
    {
        private static EnumsGenerator GetEnumsGenerator()
        {
            var enumsGenerator = new EnumsGenerator(SimpleLinuxAutocodeGenerator.GetDirectoryProvider())
                .WithTargetAssembly<Sha1Code>();

            DockerComposeSetup.Add(enumsGenerator);
            return enumsGenerator;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Create autocode");

            var gen = new SimpleLinuxAutocodeGenerator();
            gen.WithGenerator(GetEnumsGenerator());
            gen.Build();
        }
    }
}