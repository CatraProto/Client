using System;
using System.Collections.Generic;
using System.Text;

namespace CatraProto.Client.UnitTests.Crypto.Aes
{
    public class TestVector
    {
        public static List<TestVector> GetVectors() => new List<TestVector>
        {
            new TestVector(
                GenerateArrayFromHex("0000000000000000000000000000000000000000000000000000000000000000"),
                GenerateArrayFromHex("000102030405060708090A0B0C0D0E0F"),
                GenerateArrayFromHex("000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F"),
                GenerateArrayFromHex("1A8519A6557BE652E9DA8E43DA4EF4453CF456B4CA488AA383C79C98B34797CB")
            ),
            new TestVector(
                GenerateArrayFromHex("99706487A1CDE613BC6DE0B6F24B1C7AA448C8B9C3403E3467A8CAD89340F53B"),
                GenerateArrayFromHex("5468697320697320616E20696D706C65"),
                GenerateArrayFromHex("6D656E746174696F6E206F6620494745206D6F646520666F72204F70656E5353"),
                GenerateArrayFromHex("4C2E204C6574277320686F70652042656E20676F74206974207269676874210A")
            )
        };

        public byte[] PlainText { get; set; }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public byte[] Result { get; set; }

        public TestVector(byte[] plainText, byte[] key, byte[] iv, byte[] result)
        {
            PlainText = plainText;
            Key = key;
            IV = iv;
            Result = result;
        }

        public static byte[] GenerateArrayFromHex(string hexValues)
        {
            byte[] bytes = new byte[hexValues.Length / 2];
            int[] hexValue =
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
            };

            for (int x = 0, i = 0; i < hexValues.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)(hexValue[char.ToUpper(hexValues[i + 0]) - '0'] << 4 | hexValue[char.ToUpper(hexValues[i + 1]) - '0']);
                Console.WriteLine(bytes[x] + ",");
            }
            return bytes;
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte b in bytes)
            {
                result.Append(HexAlphabet[b >> 4]);
                result.Append(HexAlphabet[b & 0xF]);
            }

            return result.ToString();
        }
    }
}