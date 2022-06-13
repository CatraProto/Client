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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Serilog;

namespace CatraProto.Client.Crypto
{
    internal class MTProto
    {
        public static List<BigInteger> KnownPrimes { get; } = new List<BigInteger>()
        {
            BigInteger.Parse("25135566567101483196994790440833279750474660393232382279277736257066266618532493517139001963526957179514521981877335815379755618191324858392834843718048308951653115284529736874534289456833723962912807104017411854314007953484461899139734367756070456068592886771130491355511301923675421649355211882120329692353507392677087555292357140606251171702417804959957862991259464749806480821163999054978911727901705780417863120490095024926067731615229486812312187386108568833026386220686253160504779704721744600638258183939573405528962511242337923530869616215532193967628076922234051908977996352800560160181197923404454023908443")
        };

        public static bool CheckRangeDhPrime(BigInteger number, ILogger? logger = null)
        {
            if (!(BigInteger.Pow(2, 2047) < number && number < BigInteger.Pow(2, 2048)))
            {
                logger?.Error("{Number} is NOT between 2^2047 and 2^2048", number);
                return false;
            }

            logger?.Verbose("{Number} is between 2^2047 and 2^2048", number);
            return true;
        }

        public static bool CheckCyclicSubgroup(BigInteger number, int g, ILogger? logger = null)
        {
            switch (g)
            {
                case 2:
                    return number % 8 == 7;
                case 3:
                    return number % 3 == 2;
                case 4:
                    return true;
                case 5:
                    var mod5 = number % 5;
                    return mod5 == 1 || mod5 == 4;
                case 6:
                    var mod6 = number % 24;
                    return mod6 == 19 || mod6 == 23;
                case 7:
                    var mod7 = number % 7;
                    return mod7 == 3 || mod7 == 5 || mod7 == 6;
                default:
                    logger?.Error("Invalid G {G}", g);
                    return false;
            }
        }

        // Adapted from https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
        public static bool CheckPrimeness(BigInteger number, int certainty = 60, ILogger? logger = null)
        {
            logger?.Verbose("Verifying primeness of {Number}", number);
            if (number == 2 || number == 3)
            {
                return true;
            }

            if (number < 2 || number % 2 == 0)
            {
                return false;
            }

            var d = number - 1;
            var s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            BigInteger a;
            for (var i = 0; i < certainty; i++)
            {
                do
                {
                    a = BigIntegerTools.GenerateBigInt(2048);
                }
                while (a < 2 || a >= number - 2);

                var x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1)
                {
                    continue;
                }

                for (var r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1)
                    {
                        return false;
                    }

                    if (x == number - 1)
                    {
                        break;
                    }
                }

                if (x != number - 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static byte[] ComputeAesKeyV2(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var newNonceFirst = Hashing.ShaBigIntegers(newNonce, serverNonce);
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);

            ms.Write(newNonceFirst);
            ms.Write(serverNonceFirst.Take(12).ToArray());
            return ms.ToArray();
        }

        public static byte[] ComputeAesIvV2(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);
            var newNonceOnly = Hashing.ShaBigIntegers(newNonce, newNonce);

            ms.Write(serverNonceFirst.Skip(12).Take(8).ToArray());
            ms.Write(newNonceOnly);
            ms.Write(newNonce.ToByteArray().Take(4).ToArray());
            return ms.ToArray();
        }
    }
}