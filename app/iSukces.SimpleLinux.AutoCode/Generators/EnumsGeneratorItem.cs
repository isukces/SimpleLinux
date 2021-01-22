﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux.AutoCode.Generators
{
    public class EnumsGeneratorItem
    {
        public FileInfo GetFileName(DirectoryInfo projectDir)
        {
            var parts = TypeName.Split('+');
            var f     = parts.First().Split('.');
            var l     = parts.Last().Split('.');

            var inp = new FilePathBuilderInput
            {
                ProjectBaseDir    = projectDir,
                RelativeNamespace = string.Join(".", f.SkipLast(1)),
                ShortFileName     = l.Last() + ".auto.cs"
            };
            var maker = FilenameMaker ?? DefaultFilenameMaker.Instance;
            return maker.GetFileName(inp);
        }

        public EnumsGeneratorItem WithConflict(string option1, string option2)
        {
            Options.AddConflict(option1, option2);
            return this;
        }


        public EnumsGeneratorItem WithInterface<T>()
        {
            ImplementedInterfaces.Add(typeof(T));
            return this;
        }

        public string            TypeName       { get; set; }
        public OptionsCollection Options        { get; set; }
        public Assembly          TargetAssembly { get; set; }

        public string Namespace
        {
            get
            {
                var assemblyName = TargetAssembly.GetName().Name;
                var parts        = TypeName.Split('+');
                var dotIndex     = parts[0].LastIndexOf('.');
                if (dotIndex < 0)
                    return assemblyName;
                return assemblyName + "." + parts[0].Substring(0, dotIndex);
            }
        }

        public string[] OwnerClasses
        {
            get
            {
                var parts = TypeName.Split('+');
                var result = parts.Take(parts.Length - 1)
                    .Select(a =>
                    {
                        var q = a.Split('.');
                        return q.Last();
                    }).ToArray();
                return result;
            }
        }

        public string EnumName
        {
            get
            {
                var parts = TypeName.Split('+');
                var n     = parts.Last();
                parts = n.Split('.');
                return parts.Last();
            }
        }


        [NotNull]
        public IList<Type> ImplementedInterfaces { get; } = new List<Type>();

        public IFilenameMaker FilenameMaker { get; set; }

        public EnumsGeneratorItem WithInteger(string option)
        {
            var el = Options.GetByOption(option);
            el.Parameter     = el.Parameter.WithEncoder(OptionValueProcessor.Integer);
            return this;
        }
    }
}