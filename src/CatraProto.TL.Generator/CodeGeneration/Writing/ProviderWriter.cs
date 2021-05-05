using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.Settings;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
    public class DictionaryWriter
    {
        private string _dictionaryTemplate;
        private List<Object> _objects;

        private DictionaryWriter(params List<Object>[] objects)
        {
            _objects = new List<Object>();
            foreach (var objectList in objects)
            {
                _objects = _objects.Concat(objectList).ToList();
            }
        }

        public static async Task<DictionaryWriter> Create(params List<Object>[] objects)
        {
            return new DictionaryWriter(objects)
            {
                _dictionaryTemplate = await File.ReadAllTextAsync(Configuration.DictionaryTemplatePath),
            };
        }

        public Task WriteDictionary()
        {
            var types = new StringBuilder();
            types.AppendLine($"{StringTools.ThreeTabs}switch (constructorId)\n{StringTools.ThreeTabs}{{");
            foreach (var obj in _objects)
            {
                if (obj.IsNaked) continue;

                types.AppendLine($"{StringTools.FourTabs}case {obj.Id}:");
                types.AppendLine($"{StringTools.FiveTabs}return new {obj.Namespace.PartialNamespace}.{obj.Name}();");
            }

            types.AppendLine($"{StringTools.ThreeTabs}}}");

            var result = _dictionaryTemplate
                .Replace("^Namespace^", Configuration.DictionaryNamespace)
                .Replace("^ProviderName^", Configuration.DictionaryProviderName)
                .Replace("^Switch^", types.ToString());
            return File.WriteAllTextAsync(Configuration.DictionaryWritePath, result);
        }
    }
}