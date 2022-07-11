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
using CatraProto.Client.Crypto.AesEncryption;
using CatraProto.TL;

namespace CatraProto.Client.Crypto.KeyExchange
{
    internal static class KeyExchangeTools
    {
        public static byte[] ComputeAesKey(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var newNonceFirst = Hashing.ShaBigIntegers(newNonce, serverNonce);
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);

            ms.Write(newNonceFirst);
            ms.Write(serverNonceFirst.Take(12).ToArray());
            return ms.ToArray();
        }

        public static byte[] ComputeAesIv(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);
            var newNonceOnly = Hashing.ShaBigIntegers(newNonce, newNonce);

            ms.Write(serverNonceFirst.Skip(12).Take(8).ToArray());
            ms.Write(newNonceOnly);
            ms.Write(newNonce.ToByteArray().Take(4).ToArray());
            return ms.ToArray();
        }

        public static byte[] DecryptMessage(IgeEncryptor encryptor, byte[] data, out byte[] sha)
        {
            var decrypted = encryptor.Decrypt(data);
            var reader = new BinaryReader(decrypted.ToMemoryStream());
            sha = reader.ReadBytes(20);
            return reader.ReadBytes(decrypted.Length - 20);
        }

        public static byte[] ComputeServerSalt(BigInteger serverNonce, BigInteger newNonce)
        {
            return CryptoTools.XorBlock(newNonce.ToByteArray().Take(8).ToArray(), serverNonce.ToByteArray().Take(8).ToArray());
        }
    }
}