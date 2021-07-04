using System;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Security.Cryptography;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;

namespace CatraProto.Client.Crypto.KeyExchange
{
    public class KeyExchangeChecks
    {
        public static void CheckNonce(BigInteger bigInteger, BigInteger otherBigInteger)
        {
            if (otherBigInteger != bigInteger)
            {
                throw new SecurityException("Nonce mismatch");
            }
        }

        public static void CheckHashData(byte[] sha, ServerDHInnerData data)
        {
            if(!sha.SequenceEqual(SHA1.HashData(data.ToArray(MergedProvider.Singleton))))
            {
                throw new SecurityException("Hash mismatch");
            }
        }
    }
}