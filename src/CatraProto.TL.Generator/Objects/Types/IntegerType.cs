/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Text;
using CatraProto.TL.Generator.CodeGeneration;
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
            if (parameter.VectorInfo.IsVector)
            {
                var tp = BitSize == 32 ? "int" : "long";
                stringBuilder.AppendLine($"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.ReadVector<{tp}>(ParserTypes.{Tools.GetEnumValue(this)});");
            }
            else
            {

                switch (BitSize)
                {
                    case > 64:
                        stringBuilder.AppendLine($"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.ReadBigInteger({BitSize});");
                        break;
                    case 64:
                        stringBuilder.AppendLine($"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.ReadInt64();");
                        break;
                    case 32:
                        stringBuilder.AppendLine($"{spacing}var try{parameter.NamingInfo.CamelCaseName} = reader.ReadInt32();");
                        break;
                    default:
                        stringBuilder.AppendLine($"UNSUPPORTED");
                        break;
                }
            }

            stringBuilder.AppendLine($"if(try{parameter.NamingInfo.CamelCaseName}.IsError){{\nreturn ReadResult<IObject>.Move(try{parameter.NamingInfo.CamelCaseName});\n}}");
            stringBuilder.AppendLine($"{parameter.NamingInfo.PascalCaseName} = try{parameter.NamingInfo.CamelCaseName}.Value;");
            WriteFlagEnd(stringBuilder, spacing, parameter);
        }

        public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
        {
            if (parameter.VectorInfo.IsVector)
            {
                base.WriteSerializer(stringBuilder, parameter);
            }
            else
            {
                WriteFlagStart(stringBuilder, out var spacing, parameter);
                var propertyValue = parameter.HasFlag && !parameter.VectorInfo.IsVector ? parameter.NamingInfo.PascalCaseName + ".Value" : parameter.NamingInfo.PascalCaseName;
                switch (BitSize)
                {
                    case > 64:
                        stringBuilder.AppendLine($"var check{parameter.NamingInfo.PascalCaseName} = writer.WriteBigInteger({propertyValue});");
                        stringBuilder.AppendLine($"if(check{parameter.NamingInfo.PascalCaseName}.IsError){{ return check{parameter.NamingInfo.PascalCaseName};}}");
                        break;
                    case 64:
                        stringBuilder.AppendLine($"writer.WriteInt64({propertyValue});");
                        break;
                    case 32:
                        stringBuilder.AppendLine($"writer.WriteInt32({propertyValue});");
                        break;
                    default:
                        stringBuilder.AppendLine($"UNSUPPORTED");
                        break;
                }
                WriteFlagEnd(stringBuilder, spacing, parameter);
            }
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