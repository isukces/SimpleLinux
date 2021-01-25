// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux
{
    public partial class UserAddCommand
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -l, --no-log-init: Do not add the user to the lastlog and faillog databases.
            if ((Flags & UserAddFlags.NoLogInit) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--no-log-init" : "-l";
            // -m, --create-home: Create the user's home directory if it does not exist.
            if ((Flags & UserAddFlags.CreateHome) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--create-home" : "-m";
            // -M: Do not create the user's home directory, even if the system wide setting from /etc/login.defs (CREATE_HOME) is set to yes.
            if ((Flags & UserAddFlags.DoNotCreateHomeDirectory) != 0)
                yield return "-M";
            // -N, --no-user-group: Do not create a group with the same name as the user, but add the user to the group specified by the -g option or by the GROUP variable in /etc/default/useradd.
            if ((Flags & UserAddFlags.NoUserGroup) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--no-user-group" : "-N";
            // -o, --non-unique: Allow the creation of a user account with a duplicate (non-unique) UID.
            if ((Flags & UserAddFlags.NonUnique) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--non-unique" : "-o";
            // -r, --system: Create a system account.
            if ((Flags & UserAddFlags.System) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--system" : "-r";
            // -U, --user-group: Create a group with the same name as the user, and add the user to this group. The default behavior (if the -g, -N, and -U options are not specified) is defined by the USERGROUPS_ENAB variable in /etc/login.defs.
            if ((Flags & UserAddFlags.UserGroup) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--user-group" : "-U";
            // -b, --base-dir =BASE_DIR: BASE_DIR is concatenated with the account name to define the home directory.
            if (!string.IsNullOrEmpty(BaseDir))
            {
                yield return "--base-dir";
                yield return BaseDir.ShellQuote();
            }
            // -c, --comment =COMMENT: Any text string.
            if (!string.IsNullOrEmpty(Comment))
            {
                yield return "--comment";
                yield return Comment.ShellQuote();
            }
            // -d, --home =HOME_DIR: The new user will be created using HOME_DIR as the value for the user's login directory.
            if (!string.IsNullOrEmpty(Home))
            {
                yield return "--home";
                yield return Home.ShellQuote();
            }
            // -g, --gid =GROUP: The group name or number of the user's initial login group. The group name must exist.
            if (!string.IsNullOrEmpty(Gid))
            {
                yield return "--gid";
                yield return Gid.ShellQuote();
            }
            // -K, --key KEY=VALUE: Overrides /etc/login.defs defaults (UID_MIN, UID_MAX, UMASK, PASS_MAX_DAYS and others)
            foreach(var pair in Key)
            {
                yield return "--key";
                var value = pair.Value.ShellQuote();
                yield return $"{pair.Key}={value}";
            }
            // -p, --password =PASSWORD: The encrypted password, as returned by crypt(3). The default is to disable the password.
            if (!string.IsNullOrEmpty(Password))
            {
                yield return "--password";
                yield return Password.ShellQuote();
            }
        }

        /// <summary>
        /// -b, --base-dir =BASE_DIR: BASE_DIR is concatenated with the account name to define the home directory.
        /// </summary>
        /// <param name="baseDir">base dir</param>
        public UserAddCommand WithBaseDir(string baseDir)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            BaseDir = baseDir;
            return this;
        }

        /// <summary>
        /// -c, --comment =COMMENT: Any text string.
        /// </summary>
        /// <param name="comment">comment</param>
        public UserAddCommand WithComment(string comment)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Comment = comment;
            return this;
        }

        /// <summary>
        /// -m, --create-home: Create the user's home directory if it does not exist.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithCreateHome(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.CreateHome, value);
            return this;
        }

        /// <summary>
        /// -M: Do not create the user's home directory, even if the system wide setting from /etc/login.defs (CREATE_HOME) is set to yes.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithDoNotCreateHomeDirectory(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.DoNotCreateHomeDirectory, value);
            return this;
        }

        /// <summary>
        /// -g, --gid =GROUP: The group name or number of the user's initial login group. The group name must exist.
        /// </summary>
        /// <param name="group">group</param>
        public UserAddCommand WithGid(string group)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Gid = group;
            return this;
        }

        /// <summary>
        /// -d, --home =HOME_DIR: The new user will be created using HOME_DIR as the value for the user's login directory.
        /// </summary>
        /// <param name="homeDir">home directory</param>
        public UserAddCommand WithHome(string homeDir)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Home = homeDir;
            return this;
        }

        /// <summary>
        /// -K, --key KEY=VALUE: Overrides /etc/login.defs defaults (UID_MIN, UID_MAX, UMASK, PASS_MAX_DAYS and others)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value">value</param>
        public UserAddCommand WithKey(string key, string value)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Key[key] = value;
            return this;
        }

        /// <summary>
        /// -l, --no-log-init: Do not add the user to the lastlog and faillog databases.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithNoLogInit(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.NoLogInit, value);
            return this;
        }

        /// <summary>
        /// -o, --non-unique: Allow the creation of a user account with a duplicate (non-unique) UID.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithNonUnique(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.NonUnique, value);
            return this;
        }

        /// <summary>
        /// -N, --no-user-group: Do not create a group with the same name as the user, but add the user to the group specified by the -g option or by the GROUP variable in /etc/default/useradd.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithNoUserGroup(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.NoUserGroup, value);
            return this;
        }

        /// <summary>
        /// -p, --password =PASSWORD: The encrypted password, as returned by crypt(3). The default is to disable the password.
        /// </summary>
        /// <param name="password">password</param>
        public UserAddCommand WithPassword(string password)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Password = password;
            return this;
        }

        /// <summary>
        /// -r, --system: Create a system account.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithSystem(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.System, value);
            return this;
        }

        /// <summary>
        /// -U, --user-group: Create a group with the same name as the user, and add the user to this group. The default behavior (if the -g, -N, and -U options are not specified) is defined by the USERGROUPS_ENAB variable in /etc/login.defs.
        /// </summary>
        /// <param name="value"></param>
        public UserAddCommand WithUserGroup(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(UserAddFlags.UserGroup, value);
            return this;
        }

        public UserAddFlags Flags { get; set; }

        /// <summary>
        /// -b, --base-dir =BASE_DIR: BASE_DIR is concatenated with the account name to define the home directory.
        /// </summary>
        public string BaseDir { get; set; }

        /// <summary>
        /// -c, --comment =COMMENT: Any text string.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// -d, --home =HOME_DIR: The new user will be created using HOME_DIR as the value for the user's login directory.
        /// </summary>
        public string Home { get; set; }

        /// <summary>
        /// -g, --gid =GROUP: The group name or number of the user's initial login group. The group name must exist.
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// -K, --key KEY=VALUE: Overrides /etc/login.defs defaults (UID_MIN, UID_MAX, UMASK, PASS_MAX_DAYS and others)
        /// </summary>
        public IDictionary<string, string> Key { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// -p, --password =PASSWORD: The encrypted password, as returned by crypt(3). The default is to disable the password.
        /// </summary>
        public string Password { get; set; }

    }

    public static partial class UserAddExtensions
    {
        public static void CheckConflicts(this UserAddFlags value)
        {
            var flagsFilter = UserAddFlags.DoNotCreateHomeDirectory | UserAddFlags.CreateHome;
            if ((value & flagsFilter) == flagsFilter)
                throw new Exception("options -M and --create-home can't be used together");
        }

        public static IEnumerable<string> OptionsToString(this UserAddFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            CheckConflicts(value);
            // -l, --no-log-init: Do not add the user to the lastlog and faillog databases.
            if ((value & UserAddFlags.NoLogInit) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--no-log-init" : "-l";
            // -m, --create-home: Create the user's home directory if it does not exist.
            if ((value & UserAddFlags.CreateHome) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--create-home" : "-m";
            // -M: Do not create the user's home directory, even if the system wide setting from /etc/login.defs (CREATE_HOME) is set to yes.
            if ((value & UserAddFlags.DoNotCreateHomeDirectory) != 0)
                yield return "-M";
            // -N, --no-user-group: Do not create a group with the same name as the user, but add the user to the group specified by the -g option or by the GROUP variable in /etc/default/useradd.
            if ((value & UserAddFlags.NoUserGroup) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--no-user-group" : "-N";
            // -o, --non-unique: Allow the creation of a user account with a duplicate (non-unique) UID.
            if ((value & UserAddFlags.NonUnique) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--non-unique" : "-o";
            // -r, --system: Create a system account.
            if ((value & UserAddFlags.System) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--system" : "-r";
            // -U, --user-group: Create a group with the same name as the user, and add the user to this group. The default behavior (if the -g, -N, and -U options are not specified) is defined by the USERGROUPS_ENAB variable in /etc/login.defs.
            if ((value & UserAddFlags.UserGroup) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--user-group" : "-U";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UserAddFlags SetOrClear(this UserAddFlags current, UserAddFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

    }

    [Flags]
    public enum UserAddFlags: byte
    {
        None = 0,
        /// <summary>
        /// -l, --no-log-init: Do not add the user to the lastlog and faillog databases.
        /// </summary>
        NoLogInit = 1,
        /// <summary>
        /// -m, --create-home: Create the user's home directory if it does not exist.
        /// </summary>
        CreateHome = 2,
        /// <summary>
        /// -M: Do not create the user's home directory, even if the system wide setting from /etc/login.defs (CREATE_HOME) is set to yes.
        /// </summary>
        DoNotCreateHomeDirectory = 4,
        /// <summary>
        /// -N, --no-user-group: Do not create a group with the same name as the user, but add the user to the group specified by the -g option or by the GROUP variable in /etc/default/useradd.
        /// </summary>
        NoUserGroup = 8,
        /// <summary>
        /// -o, --non-unique: Allow the creation of a user account with a duplicate (non-unique) UID.
        /// </summary>
        NonUnique = 16,
        /// <summary>
        /// -r, --system: Create a system account.
        /// </summary>
        System = 32,
        /// <summary>
        /// -U, --user-group: Create a group with the same name as the user, and add the user to this group. The default behavior (if the -g, -N, and -U options are not specified) is defined by the USERGROUPS_ENAB variable in /etc/login.defs.
        /// </summary>
        UserGroup = 64
    }
}
