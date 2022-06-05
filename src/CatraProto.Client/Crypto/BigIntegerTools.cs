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

using System.Linq;
using System.Numerics;

namespace CatraProto.Client.Crypto
{
    internal static class BigIntegerTools
    {
        public static BigInteger GenerateBigInt(int size, bool positive = false, bool isBigEndian = false)
        {
            var buffer = CryptoTools.GenerateRandomBytes(size / 8);
            if (buffer[^1] == 255)
            {
                buffer[^1] = 254;
            }

            return new BigInteger(buffer, positive, isBigEndian);
        }

        public static BigInteger UnsignedBigIntFromBytes(byte[] bytes, bool isBigEndian = false)
        {
            var zeroByte = new byte[] { 0x00 };
            bytes = isBigEndian ? zeroByte.Concat(bytes).ToArray() : bytes.Concat(zeroByte).ToArray();
            return new BigInteger(bytes, false, isBigEndian);
        }
    }
}