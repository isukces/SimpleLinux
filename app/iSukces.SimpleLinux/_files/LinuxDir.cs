namespace iSukces.SimpleLinux
{
    public sealed class LinuxDir : LinuxFileBase
    {
        public LinuxDir(string fullName) : base(fullName.TrimEnd('/'))
        {
        }

        public static LinuxDir Make(string name)
        {
            name = name?.Trim();
            return string.IsNullOrEmpty(name) ? null : new LinuxDir(name);
        }


        public static LinuxDir operator +(LinuxDir a, LinuxDir b)
        {
            if (a is null)
                return b;
            if (b is null)
                return a;
            if (b.IsAbsolute)
                return b;
            return new LinuxDir(Concat1(a.FullName, b.FullName));
        }

        public static implicit operator LinuxDir(string name)
        {
            return new LinuxDir(name);
        }

        public LinuxDir AppendDir(string dirName)
        {
            if (string.IsNullOrEmpty(dirName))
                return this;
            return this + new LinuxDir(dirName);
        }

        public LinuxFile MakeFile(string shortName)
        {
            return this + new LinuxFile(shortName);
        }

        public static LinuxDir CurrentDir => new LinuxDir("./");
    }
}