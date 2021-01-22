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
        


    }
}