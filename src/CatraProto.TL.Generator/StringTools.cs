using System.Text;
using CatraProto.TL.Generator.Settings.Objects;

namespace CatraProto.TL.Generator
{
    internal static class StringTools
    {
        public const string OneTabs = "\t";
        public const string TwoTabs = "\t\t";
        public const string ThreeTabs = "\t\t\t";
        public const string FourTabs = "\t\t\t\t";
        public const string FiveTabs = "\t\t\t\t\t";

        static StringTools()
        {
            SplitValues = new Character[3];
            SplitValues[0] = new Character {Char = ' ', Delete = true};
            SplitValues[1] = new Character {Char = '_', Delete = true};
            SplitValues[2] = new Character {Char = '.', Delete = false};
        }

        public static Character[] SplitValues { get; set; }

        public static string PascalCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;

            var stringBuilder = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var ch = name[i];
                var skip = false;

                if (i == 0) ch = NameUppercase(ch.ToString()).ToCharArray()[0];
                foreach (var value in SplitValues)
                    if (i + 1 <= name.Length)
                        if (value.Char == ch)
                        {
                            if (!value.Delete) stringBuilder.Append(ch);
                            i++;
                            stringBuilder.Append(name[i].ToString().ToUpper());
                            skip = true;
                        }

                if (skip) continue;
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        public static string NameUppercase(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;

            var firstLetter = name[0].ToString().ToUpper();

            if (name.Length >= 1)
                return firstLetter + name.Substring(1);
            return firstLetter;
        }

        public static bool IsStringLower(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (!char.IsLetter(ch)) continue;
                if (!char.IsLower(ch)) return false;
            }

            return true;
        }

        public static string NamespaceToDirectory(string ns)
        {
            return ns.Replace(".", "/");
        }
    }
}