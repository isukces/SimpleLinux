using System;
using System.Linq;

namespace iSukces.SimpleLinux
{
    public abstract class LinuxFileBase
    {
        protected LinuxFileBase(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException(nameof(fullName));
            FullName = fullName.Replace('\\', '/');
        }

        protected static string Concat1(string x, string y)
        {
            while (true)
            {
                x = x.TrimEnd('/');
                if (x.EndsWith("/."))
                {
                    x = x.Substring(0, x.Length - 2);
                    continue;
                }

                if (x.EndsWith("/.."))
                    throw new NotImplementedException();

                break;
            }

            /*if (y.StartsWith("../"))
            {
                throw new NotImplementedException();
            }

            if (y.StartsWith("./"))
                y = y.Substring(2);*/
            var result     =  x + "/" + y;
            var isAbsolute = x.StartsWith("/");
            if (isAbsolute)
                result = result.Substring(1);
            var parts      = result.Split('/').ToList();
            for (var index = 0; index < parts.Count; index++)
            {
                var p = parts[index];
                if (p == ".")
                {
                    var canRemove = isAbsolute || index > 0;
                    if (canRemove)
                    {
                        parts.RemoveAt(index);
                        index--;
                    }

                    continue;
                }
                if (p != "..") continue;
                if (index == 0)
                    throw new Exception("");
                parts.RemoveAt(index);
                parts.RemoveAt(index-1);
                index--;
            }

            result = string.Join("/", parts);
            if (isAbsolute)
                return "/" + result;
            return result;
        }

        public void CheckAbsolute(string variableName)
        {
            if (IsAbsolute)
                return;
            throw new ShouldHaveAbsolutePathException(FullName, variableName + " should have absolute path");
        }


        public override string ToString()
        {
            return FullName;
        }

        public string FullName { get; }

        public bool IsAbsolute
        {
            get { return FullName.StartsWith("/"); }
        }


        public LinuxDir Dir
        {
            get { return LinuxDir.Make(DirName); }
        }

        public string DirName
        {
            get
            {
                var i = FullName.LastIndexOf('/');
                if (i < 1)
                    return "";
                return FullName.Substring(0, i);
            }
        }

        public string ShortName
        {
            get { return FullName.Split('/').Last(); }
        }

        public string MakeAbsolutePwd()
        {
            var n = FullName;
            if (this.IsAbsolute)
                return n;
            if (n.StartsWith("./"))
                return "`pwd`" + n.Substring(1);
            throw new NotSupportedException();
        }
    }
}