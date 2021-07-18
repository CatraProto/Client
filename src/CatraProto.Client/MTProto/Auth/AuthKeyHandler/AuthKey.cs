using System;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.Crypto.KeyExchange;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler.Results;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class AuthKey : ISessionSerializer
    {
        public byte[] RawAuthKey { get; private set; }
        public long AuthKeyId { get; set; }
        public long ServerSalt { get; private set; }
        private ILogger _logger;
        private Api _api;

        public AuthKey(Api api, ILogger logger)
        {
            _logger = logger.ForContext<AuthKey>();
            _api = api;
        }

        public void Read(Reader reader)
        {
            RawAuthKey = reader.Read<byte[]>();
            AuthKeyId = reader.Read<long>();
            ServerSalt = reader.Read<long>();
        }

        public void Save(Writer writer)
        {
            writer.Write(RawAuthKey);
            writer.Write(AuthKeyId);
            writer.Write(ServerSalt);
        }
        
        public async Task<AuthKeyResult> ComputeAuthKey(int duration, CancellationToken cancellationToken = default)
        {
            try
            {
                var isPermanent = duration <= 0;
                _logger.Information("Generating auth {Type} key", isPermanent ? "permanent" : "temporary");
                var nonce = CryptoTools.GenerateBigInt(128);
                var reqPq = await _api.MtProtoApi.ReqPqMultiAsync(nonce, cancellationToken);
                if (!reqPq.RpcCallFailed)
                {
                    KeyExchangeChecks.CheckNonce(nonce, reqPq.Response.Nonce);

                    var serverNonce = reqPq.Response.ServerNonce;
                    var pq = reqPq.Response.Pq;

                    _logger.Information("Received ServerNonce from server with value {SNonce} and Pq with value {Pq}", serverNonce, pq);
                    _logger.Information("Server RSA Fingerprints: {Fingerprints}", reqPq.Response.ServerPublicKeyFingerprints);
                    var (foundKey, rsaKey) = Rsa.FindByFingerprints(reqPq.Response.ServerPublicKeyFingerprints);
                    if (rsaKey == null)
                    {
                        _logger.Error("None of the fingerprints provided were found in the array of RSA keys");
                        return new AuthKeyFail(Errors.RsaNotFound);
                    }

                    var (p, q) = CryptoTools.GetFastPq(BitConverter.ToUInt64(pq.Reverse().ToArray()));
                    var newNonce = CryptoTools.GenerateBigInt(256);

                    PQInnerDataBase toHash = isPermanent ? new PQInnerData() : new PQInnerDataTemp { ExpiresIn = duration };
                    toHash.Nonce = nonce;
                    toHash.ServerNonce = reqPq.Response.ServerNonce;
                    toHash.NewNonce = newNonce;
                    toHash.P = p;
                    toHash.Q = q;
                    toHash.Pq = reqPq.Response.Pq;
                    

                    var encryptedData = rsaKey.EncryptData(Hashing.ComputeDataHashedFilling(toHash, MergedProvider.Singleton));
                    rsaKey.Dispose();

                    _logger.Information("Sending ReqDHParams request...");
                    var reqDh = await _api.MtProtoApi.ReqDHParamsAsync(nonce, serverNonce, p, q, foundKey, encryptedData,
                        cancellationToken);
                    if (!reqDh.RpcCallFailed)
                    {
                        if (reqDh.Response is ServerDHParamsOk ok)
                        {
                            _logger.Information("Server dh params ok, checking nonce and computing aes iv and key...");
                            KeyExchangeChecks.CheckNonce(nonce, ok.Nonce);
                            var aesKey = KeyExchangeTools.ComputeAesKey(serverNonce, newNonce);
                            var aesIv = KeyExchangeTools.ComputeAesIv(serverNonce, newNonce);
                            using var igeEncryptor = new IgeEncryptor(aesKey, aesIv);
                            var serverDhInnerData = KeyExchangeTools
                                .DecryptMessage(igeEncryptor, ok.EncryptedAnswer, out var sha)
                                .ToObject<ServerDHInnerData>(MergedProvider.Singleton);

                            _logger.Information("Message decrypted, checking serverDhInnerData integrity");
                            KeyExchangeChecks.CheckHashData(sha, serverDhInnerData);
                            
                            _logger.Information("Checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})",
                                serverDhInnerData.Nonce, nonce, serverDhInnerData.ServerNonce, serverNonce);
                            KeyExchangeChecks.CheckNonce(serverDhInnerData.Nonce, nonce);
                            KeyExchangeChecks.CheckNonce(serverDhInnerData.ServerNonce, serverNonce);

                            var zeroByte = new byte[] { 0x00 };
                            var b = CryptoTools.GenerateBigInt(2048, true, true);
                            var dhPrime = new BigInteger(zeroByte.Concat(serverDhInnerData.DhPrime).ToArray(), isBigEndian: true);
                            var gbMod = BigInteger
                                .ModPow(serverDhInnerData.G, b, dhPrime)
                                .ToByteArray(isBigEndian: true);

                            var clientDhInnerData = new ClientDHInnerData
                            {
                                Nonce = nonce,
                                ServerNonce = serverNonce,
                                GB = gbMod
                            };
                            var hashedPadding = Hashing.ComputeDataHashedPadding(clientDhInnerData, MergedProvider.Singleton);
                            var encryptedInnerData = igeEncryptor.Encrypt(hashedPadding);
                
                            _logger.Information("gbMod computed, sending setClientDHParams...");
                            var setDhClient = await _api.MtProtoApi.SetClientDHParamsAsync(nonce, serverNonce, encryptedInnerData, cancellationToken);
                            if (!setDhClient.RpcCallFailed)
                            {
                                if (setDhClient.Response is DhGenOk dhGenOk)
                                {
                                    _logger.Information("Received dhGenOk checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})",
                                        dhGenOk.Nonce,
                                        nonce, dhGenOk.ServerNonce, serverNonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.Nonce, nonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.ServerNonce, serverNonce);
                                    
                                    RawAuthKey = CryptoTools.RemoveFirstBytes(BigInteger
                                        .ModPow(new BigInteger(zeroByte.Concat(serverDhInnerData.GA).ToArray(), isBigEndian: true), b, dhPrime)
                                        .ToByteArray(isBigEndian: true));
                                    AuthKeyId = BitConverter.ToInt64(SHA1.HashData(RawAuthKey).TakeLast(8).ToArray());
                                    ServerSalt = BitConverter.ToInt64(KeyExchangeTools.ComputeServerSalt(serverNonce, newNonce));
                                    
                                    _logger.Information(
                                        "Nonce and serverNonce match, AuthKey successfully generated. AuthKey: {Key} AuthKeyId: {Id} ServerSalt: {Salt}",
                                        RawAuthKey, AuthKeyId, ServerSalt);
                                    return new AuthKeySuccess();
                                }
                                else
                                {
                                    return new AuthKeyFail(Errors.DhGenFail);
                                }
                            }
                            else
                            {
                                return new AuthKeyFail(Errors.ServerCallFail);
                            }
                        }
                        else
                        {
                            return new AuthKeyFail(Errors.ServerDhFail);
                        }
                    }
                    else
                    {
                        _logger.Error("Received {ErrorCode} as a result of ReqDhParams", reqDh.Error.ErrorCode);
                        return new AuthKeyFail(Errors.ServerCallFail);
                    }
                }
                else
                {
                    return new AuthKeyFail(Errors.ServerCallFail);
                }
            }
            catch (SecurityException e)
            {
                switch (e.Message)
                {
                    case "Nonce mismatch":
                        return new AuthKeyFail(Errors.NonceMismatch);
                    case "Hash mismatch":
                        return new AuthKeyFail(Errors.HashMismatch);
                }
            }
            catch(Exception e)
            {
                _logger.Error(e, "Unexpected exception thrown");
                return new AuthKeyFail(Errors.UnexpectedError);
            }
            return new AuthKeyFail(Errors.UnexpectedError);
        }

        public IgeEncryptor CreateEncryptor(byte[] msgKey, bool fromClient)
        {
            var x = fromClient ? 0 : 8;
            if (RawAuthKey == null)
            {
                throw new Exception("AuthKey must be generated first");
            }

            var sha256A = SHA256.HashData(msgKey.Concat(RawAuthKey.Skip(x).Take(36)).ToArray());
            var sha256B = SHA256.HashData(RawAuthKey.Skip(40 + x).Take(36).Concat(msgKey).ToArray());
            var aesKey = sha256A.Take(8).Concat(sha256B.Skip(8).Take(16).Concat(sha256A.Skip(24).Take(8))).ToArray();
            var aesIv = sha256B.Take(8).Concat(sha256A.Skip(8).Take(16).Concat(sha256B.Skip(24).Take(8))).ToArray();
            return new IgeEncryptor(aesKey, aesIv);
        }
    }
}