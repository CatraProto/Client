using System.Collections.Generic;
using System.Text;
using CatraProto.TL.Generator.Objects.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types.Interfaces
{
    public abstract class TypeBase
    {
        public string Name { get; set; }
        public bool IsBare { get; set; }
        public bool IsNaked { get; set; }
        public Namespace Namespace { get; set; }
        public List<Parameter> ReferencedParameters { get; set; } = new List<Parameter>();
        public List<Object> ReferencedObjects { get; set; } = new List<Object>();
        public bool IsVector { get; set; }

        public abstract void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false);

        public virtual void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            string text;
            var typeName = IsBare ? Name : Namespace.FullNamespace;
            var type = parameter.IsVector ? $"IList<{typeName}>" : typeName;
            if (parameter.IsVector)
            {
                text = parameter.IsNaked ? $"{spacing}{parameter.Name} = reader.ReadVector<{typeName}>(() => {{var instance = ({typeName})new {typeName[..^4]}(); instance.Deserialize(reader); return instance;}});" : $"{spacing}{parameter.Name} = reader.ReadVector<{typeName}>();";
            }
            else
            {
                text = parameter.IsNaked ? $"{spacing}{parameter.Name} = ({type})new {type[..^4]}();\n{spacing}{parameter.Name}.Deserialize(reader);" : $"{spacing}{parameter.Name} = reader.Read<{type}>();";
            }

            stringBuilder.AppendLine(text);
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public virtual void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            stringBuilder.AppendLine($"{spacing}writer.Write({parameter.Name});");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public virtual void WriteFlagUpdate(StringBuilder stringBuilder, Parameter parameter)
        {
            if (!parameter.HasFlag) return;
            stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Flag.Name} = {parameter.Name} == null ? FlagsHelper.UnsetFlag({parameter.Flag.Name}, {parameter.Flag.Bit}) : FlagsHelper.SetFlag({parameter.Flag.Name}, {parameter.Flag.Bit});");
        }

        public virtual void WriteParameter(StringBuilder stringBuilder, Parameter parameter,
            string customTypeName = null, bool isAbstract = false)
        {
            var typeName = IsBare ? Name : Namespace.FullNamespace;
            var type = parameter.IsVector ? $"IList<{typeName}>" : typeName;
            type = parameter.HasFlag && IsBare && !IsVector ? type + "?" : type;
            stringBuilder.AppendLine(
                $"{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {type} {parameter.Name} {{ get; set; }}");
        }

        public virtual void WriteMethodParameter(StringBuilder stringBuilder, Parameter parameter)
        {
            var writtenType = parameter.Type.IsBare ? parameter.Type.Name : parameter.Type.Namespace.FullNamespace;
            if (parameter.IsVector)
            {
                writtenType = "List<" + writtenType + ">";
            }

            if (parameter.HasFlag && this is not StringType)
            {
                writtenType += "?";
            }

            writtenType = $"{writtenType} {parameter.InMethodName}";

            if (parameter.HasFlag)
            {
                writtenType += " = null";
            }

            stringBuilder.Append(writtenType);
        }

        protected void WriteFlagStart(StringBuilder builder, out string spacing, Parameter parameter)
        {
            spacing = parameter.HasFlag ? StringTools.FourTabs : StringTools.ThreeTabs;
            if (parameter.HasFlag)
                builder.AppendLine(
                    $"{StringTools.ThreeTabs}if(FlagsHelper.IsFlagSet({parameter.Flag.Name}, {parameter.Flag.Bit}))\n{StringTools.ThreeTabs}{{");
        }

        protected void WriteFlagEnd(StringBuilder builder, string spacing, Parameter parameter)
        {
            if (spacing == StringTools.FourTabs && parameter.HasFlag)
            {
                builder.AppendLine($"{StringTools.ThreeTabs}}}");
                builder.AppendLine();
            }
        }

        public virtual List<Namespace> GetRequiredNamespaces(Parameter parameter)
        {
            var list = new List<Namespace>();

            if (parameter.IsVector) list.Add(new Namespace("System.Collections.Generic.IList", false));
            if (!IsBare) list.Add(Namespace);

            return list;
        }

        public void WriteUsings(StringBuilder builder)
        {
            var importsList = new List<string>();
            builder.AppendLine("using CatraProto.TL;");
            builder.AppendLine("using CatraProto.TL.Interfaces;");

            foreach (var obReferencedObject in ReferencedObjects)
            {
                foreach (var parameter in obReferencedObject.Parameters)
                {
                    if (!parameter.IsCommon) continue;
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
        }

        protected string GetParameterAccessibility(Parameter parameter, bool isAbstract = false)
        {
            if (isAbstract) return "public abstract";
            if (parameter.IsCommon) return "public override";
            return "public";
        }

        public static bool operator ==(TypeBase type1, TypeBase type2)
        {
            if (type1 is null || type2 is null) return false;
            if (type1.Name != type2.Name) return false;
            if (type1.Namespace != type2.Namespace) return false;

            return true;
        }

        public static bool operator !=(TypeBase type1, TypeBase type2)
        {
            return !(type1 == type2);
        }

        protected bool Equals(TypeBase other)
        {
            return other == this;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypeBase)obj);
        }
    }
}