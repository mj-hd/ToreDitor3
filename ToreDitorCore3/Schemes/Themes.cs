using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using HyperTomlProcessor;

namespace ToreDitorCore.Schemes
{
    public class Themes : Dictionary<string, Theme>
    {
        public Themes()
        {
        }

        public void Add(Theme theme)
        {
            if (this.ContainsKey(theme.Name))
            {
                throw new Exception("既に同じ名前のテーマが登録されています。");
            }

            this.Add(theme.Name, theme);
        }

        public void ImportFromDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            foreach (var file in Directory.EnumerateFiles(path))
            {
                var theme = new Theme(file);
                this.Add(theme);
            }
        }
    }

    public class Theme
    {
        public Theme()
        {
            string[] defaultStyles = {
                "Cursor", "Select", "CursorLine", "CursorColumn",
                "LineNumber", "MatchParen", "Search", "Directory",
                "Folded", "SignColumn", "Default", "Boolean", "Character",
                "Comment", "Conditional", "Constant", "Define", "ErrorMsg",
                "WarningMsg", "Float", "Function", "Identifier", "Keyword",
                "Label", "NonText", "Number", "Operator", "PreProc", "Special",
                "SpecialKey", "Statement", "StorageClass", "String", "Tag",
                "Title", "Underlined"
            };

            for (var i = 0; i < 2; i++)
            {
                this.Style.Add(new Dictionary<string, Syntax.Directive>());
                foreach (var style in defaultStyles)
                {
                    this.Style[i][style] = new Syntax.Directive("color:#000000;background-color:#ffffff;");
                }
            }
        }
        public Theme(string file)
            : this()
        {
            this.Import(file);
        }

        public void Import(string file)
        {
            dynamic toml;
            using (var sr = new StreamReader(file))
            {
                toml = DynamicToml.Parse(Toml.V04, sr);
            }

            if (!toml.IsDefined("title"))
            {
                throw new Exception("titleが指定されていません。");
            }
            this.Name = toml.title;

            if (toml.IsDefined("author"))
            {
                this.Author = toml.author;
            }

            if (toml.IsDefined("version"))
            {
                this.Version = new Version(toml.version);
            }

            if (toml.IsDefined("website"))
            {
                this.Website = toml.website;
            }

            this.Style[ThemeSide.Light].Clear();
            this.Style[ThemeSide.Dark].Clear();

            if (!(toml.IsDefined("light-bg-style") && toml.IsDefined("dark-bg-style")))
            {
                throw new Exception("light-bg-styleかdark-bg-styleが不足しています。");
            }

            foreach (KeyValuePair<string, object> style in toml["light-bg-style"])
            {
                this.Style[ThemeSide.Light][style.Key] = new Syntax.Directive(style.Value.ToString());
            }

            foreach (KeyValuePair<string, object> style in toml["dark-bg-style"])
            {
                this.Style[ThemeSide.Dark][style.Key] = new Syntax.Directive(style.Value.ToString());
            }
        }

        public void Export(string file)
        {
            var toml = DynamicToml.CreateTable();
            toml.Add(this);

            using (var sw = new StreamWriter(file, false, Encoding.Unicode))
            {
                toml.WriteTo(Toml.V04, sw);
            }
        }

        public string Name;
        public string Author;
        public Version Version;
        public string Website;
        public List<Dictionary<string, Syntax.Directive>> Style = new List<Dictionary<string, Syntax.Directive>>();

        public static class ThemeSide {
            public const int Light = 0;
            public const int Dark = 1;
            public static int FromString(string side)
            {
                switch (side)
                {
                    case "light":
                        return Light;
                    case "dark":
                        return Dark;
                }
                return Light;
            }
            public static string ToString(int side)
            {
                return side.ToString();
            }
        }
    }
}
