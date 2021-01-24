using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class UnzipSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_Unzip(enumsGenerator);
        }


        private static void Add_Unzip(EnumsGenerator enumsGenerator)
        {
            // https://linux.die.net/man/1/unzip
            // unzip [-Z] [-cflptTuvz[abjnoqsCDKLMUVWX$/:^]] file[.zip] [file(s) ...] [-x xfile(s) ...] [-d exdir]
            const string desc = @"
-x exclude            An optional list of archive members to be excluded from processing.
-d $output-directory  An optional directory to which to extract files.
-o, $overwrite        Overwrite existing files without prompting.
"; 
            var item = enumsGenerator
                .WithEnum("Unzip", desc);
            item.WithStringValue("-d", "Output directory");
            item.WithStringValue("-x", "Items to exclude", true);
            CommonSetup(item);
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\{2}");
        }
    }
}