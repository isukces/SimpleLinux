using JetBrains.Annotations;

namespace iSukces.SimpleLinux
{
    public interface IFileContentSource : IShaSource
    {
        [CanBeNull]
        byte[] GetBytes();
    }
}