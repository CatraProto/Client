using System.Linq;
using System.Numerics;

namespace CatraProto.Client.Crypto
{
    static class BigIntegerTools
    {
        public static BigInteger GenerateBigInt(int size, bool positive = false, bool isBigEndian = false)
        {
            var buffer = CryptoTools.GenerateRandomBytes(size / 8);
            if (buffer[^1] == 255)
            {
                buffer[^1] = 254;
            }

            if (positive)
            {
                var zeroByte = new byte[] { 0x00 };
                buffer = isBigEndian ? zeroByte.Concat(buffer).ToArray() : buffer.Concat(zeroByte).ToArray();
            }


            return new BigInteger(buffer, false, isBigEndian);
        }

        public static BigInteger UnsignedBigIntFromBytes(byte[] bytes, bool isBigEndian = false)
        {
            var zeroByte = new byte[] { 0x00 };
            bytes = isBigEndian ? zeroByte.Concat(bytes).ToArray() : bytes.Concat(zeroByte).ToArray();
            return new BigInteger(bytes, false, isBigEndian);
        }
    }
}