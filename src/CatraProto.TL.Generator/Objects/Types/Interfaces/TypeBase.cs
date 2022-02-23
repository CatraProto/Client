using System.Collections.Generic;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types.Interfaces
{
    public abstract class TypeBase
    {
        public NamingInfo NamingInfo { get; set; } = new NamingInfo();
        public TypeInfo TypeInfo { get; set; } = new TypeInfo();
        public Namespace Namespace { get; set; }
        public List<Parameter> ReferencedParameters { get; set; } = new List<Parameter>();
        public List<Object> ReferencedObjects { get; set; } = new List<Object>();

        public abstract void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false);

        public virtual void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            string text;
            var typeName = GetTypeName(NamingType.FullNamespace, parameter, false);
            if (parameter.VectorInfo.IsVector)
            {
                if (parameter.VectorInfo.IsNaked)
                {
                    if (parameter.NamingInfo.OriginalName == "messages" && parameter.Type.Namespace.FullNamespace == "CatraProto.Client.TL.Schemas.MTProto.Message")
                    {
                        text = $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.MTProto.Deserializers.MsgContainerDeserializer>(CatraProto.Client.TL.Schemas.MergedProvider.Singleton), {parameter.VectorInfo.IsNaked.ToString().ToLower()}).Cast<CatraProto.Client.TL.Schemas.MTProto.MessageBase>().ToList();";
                    }
                    else
                    {
                        text = $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<{typeName}>(CatraProto.Client.TL.Schemas.MergedProvider.Singleton), {parameter.VectorInfo.IsNaked.ToString().ToLower()});";
                    }
                }
                else
                {
                    text = $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.ReadVector<{typeName}>();";
                }
            }
            else
            {
                text = parameter.Type.TypeInfo.IsNaked ? $"{spacing}{parameter.NamingInfo.PascalCaseName} = new {typeName}();\n{spacing}{parameter.NamingInfo.PascalCaseName}.Deserialize(reader);" : $"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.Read<{typeName}>();";
            }

            stringBuilder.AppendLine(text);
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public virtual void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            stringBuilder.AppendLine($"{spacing}writer.Write({parameter.NamingInfo.PascalCaseName});");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public virtual void WriteFlagUpdate(StringBuilder stringBuilder, Parameter parameter)
        {
            if (!parameter.HasFlag)
            {
                return;
            }

            stringBuilder.AppendLine($"{StringTools.ThreeTabs}{parameter.Flag.Name} = {parameter.NamingInfo.PascalCaseName} == null ? FlagsHelper.UnsetFlag({parameter.Flag.Name}, {parameter.Flag.Bit}) : FlagsHelper.SetFlag({parameter.Flag.Name}, {parameter.Flag.Bit});");
        }

        public virtual void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool isAbstract = false)
        {
            var typeName = GetTypeName(NamingType.FullNamespace, parameter, true, parameter.Type.Namespace?.FullNamespace == "CatraProto.Client.TL.Schemas.MTProto.Message");
            typeName = parameter.HasFlag && TypeInfo.IsBare && !parameter.VectorInfo.IsVector ? typeName + "?" : typeName;
            stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonProperty(\"{parameter.NamingInfo.OriginalName}\")]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {typeName} {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
        }

        public virtual void WriteMethodParameter(StringBuilder stringBuilder, Parameter parameter, bool nullableContext = false)
        {
            var writtenType = GetTypeName(NamingType.FullNamespace, parameter, true, parameter.Type.Namespace?.FullNamespace == "CatraProto.Client.TL.Schemas.MTProto.Message");
            if (nullableContext)
            {
                writtenType = parameter.HasFlag ? $"{writtenType}? {parameter.NamingInfo.CamelCaseName} = null" : $"{writtenType} {parameter.NamingInfo.CamelCaseName}";
                stringBuilder.Append(writtenType);
                return;
            }

            if (parameter.Flag != null && this is not StringType && this is not GenericType && this is not RuntimeDefinedType && this is not BytesType)
            {
                writtenType += "?";
            }

            writtenType = $"{writtenType} {parameter.NamingInfo.CamelCaseName}";

            if (parameter.Flag != null)
            {
                writtenType += " = null";
            }

            stringBuilder.Append(writtenType);
        }

        public virtual NamingInfo GetFinalParameterName(Parameter parameter)
        {
            return parameter.NamingInfo;
        }

        protected void WriteFlagStart(StringBuilder builder, out string spacing, Parameter parameter)
        {
            spacing = parameter.HasFlag ? StringTools.FourTabs : StringTools.ThreeTabs;
            if (parameter.HasFlag)
            {
                builder.AppendLine($"{StringTools.ThreeTabs}if(FlagsHelper.IsFlagSet({parameter.Flag.Name}, {parameter.Flag.Bit}))\n{StringTools.ThreeTabs}{{");
            }
        }

        protected void WriteFlagEnd(StringBuilder builder, string spacing, Parameter parameter)
        {
            if (spacing == StringTools.FourTabs && parameter.HasFlag)
            {
                builder.AppendLine($"{StringTools.ThreeTabs}}}");
                builder.AppendLine();
            }
        }

        protected virtual string GetParameterAccessibility(Parameter parameter, bool isAbstract = false)
        {
            if (isAbstract)
            {
                return "public abstract";
            }

            if (parameter.IsCommon)
            {
                return "public sealed override";
            }

            return "public";
        }

        public virtual string GetTypeName(NamingType type, Parameter parameter, bool includeVector, bool forceBase = false, NameContext nameContext = NameContext.Deserialization)
        {
            string name = "INVALID NAME";
            if (NamingInfo.OriginalName == "BigInteger" && type == NamingType.FullNamespace)
            {
                return "System.Numerics.BigInteger";
            }

            if (TypeInfo.IsBare)
            {
                name = NamingInfo.OriginalName;
            }
            else
            {
                switch (type)
                {
                    case NamingType.CamelCase:
                        name = NamingInfo.CamelCaseName;
                        break;
                    case NamingType.PascalCase:
                        name = NamingInfo.PascalCaseName;
                        break;
                    case NamingType.Original:
                        name = NamingInfo.OriginalName;
                        break;
                    case NamingType.FullNamespace:
                        name = Namespace.FullNamespace;
                        break;
                }
            }

            if (forceBase || !TypeInfo.ForceNoBase && (TypeInfo.IsNaked && nameContext == NameContext.TypeExtends || !TypeInfo.IsNaked && !TypeInfo.IsBare))
            {
                name += "Base";
            }

            if (includeVector && parameter.VectorInfo.IsVector)
            {
                name = "IList<" + name + ">";
            }

            return name;
        }

        public virtual void WriteMethodBeforeCall(StringBuilder builder, Parameter parameter, string returnType)
        {
            return;
        }

        public static bool operator ==(TypeBase type1, TypeBase type2)
        {
            if (type1 is null || type2 is null)
            {
                return false;
            }

            if (type1.NamingInfo.PascalCaseName != type2.NamingInfo.PascalCaseName)
            {
                return false;
            }

            if (type1.Namespace != type2.Namespace)
            {
                return false;
            }

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
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((TypeBase)obj);
        }
    }
}