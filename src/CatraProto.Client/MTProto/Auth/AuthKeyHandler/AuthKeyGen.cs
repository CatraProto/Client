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
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    static class AuthKeyGen
    {
        public static async Task<AuthKeySuccess> EnsureComputeAsync(int duration, Api api, ILogger logger, CancellationToken token = default)
        {
            while (true)
            {
                var compute = await ComputeAuthKey(duration, api, logger, token);
                if (compute is AuthKeySuccess success)
                {
                    return success;
                }
                else
                {
                    logger.Warning("AuthKey generation failed due to {Error}, retrying in 2 seconds...", ((AuthKeyFail)compute).Error);
                    await Task.Delay(TimeSpan.FromSeconds(2), token);
                }
            }
        }

        public static async Task<AuthKeyResult> ComputeAuthKey(int duration, Api api, ILogger logger, CancellationToken cancellationToken = default)
        {
            try
            {
                var isPermanent = duration <= 0;
                logger.Information("Generating auth {Type} key", isPermanent ? "permanent" : "temporary");
                var nonce = BigIntegerTools.GenerateBigInt(128);
                var reqPq = await api.MtProtoApi.ReqPqMultiAsync(nonce, cancellationToken: cancellationToken);
                if (!reqPq.RpcCallFailed)
                {
                    KeyExchangeChecks.CheckNonce(nonce, reqPq.Response!.Nonce);

                    var serverNonce = reqPq.Response.ServerNonce;
                    var pq = reqPq.Response.Pq;

                    logger.Verbose("Received ServerNonce from server with value {SNonce} and Pq with value {Pq}", serverNonce, pq);
                    logger.Verbose("Server RSA Fingerprints: {Fingerprints}", reqPq.Response.ServerPublicKeyFingerprints);
                    if (!Rsa.FindByFingerprints(reqPq.Response.ServerPublicKeyFingerprints, out var found))
                    {
                        logger.Error("None of the fingerprints provided were found in the array of RSA keys");
                        return new AuthKeyFail(Errors.RsaNotFound);
                    }

                    var rsaKey = found.Item2;
                    var (p, q) = CryptoTools.GetFastPq(BitConverter.ToUInt64(pq.Reverse().ToArray()));
                    var newNonce = BigIntegerTools.GenerateBigInt(256);

                    PQInnerDataBase toHash = isPermanent ? new PQInnerData() : new PQInnerDataTemp { ExpiresIn = duration };
                    toHash.Nonce = nonce;
                    toHash.ServerNonce = reqPq.Response.ServerNonce;
                    toHash.NewNonce = newNonce;
                    toHash.P = p;
                    toHash.Q = q;
                    toHash.Pq = reqPq.Response.Pq;


                    var encryptedData = rsaKey.EncryptData(Hashing.ComputeDataHashedFilling(toHash, MergedProvider.Singleton));
                    rsaKey.Dispose();

                    logger.Verbose("Sending ReqDHParams request...");
                    var reqDh = await api.MtProtoApi.ReqDHParamsAsync(nonce, serverNonce, p, q, found.Item1, encryptedData, cancellationToken: cancellationToken);
                    if (!reqDh.RpcCallFailed)
                    {
                        if (reqDh.Response is ServerDHParamsOk ok)
                        {
                            logger.Verbose("Server dh params ok, checking nonce and computing aes iv and key...");
                            KeyExchangeChecks.CheckNonce(nonce, ok.Nonce);
                            var aesKey = KeyExchangeTools.ComputeAesKey(serverNonce, newNonce);
                            var aesIv = KeyExchangeTools.ComputeAesIv(serverNonce, newNonce);
                            using var igeEncryptor = new IgeEncryptor(aesKey, aesIv);
                            var serverDhInnerData = KeyExchangeTools.DecryptMessage(igeEncryptor, ok.EncryptedAnswer, out var sha).ToObject<ServerDHInnerData>(MergedProvider.Singleton);

                            logger.Verbose("Message decrypted, checking serverDhInnerData integrity");
                            KeyExchangeChecks.CheckHashData(sha, serverDhInnerData);

                            logger.Verbose("Checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", serverDhInnerData.Nonce, nonce, serverDhInnerData.ServerNonce, serverNonce);
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

                            logger.Verbose("gbMod computed, sending setClientDHParams...");
                            var setDhClient = await api.MtProtoApi.SetClientDHParamsAsync(nonce, serverNonce, encryptedInnerData, cancellationToken: cancellationToken);
                            if (!setDhClient.RpcCallFailed)
                            {
                                if (setDhClient.Response is DhGenOk dhGenOk)
                                {
                                    logger.Verbose("Received dhGenOk checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", dhGenOk.Nonce, nonce, dhGenOk.ServerNonce, serverNonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.Nonce, nonce);
                                    KeyExchangeChecks.CheckNonce(dhGenOk.ServerNonce, serverNonce);

                                    var rawKey = CryptoTools.RemoveStartingZeros(BigInteger.ModPow(new BigInteger(zeroByte.Concat(serverDhInnerData.GA).ToArray(), isBigEndian: true), b, dhPrime).ToByteArray(isBigEndian: true));
                                    Array.Resize(ref rawKey, 256);
                                    var authKeyId = BitConverter.ToInt64(SHA1.HashData(rawKey).TakeLast(8).ToArray());
                                    var serverSalt = BitConverter.ToInt64(KeyExchangeTools.ComputeServerSalt(serverNonce, newNonce));

                                    logger.Information("Nonce and serverNonce match, AuthKey successfully generated. AuthKeyId: {Id} ServerSalt: {Salt}", authKeyId, serverSalt);
                                    return new AuthKeySuccess(rawKey, authKeyId, serverSalt, duration > 0 ? (int)DateTimeOffset.Now.Add(TimeSpan.FromSeconds(duration)).ToUnixTimeSeconds() : null);
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
                logger.Error(e, "Unexpected exception thrown");
                return new AuthKeyFail(Errors.UnexpectedError);
            }

            return new AuthKeyFail(Errors.UnexpectedError);
        }
    }
}