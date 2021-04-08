using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CatraProto.Client.Crypto.AES
{
    class IGE
    {
        public static void Decrypt()
        {
            var toEncrypt = GenerateArrayFromHex("00000000 00000000 00000000 0000000000000000 00000000 00000000 00000000");
            var iv = GenerateArrayFromHex("00010203 04050607 08090A0B 0C0D0E0F 10111213 14151617 18191A1B 1C1D1E1F");
            var key = GenerateArrayFromHex("00010203 04050607 08090A0B 0C0D0E0F");
            var iv1 = iv.Take(8).ToArray();
            var iv2 = iv.TakeLast(8).ToArray();
            var previousBlocks = new List<byte>();
            
            if (toEncrypt.Length % 16 != 0)
            {
                throw new ArgumentException("Plaintext must be a multiple of 16");
            }
            
            for (var i = 0; i < toEncrypt.Length; i++)
            {
                var plainByte = toEncrypt[i];
            }
        }

        public static byte[] GenerateArrayFromHex(string hexValues)
        {
            var array = new List<byte>();
            foreach (var hex in hexValues.Split(" "))
            {
                var number = int.Parse(hex, NumberStyles.HexNumber);
                foreach (var b in BitConverter.GetBytes(number))
                {
                    array.Add(b);
                }
            }

            return array.ToArray();
        }
    }
}