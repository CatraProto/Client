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
        public byte[]? RawAuthKey { get; private set; }
        public long? AuthKeyId { get; set; }
        public long? ServerSalt { get; private set; }
        private readonly ILogger _logger;
        private readonly Api _api;

        public AuthKey(Api api, ILogger logger)
        {
            _logger = logger.ForContext<AuthKey>();
            _api = api;
        }

        public async Task<AuthKeyResult> ComputeAuthKey(int duration, CancellationToken cancellationToken = default)
        {
            try
            {
                var isPermanent = duration <= 0;
                _logger.Information("Generating auth {Type} key", isPermanent ? "permanent" : "temporary");
                var nonce = BigIntegerTools.GenerateBigInt(128, true);
                var reqPq = await _api.MtProtoApi.ReqPqMultiAsync(nonce, cancellationToken: cancellationToken);
                if (!reqPq.RpcCallFailed)
                {
                    KeyExchangeChecks.CheckNonce(nonce, reqPq.Response!.Nonce);

                    var serverNonce = reqPq.Response.ServerNonce;
                    var pq = reqPq.Response.Pq;

                    _logger.Information("Received ServerNonce from server with value {SNonce} and Pq with value {Pq}", serverNonce, pq);
                    _logger.Information("Server RSA Fingerprints: {Fingerprints}", reqPq.Response.ServerPublicKeyFingerprints);
                    if (!Rsa.FindByFingerprints(reqPq.Response.ServerPublicKeyFingerprints, out var found))
                    {
                        _logger.Error("None of the fingerprints provided were found in the array of RSA keys");
                        return new AuthKeyFail(Errors.RsaNotFound);
                    }

                    var rsaKey = found!.Item2;
                    var (p, q) = CryptoTools.GetFastPq(BitConverter.ToUInt64(pq.Reverse().ToArray()));
                    var newNonce = BigIntegerTools.GenerateBigInt(256, true);

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
                    var reqDh = await _api.MtProtoApi.ReqDHParamsAsync(nonce, serverNonce, p, q, found.Item1, encryptedData, cancellationToken: cancellationToken);
                    if (!reqDh.RpcCallFailed)
                    {
                        if (reqDh.Response is ServerDHParamsOk ok)
                        {
                            _logger.Information("Server dh params ok, checking nonce and computing aes iv and key...");
                            KeyExchangeChecks.CheckNonce(nonce, ok.Nonce);
                            var aesKey = KeyExchangeTools.ComputeAesKey(serverNonce, newNonce);
                            var aesIv = KeyExchangeTools.ComputeAesIv(serverNonce, newNonce);
                            using var igeEncryptor = new IgeEncryptor(aesKey, aesIv);
                            var serverDhInnerData = KeyExchangeTools.DecryptMessage(igeEncryptor, ok.EncryptedAnswer, out var sha).ToObject<ServerDHInnerData>(MergedProvider.Singleton);

                            _logger.Information("Message decrypted, checking serverDhInnerData integrity");
                            KeyExchangeChecks.CheckHashData(sha, serverDhInnerData);

                            _logger.Information("Checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", serverDhInnerData.Nonce, nonce, serverDhInnerData.ServerNonce, serverNonce);
                            KeyExchangeChecks.CheckNonce(serverDhInnerData.Nonce, nonce);
                            KeyExchangeChecks.CheckNonce(serverDhInnerData.ServerNonce, serverNonce);

                            var zeroByte = new byte[] { 0x00 };
                            var b = BigIntegerTools.GenerateBigInt(2048, true, true);
                            var dhPrime = new BigInteger(zeroByte.Concat(serverDhInnerData.DhPrime).ToArray(), isBigEndian: true);
                            var gbMod = BigInteger.ModPow(serverDhInnerData.G, b, dhPrime).ToByteArray(isBigEndian: true);

                            var clientDhInnerData = new ClientDHInnerData
                            {
                                Nonce = nonce,
                                ServerNonce = serverNonce,
                                GB = gbMod
                            };
                            var hashedPadding = Hashing.ComputeDataHashedPadding(clientDhInnerData, MergedProvider.Singleton);
                            var encryptedInnerData = igeEncryptor.Encrypt(hashedPadding);

                            _logger.Information("gbMod computed, sending setClientDHParams...");
                            var setDhClient = await _api.MtProtoApi.SetClientDHParamsAsync(nonce, serverNonce, encryptedInnerData, cancellationToken: cancellationToken);
                            if (!setDhClient.RpcCallFailed)
                            {
                                if (setDhClient.Response is DhGenOk dhGenOk)
                                {
                                    _logger.Information("Received dhGenOk checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", dhGenOk.Nonce, nonce, dhGenOk.ServerNonce, serverNonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.Nonce, nonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.ServerNonce, serverNonce);

                                    RawAuthKey = CryptoTools.RemoveFirstBytes(BigInteger.ModPow(new BigInteger(zeroByte.Concat(serverDhInnerData.GA).ToArray(), isBigEndian: true), b, dhPrime).ToByteArray(isBigEndian: true));
                                    AuthKeyId = BitConverter.ToInt64(SHA1.HashData(RawAuthKey).TakeLast(8).ToArray());
                                    ServerSalt = BitConverter.ToInt64(KeyExchangeTools.ComputeServerSalt(serverNonce, newNonce));

                                    _logger.Information("Nonce and serverNonce match, AuthKey successfully generated. AuthKey: {Key} AuthKeyId: {Id} ServerSalt: {Salt}", RawAuthKey, AuthKeyId, ServerSalt);
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
                        _logger.Error("Received {ErrorCode} as a result of ReqDhParams", reqDh.Error!.ErrorCode);
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
            catch (Exception e)
            {
                _logger.Error(e, "Unexpected exception thrown");
                return new AuthKeyFail(Errors.UnexpectedError);
            }

            return new AuthKeyFail(Errors.UnexpectedError);
        }

        public IgeEncryptor CreateEncryptorV2(byte[] msgKey, bool fromClient)
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

        public IgeEncryptor CreateEncryptorV1(byte[] msgKey, bool fromClient)
        {
            var x = fromClient ? 0 : 8;
            if (RawAuthKey == null)
            {
                throw new Exception("AuthKey must be generated first");
            }

            var sha1A = SHA1.HashData(msgKey.Concat(RawAuthKey.Skip(x).Take(32)).ToArray());
            var sha1B = SHA1.HashData(RawAuthKey.Skip(32 + x).Take(16).Concat(msgKey).Concat(RawAuthKey.Skip(48 + x).Take(16)).ToArray());
            var sha1C = SHA1.HashData(RawAuthKey.Skip(64 + x).Take(32).Concat(msgKey).ToArray());
            var sha1D = SHA1.HashData(msgKey.Concat(RawAuthKey.Skip(96 + x).Take(32)).ToArray());

            var aesKey = sha1A.Take(8).Concat(sha1B.Skip(8).Take(12).Concat(sha1C.Skip(4).Take(12))).ToArray();
            var aesIv = sha1A.Skip(8).Take(12).Concat(sha1B.Take(8)).Concat(sha1C.Skip(16).Take(4)).Concat(sha1D.Take(8)).ToArray();
            return new IgeEncryptor(aesKey, aesIv);
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
    }
}