namespace iSukces.SimpleLinux.AutoCode.Generators
{
    internal class CodeVariable
    {
        public CodeVariable(string name)
        {
            Name = name;
        }

        public string GetCodeAndMarkAsDeclared()
        {
            var code = string.Format("{0}{1} = {2};",
                WasDeclared ? "" : "var ",
                Name,
                Expression);
            WasDeclared = true;
            return code;
        }

        public string Name        { get; }
        public string Expression  { get; set; }
        public bool   WasDeclared { get; set; }
    }
}