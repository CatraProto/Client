using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Settings;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;
using Type = CatraProto.TL.Generator.Objects.Types.Interfaces.TypeBase;

namespace CatraProto.TL.Generator.CodeGeneration.Writing
{
    internal sealed class Writer
    {
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
                _constructorTemplate = await File.ReadAllTextAsync(Configuration.ConstructorTemplatePath)
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
            return File.WriteAllTextAsync(StringTools.NamespaceToDirectory(obj.Namespace.FullNamespace) + ".cs", copy);        }

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