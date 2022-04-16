using System.Collections.Generic;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration;
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
                text = $"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.ReadVector<{typeName}>(ParserTypes.{Tools.GetEnumValue(this)}, nakedVector: {parameter.VectorInfo.IsNaked.ToString().ToLower()}, nakedObjects: {TypeInfo.IsNaked.ToString().ToLower()});";
            }
            else
            {
                text = $"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.{Tools.GetReaderName(this, parameter)}();";
            }

            stringBuilder.AppendLine(text);
            stringBuilder.AppendLine($"if(try{parameter.NamingInfo.CamelCaseName}.IsError){{\nreturn ReadResult<IObject>.Move(try{parameter.NamingInfo.CamelCaseName});\n}}");
            stringBuilder.AppendLine($"{parameter.NamingInfo.PascalCaseName} = try{parameter.NamingInfo.CamelCaseName}.Value;");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public virtual void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            var methodName = Tools.GetWriterName(this, out var mustCheck);
            if (mustCheck)
            {
                stringBuilder.Append($"var check{parameter.NamingInfo.CamelCaseName} = ");
            }
            else
            {
                stringBuilder.AppendLine();
            }
            if (parameter.VectorInfo.IsVector)
            {
                stringBuilder.AppendLine($"{spacing}writer.WriteVector({parameter.NamingInfo.PascalCaseName}, {parameter.VectorInfo.IsNaked.ToString().ToLower()});");
            }
            else
            {
                var paramName = parameter.Type is DoubleType && parameter.HasFlag ? parameter.NamingInfo.PascalCaseName + ".Value" : parameter.NamingInfo.PascalCaseName;
                stringBuilder.AppendLine($"{spacing}writer.{methodName}({paramName});");
            }

            if (mustCheck)
            {
                stringBuilder.AppendLine($"if(check{parameter.NamingInfo.CamelCaseName}.IsError){{\n return check{parameter.NamingInfo.CamelCaseName}; \n}}");
            }

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
            var typeName = GetTypeName(NamingType.FullNamespace, parameter, true);
            typeName = parameter.HasFlag && TypeInfo.IsBare && !parameter.VectorInfo.IsVector ? typeName + "?" : typeName;
            stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonProperty(\"{parameter.NamingInfo.OriginalName}\")]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {typeName} {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
        }

        public virtual void WriteMethodParameter(StringBuilder stringBuilder, Parameter parameter, bool nullableContext = false)
        {
            var writtenType = GetTypeName(NamingType.FullNamespace, parameter, true);
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
                name = "List<" + name + ">";
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