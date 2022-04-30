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

using System.IO;
using System.Linq;
using System.Numerics;

namespace CatraProto.Client.Crypto
{
    public class MTProto
    {
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