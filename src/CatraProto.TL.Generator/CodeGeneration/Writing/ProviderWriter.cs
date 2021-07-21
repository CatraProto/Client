using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Settings;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
	public class ProviderWriter
	{
		private string _dictionaryTemplate;
		private List<Object> _objects;

		private ProviderWriter(params List<Object>[] objects)
		{
			_objects = new List<Object>();
			foreach (var objectList in objects)
			{
				_objects = _objects.Concat(objectList).ToList();
			}
		}

		public static async Task<ProviderWriter> Create(params List<Object>[] objects)
		{
			return new ProviderWriter(objects)
			{
				_dictionaryTemplate = await File.ReadAllTextAsync(Configuration.DictionaryTemplatePath)
			};
		}

		public Task WriteDictionary()
		{
			var types = new StringBuilder();
			types.AppendLine($"{StringTools.ThreeTabs}switch (constructorId)\n{StringTools.ThreeTabs}{{");
			foreach (var obj in _objects)
			{
				if (obj.Id == 0)
				{
					continue;
				}

				types.AppendLine($"{StringTools.FourTabs}case {obj.Id}:");
				types.AppendLine($"{StringTools.FiveTabs}return new {obj.GetObjectName(NamingType.FullNamespace)}();");
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