namespace iSukces.SimpleLinux
{
    public sealed class LinuxFile : LinuxFileBase
    {
        public LinuxFile(string fullName) : base(fullName)
        {
        }

        public static LinuxFile Make(string name)
        {
            name = name?.Trim();
            return string.IsNullOrEmpty(name) ? null : new LinuxFile(name);
        }

        public static LinuxFile operator +(LinuxDir a, LinuxFile b)
        {
            if (a is null)
                return b;
            if (b is null)
                return null;
            if (b.IsAbsolute)
                return b;
            return new LinuxFile(Concat1(a.FullName, b.FullName));
        }

        public static implicit operator LinuxFile(string name)
        {
            return new LinuxFile(name);
        }
    }
}