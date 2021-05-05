using System;
using System.Collections.Generic;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    internal class IntegerType : TypeBase
    {
        public int BitSize { get; }

        public IntegerType(int bitSize)
        {
            IsBare = true;
            BitSize = bitSize;
            Name = BitSize switch
            {
                > 64 => "BigInteger",
                64 => "long",
                _ => "int"
            };
        }

        public override void WriteDeserializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            var method = parameter.IsVector ? "ReadVector" : "Read";
            switch (BitSize)
            {
                case > 64:
                    stringBuilder.AppendLine($"{spacing}{parameter.Name} = reader.{method}<BigInteger>({BitSize.ToString()});");
                    break;
                default:
                    stringBuilder.AppendLine($"{spacing}{parameter.Name} = reader.{method}<{Name}>();");
                    break;
            }

            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            WriteFlagStart(stringBuilder, out var spacing, parameter);
            var propertyValue = parameter.HasFlag && !parameter.IsVector ? parameter.Name + ".Value" : parameter.Name;
            
            switch (BitSize)
            {
                case > 64:
                    stringBuilder.AppendLine($"{spacing}var size{parameter.Name} = {parameter.Name}.GetByteCount();");
                    stringBuilder.AppendLine($"{spacing}if(size{parameter.Name} != {BitSize / 8}){{");
                    stringBuilder.AppendLine($"{spacing}{StringTools.OneTabs}throw new CatraProto.TL.Exceptions.SerializationException($\"ByteSize mismatch, should be {BitSize / 8}bytes got {{size{parameter.Name}}}bytes\", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);");
                    stringBuilder.AppendLine($"{spacing}}}");
                    stringBuilder.AppendLine($"{spacing}writer.Write({parameter.Name});");
                    break;
                default:
                    stringBuilder.AppendLine($"{spacing}writer.Write({propertyValue});");
                    break;
            }

            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter,
            string customTypeName = null, bool isAbstract = false)
        {
            var type = parameter.IsVector ? $"IList<{Name}>" : Name;
            type = parameter.HasFlag && parameter.IsVector == false ? type + "?" : type;
            stringBuilder.Append($"{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} {type}");
            stringBuilder.AppendLine($" {parameter.Name} {{ get; set; }}");
        }
        
        public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
        {
            throw new NotSupportedException("Bare types don't have a Base implementation.");
        }

        public override List<Namespace> GetRequiredNamespaces(Parameter parameter)
        {
            var list = base.GetRequiredNamespaces(parameter);
            if (BitSize > 64) list.Add(new Namespace("System.Numerics.BigInteger", false));

            return list;
        }

        public static bool operator ==(IntegerType integer1, IntegerType integer2)
        {
            if (integer1 is null || integer2 is null) return false;

            return integer1.BitSize == integer2.BitSize;
        }

        public static bool operator !=(IntegerType integer1, IntegerType integer2)
        {
            if (integer1 is null || integer2 is null) return false;

            if (integer1 == integer2) return false;

            return true;
        }

        protected bool Equals(IntegerType other)
        {
            return base.Equals(other) && other == this;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IntegerType)obj);
        }

        public override int GetHashCode()
        {
            return BitSize;
        }
    }
}