using System;

namespace iSukces.SimpleLinux
{
    public interface IFileCreateRequest : IShaSource
    {
        LinuxFile          File          { get; }
        IFileContentSource Content       { get; }
        DateTimeOffset?    LastWriteTime { get; }
    }
}