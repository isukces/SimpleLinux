namespace iSukces.SimpleLinux
{
    public abstract class LinuxCommand
    {
        public abstract string GetCode();

        public override string ToString()
        {
            return GetCode();
        }

        public bool Sudo { get; set; }

        public LinuxStream Output { get; set; }
    }
}