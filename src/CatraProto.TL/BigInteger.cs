namespace CatraProto.TL
{
    internal static class BigInteger
    {
        internal static System.Numerics.BigInteger ReadBytes(int bitSize, Reader reader)
        {
            var byteCount = bitSize / 8;
            var bytes = new byte[byteCount];

            for (var i = 0; i < byteCount; i++)
            {
                bytes[i] = reader.Read<byte>();
            }

            return new System.Numerics.BigInteger(bytes);
        }
    }
}