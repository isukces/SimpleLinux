using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class AutocodeExtensions
    {
        public static string Camelise(this string x)
        {
            var upper = true;
            var sb    = new StringBuilder(x.Length);
            foreach (var i in x)
            {
                if (i == ' ' || i == '-')
                {
                    upper = true;
                    continue;
                }

                if (upper)
                    sb.Append(char.ToUpper(i));
                else
                    sb.Append(i);
                upper = false;
            }

            return sb.ToString();
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
        public static void AddAggressiveInlining(this ICsClassMember csMethod, ITypeNameResolver cl)
        {
            var atr = CsAttribute.Make<MethodImplAttribute>(cl)
                .WithArgumentCode(cl.GetTypeName<MethodImplOptions>() + "." + MethodImplOptions.AggressiveInlining);
            csMethod.Attributes.Add(atr);
        }

        public static string Append(this string xTrimmed, string yTrimmed, string separator = " ")
        {
            if (string.IsNullOrEmpty(yTrimmed))
                return xTrimmed;
            if (string.IsNullOrEmpty(xTrimmed))
                return yTrimmed;
            return xTrimmed + separator + yTrimmed;
        }
    }
}