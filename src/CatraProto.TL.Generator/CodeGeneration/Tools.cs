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

using System.Numerics;
using System;
using System.Text.RegularExpressions;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;
using CatraProto.TL.Generator.Objects.Types.InternalTypes;
using Microsoft.VisualBasic;
using CatraProto.TL.Generator.Objects;

namespace CatraProto.TL.Generator.CodeGeneration
{
    static class Tools
    {
        public static TypeBase CreateType(string type, TypeInfo typeInfo, string sourceName = null)
        {
            if (Regex.IsMatch(type, @"\bint[0-9]*"))
            {
                var bits = type.Replace("int", string.Empty);
                return bits == "" ? new IntegerType(32) : new IntegerType(int.Parse(bits));
            }

            switch (type)
            {
                case "string":
                    return new StringType();
                case "#":
                    return new FlagType();
                case "true":
                case "false":
                case "Bool":
                    return new BoolType(type);
                case "long":
                    return new IntegerType(64);
                case "bytes":
                    return new BytesType();
                case "double":
                    return new DoubleType();
                case "!X":
                case "Object":
                case "X":
                    return new RuntimeDefinedType();
            }

            return new GenericType(type, typeInfo);
        }

        public static string GetWriterName(TypeBase type, out bool mustCheck)
        {
            mustCheck = false;
            switch (type)
            {
                case BoolType:
                    mustCheck = true;
                    return "WriteBool";
                case BytesType:
                    return "WriteBytes";
                case DoubleType:
                    return "WriteDouble";
                case FlagType:
                    return "WriteInt32";
                case RandomId:
                    return "WriteInt64";
                case GenericType:
                case InputChannelOrUserAuto:
                case InputPeerBaseAuto:
                case RuntimeDefinedType:
                    mustCheck = true;
                    return "WriteObject";
                case StringType:
                    return "WriteString";
                default:
                    return "NOT RECOGNIZED";
            }
        }

        public static string GetReaderName(TypeBase type, Parameter parameter)
        {
            switch (type)
            {
                case BoolType:
                    return "ReadBool";
                case BytesType:
                    return "ReadBytes";
                case DoubleType:
                    return "ReadDouble";
                case FlagType:
                    return "ReadInt32";
                case RandomId:
                    return "ReadInt64";
                case GenericType:
                case RuntimeDefinedType:
                case InputChannelOrUserAuto:
                case InputPeerBaseAuto:
                    return $"ReadObject<{type.GetTypeName(NamingType.FullNamespace, parameter, false)}>";
                case StringType:
                    return "ReadString";
                default:
                    return "NOT RECOGNIZED";
            }
        }

        public static string GetEnumValue(TypeBase type)
        {
            switch (type)
            {
                case BoolType:
                    return "Bool";
                case BytesType:
                    return "Bytes";
                case DoubleType:
                    return "Double";
                case FlagType:
                    return "Int";
                case RandomId:
                    return "Int64";
                case GenericType:
                case InputChannelOrUserAuto:
                case InputPeerBaseAuto:
                case RuntimeDefinedType:
                    return $"Object";
                case StringType:
                    return "String";
                case IntegerType inte when (inte.BitSize == 32):
                    return "Int";
                case IntegerType inte when (inte.BitSize == 64):
                    return "Int64";
                case IntegerType inte when (inte.BitSize > 64):
                    return "BigInteger";
                default:
                    return "NOT RECOGNIZED";
            }
        }
    }
}