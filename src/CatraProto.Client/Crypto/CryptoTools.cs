using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CatraProto.Client.Crypto
{
    static class CryptoTools
    {
        public static BigInteger GenerateBigInt(int size, bool unsinged = false)
        {
            var byteArray = new byte[size / 8];
            new Random().NextBytes(byteArray);
            return new BigInteger(byteArray, unsinged);
        }


        public static Tuple<byte[], byte[]> GetFastPq(ulong pq)
        {
            var first = FastFactor((long)pq);
            var second = (long)pq / first;

            var transformedFirst = RemoveFirstBytes(BitConverter.GetBytes(first).Reverse().ToArray());
            var transformedSecond = RemoveFirstBytes(BitConverter.GetBytes(second).Reverse().ToArray());
            return first < second
                ? new Tuple<byte[], byte[]>(transformedFirst, transformedSecond)
                : new Tuple<byte[], byte[]>(transformedSecond, transformedFirst);
        }

        private static byte[] RemoveFirstBytes(byte[] array)
        {
            var result = new List<byte>(array);

            while (result.Count > 0 && result[0] == 0x00)
            {
                result.RemoveAt(0);
            }

            return result.ToArray();
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
    }
}