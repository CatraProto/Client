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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Settings;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
    public class ProviderWriter
    {
        private string _dictionaryTemplate;
        private List<TLObject> _objects;

        private ProviderWriter(params List<TLObject>[] objects)
        {
            _objects = new List<TLObject>();
            foreach (var objectList in objects)
            {
                _objects = _objects.Concat(objectList).ToList();
            }
        }

        public static async Task<ProviderWriter> CreateAsync(params List<TLObject>[] objects)
        {
            return new ProviderWriter(objects)
            {
                _dictionaryTemplate = await File.ReadAllTextAsync(Configuration.DictionaryTemplatePath)
            };
        }

        public Task WriteDictionary()
        {
            var types = new StringBuilder();
            var nakedObjectTypes = new StringBuilder();
            types.AppendLine($"{StringTools.ThreeTabs}switch (constructorId)\n{StringTools.ThreeTabs}{{");
            foreach (var obj in _objects.Where(x => x is Constructor or Method { IsOptimized: false }))
            {
                if (obj.Id == 0 || obj.Type.TypeInfo.IsNaked)
                {
                    nakedObjectTypes.AppendLine($"if(type == typeof({obj.Namespace.FullNamespace})) \n{{\n return new {obj.Namespace.FullNamespace}();\n}}");
                }

                if (obj.Id == 0)
                {
                    continue;
                }

                types.AppendLine($"{StringTools.FourTabs}case {obj.Id}:");
                types.AppendLine($"{StringTools.FiveTabs}return new {obj.GetObjectName(NamingType.FullNamespace)}();");
            }

            types.AppendLine($"{StringTools.ThreeTabs}}}");

            var result = _dictionaryTemplate.Replace("^Namespace^", Configuration.DictionaryNamespace).Replace("^ProviderName^", Configuration.DictionaryProviderName).Replace("^Switch^", types.ToString()).Replace("^NakedObjectTypes^", nakedObjectTypes.ToString());
            return File.WriteAllTextAsync(Configuration.DictionaryWritePath, result);
        }
    }
}