namespace iSukces.SimpleLinux
{
    public struct LinuxStream
    {
        public LinuxStream(string name, bool append = false)
        {
            Name = name?.Trim();
            if (Name == string.Empty)
                Name = null;
            if (string.IsNullOrEmpty(Name))
                append = false;
            Append = append;
        }

        public string WithOperator(string create, string append)
        {
            return IsEmpty ? string.Empty : $"{(Append ? append : create)} {Name}";
        }

        public static LinuxStream DevNull => new LinuxStream("/dev/null");

        public bool   Append  { get; }
        public string Name    { get; }
        public bool   IsEmpty => string.IsNullOrEmpty(Name);
    }
}