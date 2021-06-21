using System.Text.RegularExpressions;
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.CodeGeneration
{
    internal static class Tools
    {
        public static TypeBase CreateType(string type, bool isBaseType = false)
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

            if (isBaseType) type += "Base";
            return new GenericType(type);
        }
    }
}