using System;
using System.Numerics;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL.Tools
{
    public static class Converter
    {
        public static ParserTypes Convert<T>()
        {
            return Convert(typeof(T));
        }

        public static ParserTypes Convert(Type type)
        {
            if (type == typeof(int))
            {
                return ParserTypes.Int;
            }
            else if (type == typeof(long))
            {
                return ParserTypes.Int64;
            }
            else if (type == typeof(double))
            {
                return ParserTypes.Double;
            }
            else if (type == typeof(byte))
            {
                return ParserTypes.Byte;
            }
            else if (type == typeof(byte[]))
            {
                return ParserTypes.Bytes;
            }
            else if (type == typeof(string))
            {
                return ParserTypes.String;
            }
            else if (type == typeof(bool))
            {
                return ParserTypes.Bool;
            }
            else if (type == typeof(IObject))
            {
                return ParserTypes.Object;
            }
            else if (type == typeof(BigInteger))
            {
                return ParserTypes.BigInteger;
            }

            throw new InvalidOperationException($"Type {type} not supported");
        }
    }
}
