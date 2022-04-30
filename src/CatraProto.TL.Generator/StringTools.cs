/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Linq;
using System.Text;
using CatraProto.TL.Generator.Settings.Objects;

namespace CatraProto.TL.Generator
{
    static class StringTools
    {
        public const string OneTabs = "\t";
        public const string TwoTabs = "\t\t";
        public const string ThreeTabs = "\t\t\t";
        public const string FourTabs = "\t\t\t\t";
        public const string FiveTabs = "\t\t\t\t\t";
        public static Character[] SplitValues { get; set; }

        private static string[] _bannedKeywords =
        {
            "params",
            "object",
            "private",
            "async",
            "long",
            "int",
            "string"
        };

        static StringTools()
        {
            SplitValues = new Character[3];
            SplitValues[0] = new Character { Char = ' ', Delete = true };
            SplitValues[1] = new Character { Char = '_', Delete = true };
            SplitValues[2] = new Character { Char = '.', Delete = false };
        }

        public static string PascalCase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var ch = name[i];
                var skip = false;

                if (i == 0)
                {
                    ch = NameUppercase(ch.ToString()).ToCharArray()[0];
                }

                foreach (var value in SplitValues)
                {
                    if (i + 1 < name.Length)
                    {
                        if (value.Char == ch)
                        {
                            if (!value.Delete)
                            {
                                stringBuilder.Append(ch);
                            }

                            i++;
                            stringBuilder.Append(name[i].ToString().ToUpper());
                            skip = true;
                        }
                    }
                }

                if (skip)
                {
                    continue;
                }

                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        public static string NameUppercase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            var firstLetter = name[0].ToString().ToUpper();

            if (name.Length >= 1)
            {
                return firstLetter + name.Substring(1);
            }

            return firstLetter;
        }

        public static bool IsStringLower(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (!char.IsLetter(ch))
                {
                    continue;
                }

                if (!char.IsLower(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public static string NamespaceToDirectory(string ns)
        {
            return ns.Replace(".", "/");
        }

        public static string FixLanguageWord(string word)
        {
            if (_bannedKeywords.Contains(word))
            {
                return word[0] + word;
            }

            return word;
        }
    }
}