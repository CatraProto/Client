using System;
using System.Threading.Tasks;

namespace CatraProto.Client.MTProto
{
    internal class AuthKey
    {
        /// <summary>
        ///     Whether this AuthKey is permanent or temporary
        /// </summary>
        public bool IsPermanent { get; init; }

        /// <summary>
        ///     Expiration date of the AuthKey.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the AuthKey is permanent</exception>
        public DateTimeOffset ExpiresIn
        {
            get
            {
                if (IsPermanent)
                    throw new InvalidOperationException("This AuthKey is not temporary, therefore it has no expire date");
                return _expiresIn;
            }
        }

        private DateTimeOffset _expiresIn;

        public AuthKey(byte[] authkey, bool isPermanent)
        {
            IsPermanent = isPermanent;
        }


        private async Task GenerateAuthKey()
        {
            /*
            var reqpq = new ReqPq
            {
                Nonce = TlBigInteger.RandomBigInteger()
            };

            var result = await connection.SendStreamUnencryptedRequest<ResPQ>(reqpq);
            if (result.Nonce.ToBigInteger == reqpq.Nonce.ToBigInteger)
            {
                var pq = BitConverter.ToUInt64(result.Pq.Reverse().ToArray(), 0);
                var (p, q) = MiscTools.GetFastPQ(pq);
                var pBytes = FromUInt64(p);
                var qBytes = FromUInt64(q);
                var rsaFingerPrint = await Rsa.CalculateRsaFingerprint(Rsa.RSAKeys[0]);
                var newNonce = TlBigInteger.privateRandomBigInteger(256);
                var innerData = new PQInnerData
                {
                    Nonce = result.Nonce,
                    ServerNonce = result.ServerNonce,
                    P = pBytes,
                    Q = qBytes,
                    Pq = result.Pq,
                    NewNonce = newNonce
                };
                
                var reqDhParams = new ReqDHParams
                {
                    Nonce = result.Nonce,
                    ServerNonce = result.ServerNonce,
                    P = pBytes,
                    Q = qBytes,
                    PublicKeyFingerprint = result.ServerPublicKeyFingerprints[0],
                    EncryptedData = Rsa.EncryptData(HandshakingTools.GenDataHash(innerData), MTProtoRSA.RSAKeys[0])
                };
                ImportantNotice("SPKF: " + result.ServerPublicKeyFingerprints[0] + " Calculated: " + rsaFingerPrint);
                var dhResponse = await connection.SendStreamUnencryptedRequest<ServerDHParamsBase>(reqDhParams);
                
                if (dhResponse is ServerDHParamsOk paramsOk)
                {
                    var answer = paramsOk.EncryptedAnswer;
                }
                else
                {
                    //TODO: EXCEPTION THROWING
                }
            }
            */
        }
    }
}