using System;

namespace CatraProto.Client.Tools
{
    static class MiscTools
    {
        //https://github.com/UnigramDev/Unigram/blob/cd8ddb40bffd427fd9bc3fa6f2b99608e2118124/Unigram/Unigram.Api/Helpers/Utils.cs#L244
        public static Tuple<ulong, ulong> GetFastPQ(ulong pq)
        {
            var first = FastFactor((long)pq);
            var second = (long)pq / first;

            return first < second ?
                new Tuple<ulong, ulong>((ulong)first, (ulong)second) :
                new Tuple<ulong, ulong>((ulong)second, (ulong)first);
        }

        public static long GCD(long a, long b)
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
                    ++it;
                    long a = x, b = x, c = q;
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
                    g = GCD(z, what);
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
