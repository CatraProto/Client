using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Settings;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;
using Type = CatraProto.TL.Generator.Objects.Types.Interfaces.TypeBase;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
	sealed class Writer
	{
		private string _apiTemplated;
		private string _constructorTemplate;
		private string _methodTemplate;
		private List<Object> _objects;
		private string _typeTemplate;
		private List<Type> _writtenTypes = new List<Type>();

		private Writer(List<Object> objects)
		{
			_objects = objects;
		}

		public static async Task<Writer> Create(List<Object> objects)
		{
			return new Writer(objects)
			{
				_typeTemplate = await File.ReadAllTextAsync(Configuration.AbstractTemplatePath),
				_methodTemplate = await File.ReadAllTextAsync(Configuration.MethodTemplatePath),
				_constructorTemplate = await File.ReadAllTextAsync(Configuration.ConstructorTemplatePath),
				_apiTemplated = await File.ReadAllTextAsync(Configuration.ApiTemplatePath)
			};
		}

		public async Task Write()
		{
			var tasks = new List<Task>();
			foreach (var obj in _objects)
			{
				if (!_writtenTypes.Contains(obj.Type) && !obj.Type.IsBare)
				{
					_writtenTypes.Add(obj.Type);
					tasks.Add(WriteType(obj.Type));
				}

				tasks.Add(WriteObject(obj));
			}

			await Task.WhenAll(tasks);
		}

		//This code is awful, I know
		public async Task WriteMethods()
		{
			var files = new Dictionary<string, string[]>();
			var writtenNamespaces = new List<string>();
			foreach (var o in _objects.Where(x => x is Method))
			{
				var method = (Method)o;
				var stringBuilder = new StringBuilder();
				method.WriteMethod(stringBuilder);

				var fixedNamespace = new Namespace(method.Namespace.FullNamespace, false)
				{
					[3] = "Requests"
				};

				if (fixedNamespace.PartialNamespaceArray.Length == 5)
				{
					fixedNamespace[4] += "Api";
				}

				if (files.TryGetValue(fixedNamespace.PartialNamespace, out var file))
				{
					file[1] += stringBuilder.ToString();
				}
				else
				{
					files.Add(fixedNamespace.PartialNamespace, new[] { "", stringBuilder.ToString(), "" });
				}

				if (fixedNamespace.PartialNamespaceArray.Length > 5)
				{
					var ns = Namespace.ArrayToString(fixedNamespace.PartialNamespaceArray[..6]);
					var writtenProp = $"\npublic {fixedNamespace.PartialNamespace} {fixedNamespace.PartialNamespaceArray[^1]} {{ get; }}";
					var writtenInit = $"\n{fixedNamespace.PartialNamespaceArray[^1]} = new {fixedNamespace.PartialNamespace}(messagesHandler);";
					if (writtenNamespaces.Contains(ns))
					{
						continue;
					}

					if (files.TryGetValue(Namespace.ArrayToString(fixedNamespace.PartialNamespaceArray[..5]) + "Api", out var filee))
					{
						filee[0] += writtenProp;
						filee[2] += writtenInit;
					}
					else
					{
						files.Add(Namespace.ArrayToString(fixedNamespace.PartialNamespaceArray[..5]) + "Api", new[] { writtenProp, "", writtenInit });
					}

					writtenNamespaces.Add(ns);
				}
			}

			var taskList = new List<Task>();
			foreach (var pair in files)
			{
				var template = _apiTemplated;
				var ns = new Namespace(pair.Key, false)
				{
					[3] = "Requests"
				};

				Directory.CreateDirectory(StringTools.NamespaceToDirectory(ns.PartialNamespace).Replace(".", "/"));
				taskList.Add(File.WriteAllTextAsync(ns.FullNamespace.Replace(".", "/") + ".cs", template
					.Replace("^Namespace^", ns.PartialNamespace)
					.Replace("^Class^", ns.Class)
					.Replace("^Other^", pair.Value[0])
					.Replace("^Methods^", pair.Value[1])
					.Replace("^Inits^", pair.Value[2])
				));
			}

			await Task.WhenAll(taskList);
		}

		private Task WriteObject(Object obj)
		{
			var usings = new StringBuilder();
			var flagsEnum = new StringBuilder();
			var parameters = new StringBuilder();
			var serializer = new StringBuilder();
			var deserializer = new StringBuilder();
			var flagsUpdating = new StringBuilder();
			obj.WriteUsings(usings);
			obj.WriteFlagsUpdating(flagsUpdating);
			obj.WriteFlagsEnums(flagsEnum);
			obj.WriteParameters(parameters);
			obj.WriteSerializer(serializer);
			obj.WriteDeserializer(deserializer);
			var template = obj is Method ? _methodTemplate : _constructorTemplate;
			var copy = template
				.Replace("^Class^", obj.Name)
				.Replace("^Namespace^", obj.Namespace.PartialNamespace)
				.Replace("^Properties^", parameters.ToString())
				.Replace("^Usings^", usings.ToString())
				.Replace("^Deserialization^", deserializer.ToString())
				.Replace("^Serialization^", serializer.ToString())
				.Replace("^Type^", obj.Type.Name)
				.Replace("^FlagsEnums^", flagsEnum.ToString())
				.Replace("^FlagsUpdate^", flagsUpdating.ToString())
				.Replace("^ConstructorId^", obj.Id.ToString())
				.Replace("^ResponseType^", obj.Type.IsBare ? obj.Type.Name : obj.Type.Namespace.FullNamespace)
				.Replace("^MethodAccessibility^", obj.GetMethodsAccessibility());
			Directory.CreateDirectory(StringTools.NamespaceToDirectory(obj.Namespace.PartialNamespace));
			if (obj is Method method)
			{
				Console.WriteLine("is method");
				var builder = new StringBuilder();
				method.WriteMethod(builder);
				//File.WriteAllTextAsync(StringTools.NamespaceToDirectory(obj.Namespace.FullNamespace) + "_Method.cs", builder.ToString()));
			}

			return File.WriteAllTextAsync(StringTools.NamespaceToDirectory(obj.Namespace.FullNamespace) + ".cs", copy);
		}

		private Task WriteType(Type type)
		{
			var usings = new StringBuilder();
			var baseParameters = new StringBuilder();
			type.WriteBaseParameters(baseParameters, true);
			type.WriteUsings(usings);
			var copy = _typeTemplate
				.Replace("^Type^", type.Name)
				.Replace("^Namespace^", type.Namespace.PartialNamespace)
				.Replace("^Properties^", baseParameters.ToString())
				.Replace("^Usings^", usings.ToString());
			Directory.CreateDirectory(StringTools.NamespaceToDirectory(type.Namespace.PartialNamespace));
			return File.WriteAllTextAsync(StringTools.NamespaceToDirectory(type.Namespace.FullNamespace) + ".cs", copy);
		}
	}
}