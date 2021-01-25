using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class TarSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_Curl(enumsGenerator);
        }

        private static void Add_Curl(EnumsGenerator enumsGenerator)
        {
            // SOURCE https://man7.org/linux/man-pages/man1/tar.1.html
            const string desc1 = @"
-f  <tar-archive> / $archive-file-name
Archive

-z/ --gzip
    Filter the archive through gzip(1).

-Z/ --compress
    Filter the archive through compress(1).

-v / $Verbose
Verbose

";

            var item = enumsGenerator
                .WithEnum("Tar", desc1, ParserKind.Style1)
                .WithStringValue("-f", "")
                .WithConflict("--gzip", "--compress");
               

            item.Names.OptionsContainerClassName = nameof(TarCommand);
            CommonSetup(item);
            
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            // OnelineLinuxCommand
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\{2}");
        }
    }
}