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
using System.Numerics;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto
{
    internal static class Hashing
    {
        public static byte[] ComputeDataHashedPadding(byte[] array, int padding = 16)
        {
            var ms = new MemoryStream();
            var serToSha1 = SHA1.HashData(array);
            ms.Write(serToSha1);
            ms.Write(array);
            if (ms.Length % padding == 0)
            {
                return ms.ToArray();
            }

            var b = new byte[padding - ms.Length % padding];
            new Random().NextBytes(b);
            ms.Write(b);

            return ms.ToArray();
        }

        public static byte[] ShaBigIntegers(BigInteger bigInteger, BigInteger otherBigInteger)
        {
            using var ms = new MemoryStream();
            ms.Write(bigInteger.ToByteArray());
            ms.Write(otherBigInteger.ToByteArray());
            return SHA1.HashData(ms.ToArray());
        }
    }
}