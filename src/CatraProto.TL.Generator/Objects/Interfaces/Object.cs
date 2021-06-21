using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Interfaces
{
    public abstract class Object
    {
        public int Id { get; set; }
        public Namespace Namespace { get; set; }
        public List<Parameter> Parameters { get; set; }
        public TypeBase Type { get; set; }
        public bool IsNaked { get; set; }

        public string Name
        {
            get => Namespace.Class;
            set => Namespace[^1] = value;
        }

        public virtual string GetMethodsAccessibility()
        {
            if (Type is RuntimeDefinedType)
            {
                return "public";
            }

            return "public override";
        }
        
        public virtual void WriteFlagsUpdating(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteFlagUpdate(builder, parameter);
            }
        }

        public virtual void WriteUsings(StringBuilder builder)
        {
            var importsList = new List<string>();
            builder.AppendLine($"using CatraProto.TL;");
            builder.AppendLine($"using CatraProto.TL.Interfaces;");

            if (this is Method && Type.Namespace != null)
            {
                builder.AppendLine($"using {Type.Namespace.PartialNamespace};");
                importsList.Add(Type.Namespace.PartialNamespace);
            }

            foreach (var parameter in Parameters)
            {
                foreach (var requiredNamespace in parameter.Type.GetRequiredNamespaces(parameter))
                {
                    if (!importsList.Contains(requiredNamespace.PartialNamespace))
                    {
                        builder.AppendLine($"using {requiredNamespace.PartialNamespace};");
                        importsList.Add(requiredNamespace.PartialNamespace);
                    }
                }
            }
        }

        public virtual void WriteFlagsEnums(StringBuilder builder)
        {
            var getFlaggedParameters = Parameters.Where(x => x.HasFlag).ToList();
            var dictionary = new Dictionary<string, List<Parameter>>();

            foreach (var flaggedParameter in getFlaggedParameters)
                if (dictionary.ContainsKey(flaggedParameter.Flag.Name))
                {
                    dictionary[flaggedParameter.Flag.Name].Add(flaggedParameter);
                }
                else
                {
                    var list = new List<Parameter> {flaggedParameter};
                    dictionary.Add(flaggedParameter.Flag.Name, list);
                }

            var lastIterationNumber = 1;
            foreach (var flag in dictionary)
            {
                builder.AppendLine($"{StringTools.TwoTabs}[Flags]");
                builder.AppendLine(
                    $"{StringTools.TwoTabs}public enum {StringTools.PascalCase(flag.Key)}Enum \n{StringTools.TwoTabs}{{");
                for (var index = 0; index < flag.Value.Count; index++)
                {
                    var parameter = flag.Value[index];
                    builder.Append($"{StringTools.ThreeTabs}{parameter.Name} = 1 << {parameter.Flag.Bit}");
                    if (flag.Value.Count != index + 1) builder.Append(',');

                    builder.AppendLine();
                }

                builder.Append($"{StringTools.TwoTabs}}}");
                if (dictionary.Count > lastIterationNumber)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                }

                lastIterationNumber++;
            }
        }

        public virtual void WriteParameters(StringBuilder builder)
        {
            foreach (var parameter in Parameters) parameter.Type.WriteParameter(builder, parameter);
        }

        public virtual void WriteSerializer(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteSerializer(builder, parameter);
            }
        }

        public virtual void WriteDeserializer(StringBuilder builder)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Type.WriteDeserializer(builder, parameter);
            }
        }
    }
}