using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Settings;
using Type = CatraProto.TL.Generator.Objects.Types.Interfaces.TypeBase;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
    sealed class Writer
    {
        private static readonly string _publicConstructor = "#nullable enable\n public ^Class^ (^ConstructorValues^)\n{\n ^ConstructorBody^ \n}\n#nullable disable";
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
            foreach (var obj in _objects.Where(x => x is Constructor or Method { IsOptimized: false }))
            {
                if (!_writtenTypes.Contains(obj.Type) && !obj.Type.TypeInfo.IsBare)
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
                method.WriteMethod(stringBuilder, false);

                var fixedNamespace = new Namespace(method.Namespace.FullNamespace, false);
                fixedNamespace[3] = "Requests";

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
                    var writtenInit = $"\n{fixedNamespace.PartialNamespaceArray[^1]} = new {fixedNamespace.PartialNamespace}(client, messagesQueue);";
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
                taskList.Add(File.WriteAllTextAsync(ns.FullNamespace.Replace(".", "/") + ".cs", template.Replace("^Namespace^", ns.PartialNamespace).Replace("^Class^", ns.Class).Replace("^Other^", pair.Value[0]).Replace("^Methods^", pair.Value[1]).Replace("^Inits^", pair.Value[2])));
            }

            await Task.WhenAll(taskList);
        }

        private Task WriteObject(Object obj)
        {
            var flagsEnum = new StringBuilder();
            var parameters = new StringBuilder();
            var serializer = new StringBuilder();
            var deserializer = new StringBuilder();
            var flagsUpdating = new StringBuilder();
            obj.WriteFlagsUpdating(flagsUpdating);
            obj.WriteFlagsEnums(flagsEnum);
            obj.WriteParameters(parameters);
            obj.WriteSerializer(serializer);
            obj.WriteDeserializer(deserializer);
            var emptyConstructoAccess = "";
            var publicContru = "";
            var hasNotNullParams = obj.HasNotNullParameters();
            if (hasNotNullParams)
            {
                emptyConstructoAccess = "internal";
                var constructorBody = new StringBuilder();
                var constructorParameters = new StringBuilder();
                obj.WriteConstructorBody(constructorBody);
                obj.WriteConstructorParameters(constructorParameters);
                publicContru = _publicConstructor.Replace("^ConstructorBody^", constructorBody.ToString()).Replace("^ConstructorValues^", constructorParameters.ToString()).Replace("^Class^", obj.NamingInfo.PascalCaseName);
            }
            else
            {
                emptyConstructoAccess = "public";
            }

            var template = obj is Method ? _methodTemplate : _constructorTemplate;
            var copy = template.Replace("^Class^", obj.NamingInfo.PascalCaseName).Replace("^Namespace^", obj.Namespace.PartialNamespace).Replace("^Properties^", parameters.ToString()).Replace("^Deserialization^", deserializer.ToString()).Replace("^Serialization^", serializer.ToString()).Replace("^Type^", obj.Type.GetTypeName(NamingType.FullNamespace, null, false, false, NameContext.TypeExtends)).Replace("^FlagsEnums^", flagsEnum.ToString()).Replace("^FlagsUpdate^", flagsUpdating.ToString()).Replace("^ConstructorId^", obj.Id.ToString()).Replace("^MethodAccessibility^", obj.GetMethodsAccessibility()).Replace("^ObjectRawName^", obj.NamingInfo.OriginalNamespacedName).Replace("^PublicConstructor^", publicContru).Replace("^EmptyConstructorAccessibility^", emptyConstructoAccess);
            Directory.CreateDirectory(StringTools.NamespaceToDirectory(obj.Namespace.PartialNamespace));
            if (obj is Method method)
            {
                var builder = new StringBuilder();
                method.WriteMethod(builder, false);
                //File.WriteAllTextAsync(StringTools.NamespaceToDirectory(obj.Namespace.FullNamespace) + "_Method.cs", builder.ToString()));
            }

            return File.WriteAllTextAsync(StringTools.NamespaceToDirectory(obj.Namespace.FullNamespace) + ".cs", copy);
        }

        private Task WriteType(Type type)
        {
            var baseParameters = new StringBuilder();
            type.WriteBaseParameters(baseParameters, true);
            var copy = _typeTemplate.Replace("^Type^", type.GetTypeName(NamingType.PascalCase, null, false, false, NameContext.TypeExtends)).Replace("^Namespace^", type.Namespace.PartialNamespace).Replace("^Properties^", baseParameters.ToString());
            Directory.CreateDirectory(StringTools.NamespaceToDirectory(type.Namespace.PartialNamespace));
            return File.WriteAllTextAsync(StringTools.NamespaceToDirectory(type.GetTypeName(NamingType.FullNamespace, null, false, false, NameContext.TypeExtends)) + ".cs", copy);
        }
    }
}