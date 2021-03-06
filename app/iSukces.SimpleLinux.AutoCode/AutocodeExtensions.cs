﻿using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class AutocodeExtensions
    {
        public static void AddAggressiveInlining(this ICsClassMember csMethod, ITypeNameResolver cl)
        {
            var atr = CsAttribute.Make<MethodImplAttribute>(cl)
                .WithArgumentCode(cl.GetTypeName<MethodImplOptions>() + "." + MethodImplOptions.AggressiveInlining);
            csMethod.Attributes.Add(atr);
        }

        public static string AppendText(this string xTrimmed, string yTrimmed, string separator = " ")
        {
            if (string.IsNullOrEmpty(yTrimmed))
                return xTrimmed;
            if (string.IsNullOrEmpty(xTrimmed))
                return yTrimmed;
            return xTrimmed + separator + yTrimmed;
        }

        public static string Camelise(this string x, bool forceToLower = false)
        {
            var upper = true;
            var sb    = new StringBuilder(x.Length);
            foreach (var i in x)
            {
                if (i == ' ' || i == '-' || i == '_')
                {
                    upper = true;
                    continue;
                }

                if (upper)
                    sb.Append(char.ToUpper(i));
                else
                    sb.Append(forceToLower ? char.ToLower(i) : i);
                upper = false;
            }

            return sb.ToString();
        }

        public static string GetTypeName(this ITypeNameResolver res, NamespaceAndName typeName)
        {
            if (res is INamespaceContainer container)
                if (container.IsKnownNamespace(typeName.Namespace))
                    return typeName.Name;
            return typeName.FullName;
        }

        public static string CodeHasElements(this string expression,string countProperty="Count")
        {
            var nn = CodeIsNotNull(expression);
            return $"{nn} && {expression}.{countProperty} > 0";
        }
        
        public static string CodeIsNotNull(this string expression)
        {
            return $"!({expression} is null)";
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            var tmp = first;
            first  = second;
            second = tmp;
        }

        public static string ToInv(this int x)
        {
            return x.ToString(CultureInfo.InvariantCulture);
        }
        
        public static string ToInv(this long x)
        {
            return x.ToString(CultureInfo.InvariantCulture);
        }
        
        public static string ToInv(this ulong x)
        {
            return x.ToString(CultureInfo.InvariantCulture);
        }

        public static void WriteDescriptionComment(this CsCodeWriter writer, OptionsCollectionValue option)
        {
            var description = option.FullDescription;
            if (string.IsNullOrEmpty(description)) return;
            writer.WriteLine("// " + description);
        }

        public static CsCodeWriter SingleLineForeach(this CsCodeWriter cs, string variable, string collection, string statement)
        {
            cs.WriteLine($"foreach (var {variable} in {collection})");
            cs.IncIndent();
            cs.WriteLine(statement);
            cs.DecIndent();
            return cs;
        }
    }
}