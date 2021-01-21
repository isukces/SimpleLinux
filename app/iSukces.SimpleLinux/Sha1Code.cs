using System;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux
{
    public struct Sha1Code : IEquatable<Sha1Code>
    {
        public Sha1Code(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0)
                _base64 = null;
            else
                _base64 = Convert.ToBase64String(bytes);
        }

        public static Sha1Code Compute(byte[] bytes)
        {
            var result = new SHA1Managed().ComputeHash(bytes ?? new byte[0]);
            return new Sha1Code(result);
        }

        public static Sha1Code Compute(string text, Encoding encoding = null)
        {
            if (encoding is null)
                encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(text ?? string.Empty);
            return Compute(bytes);
        }

        public static bool operator ==(Sha1Code left, Sha1Code right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Sha1Code left, Sha1Code right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Sha1Code other)
        {
            return Base64 == other.Base64;
        }

        public override bool Equals(object obj)
        {
            return obj is Sha1Code other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Base64.GetHashCode();
        }

        public override string ToString()
        {
            return Base64;
        }

        [NotNull]
        public string Base64
        {
            get { return _base64 ?? string.Empty; }
        }

        private readonly string _base64;
    }
}