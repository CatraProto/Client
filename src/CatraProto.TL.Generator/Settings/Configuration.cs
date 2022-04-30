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

namespace CatraProto.TL.Generator.Settings
{
    static class Configuration
    {
        public static string DefaultNamespace { get; set; } = "CatraProto.Client.TL.Schemas.CloudChats";
        public static string Namespace { get; set; } = DefaultNamespace;
        public static string AbstractTemplatePath { get; set; } = "Templates/Abstract.template";
        public static string ConstructorTemplatePath { get; set; } = "Templates/Constructor.template";
        public static string ApiTemplatePath { get; set; } = "Templates/Request.template";
        public static string DictionaryTemplatePath { get; set; } = "Templates/Dictionary.template";
        public static string MethodTemplatePath { get; set; } = "Templates/Method.template";
        public static string UpdateToolsTemplatePath { get; set; } = "Templates/UpdatesTools.template";

        public static string DictionaryNamespace { get; set; } = "CatraProto.Client.TL.Schemas";
        public static string DictionaryWritePath { get; set; } = "CatraProto/Client/TL/Schemas/MergedProvider.cs";
        public static string UpdatesToolsWritePath { get; set; } = "CatraProto/Client/Updates/UpdatesTools.Autogen.cs";
        public static string DictionaryProviderName { get; set; } = "MergedProvider";
    }
}