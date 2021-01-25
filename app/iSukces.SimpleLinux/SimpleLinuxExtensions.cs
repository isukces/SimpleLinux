using System.Text;

namespace iSukces.SimpleLinux
{
    public static class SimpleLinuxExtensions
    {
        public static Sha1Code CreateSha1(this string text, Encoding encoding = null)
        {
            return Sha1Code.Compute(text, encoding);
        }

        public static Sha1Code CreateSha1(this byte[] bytes)
        {
            return Sha1Code.Compute(bytes);
        }

        public static string ShellQuote(this string x)
        {
            if (string.IsNullOrEmpty(x))
                return string.Empty;
            const string forbidden = " '><$&~`";
            var          sb        = new StringBuilder();
            bool         needQuote = false;
            foreach (var u in x)
            {
                if (u == '\"')
                {
                    needQuote = true;
                    sb.Append("\\\"");
                    continue;
                }
                
                if (!needQuote)
                    if (forbidden.IndexOf(u) >= 0)
                        needQuote = true;
                
                sb.Append(u);
                
            }
            
            x = sb.ToString();
            if (needQuote)
                return "\"" + x + "\"";
            return x;
        }

    }
}