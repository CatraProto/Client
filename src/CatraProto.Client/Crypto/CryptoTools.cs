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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto
{
    internal static class CryptoTools
    {
        private static readonly RandomNumberGenerator CryptoRandom = RandomNumberGenerator.Create();

        public static long CreateRandomLong()
        {
            return BitConverter.ToInt64(GenerateRandomBytes(8));
        }

        public static int CreateRandomInt()
        {
            return BitConverter.ToInt32(GenerateRandomBytes(4));
        }

        public static void AddPadding(Stream stream, int divisibleBy, int minBytes = 0)
        {
            stream.Write(GenerateRandomBytes(minBytes));
            stream.Write(GenerateRandomBytes(divisibleBy - (int)stream.Length % divisibleBy));
        }

        public static void XorBlock(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second, Span<byte> destination)
        {
            if (first.Length != second.Length && destination.Length == first.Length)
            {
                throw new ArgumentException("First byte span and second must have the same length as the destination span");
            }

            for (var i = 0; i < first.Length; i++)
            {
                destination[i] = (byte)(first[i] ^ second[i]);
            }
        }

        public static void XorBlock(byte[] first, byte[] second, byte[] destination)
        {
            if (first.Length != second.Length && destination.Length == first.Length)
            {
                throw new ArgumentException("First byte array and second must have the same length as the destination array");
            }

            for (var i = 0; i < first.Length; i++)
            {
                destination[i] = (byte)(first[i] ^ second[i]);
            }
        }

        public static byte[] XorBlock(byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
            {
                throw new ArgumentException("First byte array and second must have the same length");
            }

            var output = new byte[first.Length];

            for (var i = 0; i < first.Length; i++)
            {
                output[i] = (byte)(first[i] ^ second[i]);
            }

            return output;
        }

        public static Tuple<byte[], byte[]> GetFastPq(ulong pq)
        {
            var first = FastFactor((long)pq);
            var second = (long)pq / first;

            var transformedFirst = RemoveStartingZeros(BitConverter.GetBytes(first).Reverse().ToArray());
            var transformedSecond = RemoveStartingZeros(BitConverter.GetBytes(second).Reverse().ToArray());
            return first < second ? new Tuple<byte[], byte[]>(transformedFirst, transformedSecond) : new Tuple<byte[], byte[]>(transformedSecond, transformedFirst);
        }

        //https://github.com/UnigramDev/Unigram/blob/cd8ddb40bffd427fd9bc3fa6f2b99608e2118124/Unigram/Unigram.Api/Helpers/Utils.cs#L244
        public static long GreatestCommonDivisor(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                while ((a & 1) == 0)
                {
                    a >>= 1;
                }

                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b == 0 ? a : b;
        }

        public static long FastFactor(long what)
        {
            var r = new Random();
            long g = 0;
            var it = 0;
            for (var i = 0; i < 3; i++)
            {
                var q = (r.Next(128) & 15) + 17;
                long x = r.Next(1000000000) + 1, y = x;
                var lim = 1 << (i + 18);
                for (var j = 1; j < lim; j++)
                {
                    it++;
                    var a = x;
                    var b = x;
                    long c = q;
                    while (b != 0)
                    {
                        if ((b & 1) != 0)
                        {
                            c += a;
                            if (c >= what)
                            {
                                c -= what;
                            }
                        }

                        a += a;
                        if (a >= what)
                        {
                            a -= what;
                        }

                        b >>= 1;
                    }

                    x = c;
                    var z = x < y ? y - x : x - y;
                    g = GreatestCommonDivisor(z, what);
                    if (g != 1)
                    {
                        break;
                    }

                    if ((j & (j - 1)) == 0)
                    {
                        y = x;
                    }
                }

                if (g > 1)
                {
                    break;
                }
            }

            var p = what / g;
            return Math.Min(p, g);
        }

        public static byte[] GenerateRandomBytes(int count)
        {
            var byteArray = new byte[count];
            CryptoRandom.GetNonZeroBytes(byteArray);
            return byteArray;
        }

        public static byte[] RemoveStartingZeros(byte[] array)
        {
            var result = new List<byte>(array);
            while (result.Count > 0 && result[0] == 0x00)
            {
                result.RemoveAt(0);
            }

            return result.ToArray();
        }
    }
}