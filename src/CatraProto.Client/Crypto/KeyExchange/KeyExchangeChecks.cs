using System;
using System.Numerics;

namespace CatraProto.Client.Crypto.KeyExchange
{
    public class KeyExchangeChecks
    {
        public static void CheckNonce(BigInteger bigInteger, BigInteger otherBigInteger)
        {
            if (otherBigInteger != bigInteger)
            {
                throw new Exception("Nonce mismatch");
            }
        }
    }
}