using System;
using JetBrains.Annotations;

namespace iSukces.SimpleLinux
{
    public class ShouldHaveAbsolutePathException : Exception
    {
        public ShouldHaveAbsolutePathException(string path, [CanBeNull] string message,
            [CanBeNull] Exception innerException = null)
            : base(message, innerException)
        {
            Path = path;
        }

        public string Path { get; }
    }
}