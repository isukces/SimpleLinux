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

            var item = enumsGenerator
                .WithEnum("Unzip", null);
            item.Options = new OptionsCollection
            {
                Values =
                {
                    new OptionsCollectionValue
                    {
                        AnyWithMinus = "-x",
                        Description  = "An optional list of archive members to be excluded from processing.",
                        Parameter = new ParametrizedOptionBuilder
                            {
                                Value        = "excludeList",
                                PropertyName = "Exclude",
                                ValueDescription = "Items to exclude",
                                Encoder = ParametrizedOption.ValueEncoder.StringEncoder,
                                IsCollection = true
                            }
                            .Build()
                    } 
                }
            };
            CommonSetup(item);
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\{2}");
        }
    }
}