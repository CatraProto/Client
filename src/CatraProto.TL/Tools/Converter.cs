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
