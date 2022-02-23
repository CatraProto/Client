using System;
using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    class IntegerType : TypeBase
    {
        public int BitSize { get; }

        public IntegerType(int bitSize)
        {
            BitSize = bitSize;
            TypeInfo.IsBare = true;
            switch (BitSize)
            {
                case > 64:
                    NamingInfo = "BigInteger";
                    Namespace = new Namespace("System.Numerics.BigInteger", false);
                    break;
                case 64:
                    NamingInfo = "long";
                    break;
                default:
                    NamingInfo = "int";
                    break;
            }
        }

        public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            var method = parameter.VectorInfo.IsVector ? "ReadVector" : "Read";
            switch (BitSize)
            {
                case > 64:
                    stringBuilder.AppendLine($"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.{method}<System.Numerics.BigInteger>({BitSize});");
                    break;
                default:
                    stringBuilder.AppendLine($"{spacing}{parameter.NamingInfo.PascalCaseName} = reader.{method}<{NamingInfo.OriginalName}>();");
                    break;
            }

            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            var propertyValue = parameter.HasFlag && !parameter.VectorInfo.IsVector ? parameter.NamingInfo.PascalCaseName + ".Value" : parameter.NamingInfo.PascalCaseName;

            stringBuilder.AppendLine($"{spacing}writer.Write({propertyValue});");

            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool isAbstract = false)
        {
            var type = GetTypeName(NamingType.FullNamespace, parameter, true);
            type = parameter.HasFlag && parameter.VectorInfo.IsVector == false ? type + "?" : type;
            stringBuilder.Append($"\n[Newtonsoft.Json.JsonProperty(\"{parameter.NamingInfo.OriginalName}\")]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {type}");
            stringBuilder.AppendLine($" {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
        {
            throw new NotSupportedException("Bare types don't have a Base implementation.");
        }

        public static bool operator ==(IntegerType integer1, IntegerType integer2)
        {
            if (integer1 is null || integer2 is null)
            {
                return false;
            }

            return integer1.BitSize == integer2.BitSize;
        }

        public static bool operator !=(IntegerType integer1, IntegerType integer2)
        {
            if (integer1 is null || integer2 is null)
            {
                return false;
            }

            if (integer1 == integer2)
            {
                return false;
            }

            return true;
        }

        protected bool Equals(IntegerType other)
        {
            return base.Equals(other) && other == this;
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

            return Equals((IntegerType)obj);
        }

        public override int GetHashCode()
        {
            return BitSize;
        }
    }
}