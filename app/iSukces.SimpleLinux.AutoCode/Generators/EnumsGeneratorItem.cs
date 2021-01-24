using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using iSukces.Code;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class EnumsGeneratorItem
    {
        public void AddCustomCreator(CustomCreatorDelegate action)
        {
            CustomCreators.Add(action);
        }

        public FileInfo GetFileName(DirectoryInfo projectDir)
        {
            var inp = new FilePathBuilderInput
            {
                ProjectBaseDir    = projectDir,
                RelativeNamespace = Names.RelativeNamespace,
                ShortFileName     = Names.ShortFileName
            };
            var maker = FilenameMaker ?? DefaultFilenameMaker.Instance;
            return maker.GetFileName(inp);
        }

        public EnumsGeneratorItem WithConflict(string option1, string option2)
        {
            Options.AddConflict(option1, option2);
            return this;
        }

        public EnumsGeneratorItem WithEnumValue(string option, string[] enumValues)
        {
            var el = Options.GetByOption(option);
            el.Parameter = el.Parameter.WithEncoder(ParametrizedOption.ValueEncoder.EnumProcessor(enumValues));
            /*
            if (!string.IsNullOrEmpty(valueDescription))
                el.Parameter = el.Parameter.WithValueDescription(valueDescription);
            */
            return this;
        }

        public EnumsGeneratorItem WithIntegerValue(string option, string valueDescription = null)
        {
            var el = Options.GetByOption(option);
            el.Parameter = el.Parameter.WithEncoder(ParametrizedOption.ValueEncoder.IntEncoder);
            if (!string.IsNullOrEmpty(valueDescription))
                el.Parameter = el.Parameter.WithValueDescription(valueDescription);
            return this;
        }


        public EnumsGeneratorItem WithInterface<T>()
        {
            ImplementedInterfaces.Add(typeof(T));
            return this;
        }

        public EnumsGeneratorItem WithStringValue(string option, string valueDescription = null,
            bool isCollection = false)
        {
            var el = Options.GetByOption(option);
            el.Parameter = el.Parameter.WithEncoder(ParametrizedOption.ValueEncoder.StringEncoder);
            if (!string.IsNullOrEmpty(valueDescription))
                el.Parameter = el.Parameter.WithValueDescription(valueDescription);
            el.Parameter.IsCollection = isCollection;
            return this;
        }

        public EnumsGeneratorItemNames               Names      { get; set; }
        public OptionsCollection Options        { get; set; }
        public Assembly          TargetAssembly { get; set; }

        public string Namespace
        {
            get
            {
                var assemblyName      = TargetAssembly.GetName().Name;
                var relativeNamespace = Names.RelativeNamespace;
                if (string.IsNullOrEmpty(relativeNamespace))
                    return assemblyName;
                return assemblyName + "." + relativeNamespace;
            }
        }

        public string[] OwnerClasses => Names.OwnerClasses;


        [NotNull]
        public IList<Type> ImplementedInterfaces { get; } = new List<Type>();

        public IFilenameMaker FilenameMaker { get; set; }

        public List<CustomCreatorDelegate> CustomCreators { get; } = new List<CustomCreatorDelegate>();
        public Dictionary<string, string>  Tags           { get; } = new Dictionary<string, string>();
        public string                      EnumName       => Names.EnumName;
    }

    public delegate void CustomCreatorDelegate(CsClass optionClass);
}