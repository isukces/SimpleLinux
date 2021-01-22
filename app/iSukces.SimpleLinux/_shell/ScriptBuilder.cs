using System;
using System.Text;

namespace iSukces.SimpleLinux
{
    public class ScriptBuilder : IShaSource
    {
        public void Close(string code)
        {
            DecIndent();
            WriteLine(code);
        }

        public byte[] GetContent(Encoding encoding)
        {
            var code = Code;
            if (string.IsNullOrEmpty(code))
                return null;
            if (encoding is null)
                encoding = Encoding.UTF8;
            return encoding.GetBytes(code);
        }

        public virtual string GetContentForSeparateScriptFile()
        {
            return Code;
        }

        public Sha1Code GetSha1()
        {
            return Code.CreateSha1();
        }

        public void WriteLine(string text)
        {
            if (_indentString is null)
            {
                if (Indent > 0)
                    _indentString = new string(' ', Indent * IndentSpaces);
                else
                    _indentString = "";
            }

            CodeBuilder.Append(_indentString);
            CodeBuilder.Append(text);
            CodeBuilder.Append("\n");
        }

        protected void Open(string code)
        {
            WriteLine(code);
            IncIndent();
        }

        private void DecIndent()
        {
            Indent--;
        }

        private void IncIndent()
        {
            Indent++;
        }

        public static int IndentSpaces
        {
            get { return _indentSpaces; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _indentSpaces = value;
            }
        }

        public StringBuilder CodeBuilder { get; } = new StringBuilder();

        public string Code
        {
            // ScriptTarget
            // #!/bin/bash
            get { return CodeBuilder.ToString(); }
        }

        public int Indent
        {
            get { return _indent; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _indentString = null;
                _indent       = value;
            }
        }

        private static int _indentSpaces = 4;
        private int _indent;
        private string _indentString;
    }

    public enum ScriptTarget
    {
        Run,
        ScriptFile
    }
}