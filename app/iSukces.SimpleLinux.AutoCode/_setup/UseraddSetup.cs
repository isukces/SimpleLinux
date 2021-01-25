using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class UseraddSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_Curl(enumsGenerator);
        }

        private static void Add_Curl(EnumsGenerator enumsGenerator)
        {
            /*
             * SOURCE https://linux.die.net/man/8/useradd
                        useradd [options] LOGIN
                        useradd -D
                        useradd -D [options]
             */
            const string desc1 = @"

-b/--base-dir <BASE_DIR>
BASE_DIR is concatenated with the account name to define the home directory. 

-c/ --comment <COMMENT>
Any text string.

-d/ --home <HOME_DIR>
The new user will be created using HOME_DIR as the value for the user's login directory.

-g/ --gid <GROUP>
The group name or number of the user's initial login group. The group name must exist.


-K/ --key <KEY=VALUE>
Overrides /etc/login.defs defaults (UID_MIN, UID_MAX, UMASK, PASS_MAX_DAYS and others)

-l/ --no-log-init
Do not add the user to the lastlog and faillog databases.

-m/ --create-home
Create the user's home directory if it does not exist.

-M/ $Do-not-create-home-directory
Do not create the user's home directory, even if the system wide setting from /etc/login.defs (CREATE_HOME) is set to yes.


-N/ --no-user-group
Do not create a group with the same name as the user, but add the user to the group specified by the -g option or by the GROUP variable in /etc/default/useradd.

 
-o/ --non-unique
Allow the creation of a user account with a duplicate (non-unique) UID.

-p/ --password <PASSWORD>
The encrypted password, as returned by crypt(3). The default is to disable the password.

-r/ --system
Create a system account. 

-s/ --shell <SHELL>
The name of the user's login shell. The default is to leave this field blank, which causes the system to select the default login shell specified by the SHELL variable in /etc/default/useradd, or an empty string by default.

-u/ --uid <UID>
The numerical value of the user's ID. This value must be unique, unless the -o option is used. The value must be non-negative. The default is to use the smallest ID value greater than 999 and greater than every other user. Values between 0 and 999 are typically reserved for system accounts.

-U/ --user-group
Create a group with the same name as the user, and add the user to this group.
The default behavior (if the -g, -N, and -U options are not specified) is defined by the USERGROUPS_ENAB variable in /etc/login.defs.

-Z/ --selinux-user <SEUSER>
The SELinux user for the user's login. The default is to leave this field blank, which causes the system to select the default SELinux user.
";

            var item = enumsGenerator
                .WithEnum("UserAdd", desc1, ParserKind.Style1)
                .WithStringValue("-b", "base dir")
                .WithStringValue("-c", "comment")
                
                .WithStringValue("-d", "home directory")
                .WithStringValue("-g", "group")
                
                .WithStringValue("-K", "value")
                .WithStringValue("-p", "password")
                
                .WithConflict("-m", "-M")
                ;
               

            item.Names.OptionsContainerClassName = nameof(UserAddCommand);
            CommonSetup(item);
            
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            // OnelineLinuxCommand
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\{2}");
        }
    }
}