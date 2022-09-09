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

        public static (byte[], byte[]) GetFastPq(ulong pq)
        {
            var first = PqFactorize(pq);
            var second = pq / first;

            var firstAdjusted = SkipFirstNulls(BitConverter.GetBytes(first).Reverse().ToArray());
            var secondAdjusted = SkipFirstNulls(BitConverter.GetBytes(second).Reverse().ToArray());
            return first < second ? (firstAdjusted, secondAdjusted) : (secondAdjusted, firstAdjusted);
        }

        // PQ Factorization is taken from TDLib and simply adapted to C#
        // https://github.com/tdlib/td/blob/master/tdutils/td/utils/crypto.cpp
        public static ulong PqGcd(ulong a, ulong b)
        {
            if (a == 0)
            {
                return b;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            while (true)
            {
                if (a > b)
                {
                    a = (a - b) >> 1;
                    while ((a & 1) == 0)
                    {
                        a >>= 1;
                    }
                }
                else if (b > a)
                {
                    b = (b - a) >> 1;
                    while ((b & 1) == 0)
                    {
                        b >>= 1;
                    }
                }
                else
                {
                    return a;
                }
            }
        }

        // returns (c + a * b) % pq
        public static ulong PqAddMul(ulong c, ulong a, ulong b, ulong pq)
        {
            while (b > 0)
            {
                if ((b & 1) > 0)
                {
                    c += a;
                    if (c >= pq)
                    {
                        c -= pq;
                    }
                }

                a += a;
                if (a >= pq)
                {
                    a -= pq;
                }

                b >>= 1;
            }

            return c;
        }

        public static ulong PqFactorize(ulong pq)
        {
            if (pq <= 2 || pq > (((ulong)1) << 63))
            {
                return 1;
            }

            if ((pq & 1) == 0)
            {
                return 2;
            }

            ulong g = 0;
            for (int i = 0, iter = 0; i < 3 || iter < 1000; i++)
            {
                var q = (ulong)Random.Shared.Next(17, 32) % (pq - 1);
                var x = ((ulong)Random.Shared.NextInt64()) % (pq - 1) + 1;
                var y = x;
                var lim = 1 << (Math.Min(5, i) + 18);
                for (var j = 1; j < lim; j++)
                {
                    iter++;
                    x = PqAddMul(q, x, x, pq);
                    var z = x < y ? pq + x - y : x - y;
                    g = PqGcd(z, pq);
                    if (g != 1)
                    {
                        break;
                    }

                    if ((j & (j - 1)) == 0)
                    {
                        y = x;
                    }
                }

                if (g > 1 && g < pq)
                {
                    break;
                }
            }

            if (g != 0)
            {
                var other = pq / g;
                if (other < g)
                {
                    g = other;
                }
            }

            return g;
        }

        public static byte[] GenerateRandomBytes(int count)
        {
            var byteArray = new byte[count];
            CryptoRandom.GetNonZeroBytes(byteArray);
            return byteArray;
        }

        public static byte[] SkipFirstNulls(byte[] array)
        {
            return array.SkipWhile(x => x == 0).ToArray();
        }
    }
}