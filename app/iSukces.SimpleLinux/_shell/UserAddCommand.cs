using System.Collections.Generic;

namespace iSukces.SimpleLinux
{
    public partial class UserAddCommand : OnelineLinuxCommand
    {
        public override IEnumerable<string> GetItems()
        {
            yield return "useradd";
            foreach (var i in GetCodeItems())
                yield return i;
            yield return Login;
        }

        public UserAddCommand WithLogin(string login)
        {
            Login = login;
            return this;
        }

        public string Login { get; set; }
    }
}