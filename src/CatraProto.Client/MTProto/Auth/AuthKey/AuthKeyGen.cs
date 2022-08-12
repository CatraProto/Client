/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Crypto;
using CatraProto.Client.Crypto.AesEncryption;
using CatraProto.Client.Crypto.KeyExchange;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKey
{
    internal class AuthKeyGen
    {
        private readonly ILogger _logger;
        public AuthKeyGen(ILogger logger)
        {
            _logger = logger.ForContext<AuthKeyGen>();
        }

        public async Task<AuthKeyObject?> ComputeAuthKey(int duration, MTProtoState state, CancellationToken cancellationToken = default)
        {
            var api = state.Api;
            var isPermanent = duration <= 0;
            _logger.Information("Generating auth {Type} key", isPermanent ? "permanent" : "temporary");
            var nonce = BigIntegerTools.GenerateBigInt(128);
            var reqPq = await api.MtProtoApi.ReqPqMultiAsync(nonce, cancellationToken: cancellationToken);
            if (reqPq.RpcCallFailed)
            {
                return null;
            }

            if (!CheckNonce(nonce, reqPq.Response!.Nonce))
            {
                return null;
            }

            var serverNonce = reqPq.Response.ServerNonce;
            var pq = reqPq.Response.Pq;

            _logger.Verbose("Received ServerNonce from server with value {SNonce} and Pq with value {Pq}", serverNonce, pq);
            _logger.Verbose("Server RSA Fingerprints: {Fingerprints}", reqPq.Response.ServerPublicKeyFingerprints);
            if (!Rsa.FindByFingerprints(reqPq.Response.ServerPublicKeyFingerprints, out var found))
            {
                _logger.Error("None of the fingerprints provided were found in the array of RSA keys");
                return null;
            }

            using var rsaKey = found.Item2;
            var (p, q) = CryptoTools.GetFastPq(BitConverter.ToUInt64(pq.Reverse().ToArray()));
            var newNonce = BigIntegerTools.GenerateBigInt(256);

            PQInnerDataBase data = isPermanent ? new PQInnerDataDc() : new PQInnerDataTempDc { ExpiresIn = duration };
            data.Nonce = nonce;
            data.ServerNonce = reqPq.Response.ServerNonce;
            data.NewNonce = newNonce;
            data.P = p;
            data.Q = q;
            data.Pq = reqPq.Response.Pq;
            data.Dc = state.ConnectionInfo.DcId;
            if (state.ConnectionInfo.Test)
            {
                data.Dc += 10000;
            }

            var trySer = data.ToArray(MergedProvider.Singleton, out var toArr);
            if (trySer.IsError)
            {
                _logger.Error("Failed to serialize PQInnerData. Error: {Error}", trySer.GetError().Error);
                return null;
            }

            var encryptedData = rsaKey.EncryptData(toArr);
            _logger.Verbose("Sending ReqDHParams request...");
            var reqDh = await api.MtProtoApi.ReqDHParamsAsync(nonce, serverNonce, p, q, found.Item1, encryptedData, cancellationToken: cancellationToken);
            if (reqDh.RpcCallFailed)
            {
                return null;
            }

            if (reqDh.Response is ServerDHParamsOk ok)
            {
                _logger.Verbose("Server dh params ok, checking nonce and computing aes iv and key...");
                if (!CheckNonce(nonce, ok.Nonce))
                {
                    return null;
                }

                var aesKey = KeyExchangeTools.ComputeAesKey(serverNonce, newNonce);
                var aesIv = KeyExchangeTools.ComputeAesIv(serverNonce, newNonce);
                using var igeEncryptor = new IgeEncryptor(aesKey, aesIv);
                var deserializeServerDhInnerData = KeyExchangeTools.DecryptMessage(igeEncryptor, ok.EncryptedAnswer, out var sha).ToObject<ServerDHInnerData>(MergedProvider.Singleton);
                if (deserializeServerDhInnerData.IsError)
                {
                    _logger.Error("Could not deserialized received encrypted payload");
                    return null;
                }

                var serverDhInnerData = deserializeServerDhInnerData.Value;
                state.MessageIdsHandler.SetTimeDifference(serverDhInnerData.ServerTime);
                _logger.Verbose("Message decrypted, checking serverDhInnerData integrity");
                if (!CheckNonce(nonce, serverDhInnerData.Nonce) || !CheckNonce(serverNonce, serverDhInnerData.ServerNonce) || !CheckHashData(sha, serverDhInnerData))
                {
                    return null;
                }

                var b = BigIntegerTools.GenerateBigInt(2048, true, true);
                var dhPrime = new BigInteger(serverDhInnerData.DhPrime, true, true);

                if (!Crypto.MTProto.CheckCyclicSubgroup(dhPrime, serverDhInnerData.G, _logger))
                {
                    _logger.Error("Cyclic subgroup failed. DhPrime: {DhPrime}, G: {G}", dhPrime, serverDhInnerData.G);
                    return null;
                }

                if (!Crypto.MTProto.KnownPrimes.Contains(dhPrime) || !Crypto.MTProto.CheckRangeDhPrime(dhPrime, _logger) && (!Crypto.MTProto.CheckPrimeness(dhPrime, logger: _logger) || !Crypto.MTProto.CheckPrimeness(dhPrime - 1 / 2, logger: _logger)))
                {
                    return null;
                }

                var gb = BigInteger.ModPow(serverDhInnerData.G, b, dhPrime);
                var gbArray = gb.ToByteArray(isBigEndian: true);
                var ga = new BigInteger(serverDhInnerData.GA, true, true);
                if (!CheckGLength(serverDhInnerData.G, dhPrime, "g") || !CheckGLength(ga, dhPrime, "g_a") || !CheckGLength(gb, dhPrime, "g_b"))
                {
                    return null;
                }

                if (!CheckGABLength(ga, dhPrime, "g_a") || !CheckGABLength(gb, dhPrime, "g_b"))
                {
                    return null;
                }

                var clientDhInnerData = new ClientDHInnerData
                {
                    Nonce = nonce,
                    ServerNonce = serverNonce,
                    GB = gbArray
                };

                var tryGetDh = clientDhInnerData.ToArray(MergedProvider.Singleton, out var clientDhBytes);
                if (tryGetDh.IsError)
                {
                    _logger.Error("Could not TL-Serialize ClientDHInnerData. Error: {Error}", tryGetDh.GetError().Error);
                    return null;
                }

                var hashedPadding = Hashing.ComputeDataHashedPadding(clientDhBytes);
                var encryptedInnerData = igeEncryptor.Encrypt(hashedPadding);
                _logger.Verbose("gbMod computed, sending setClientDHParams...");
                var setDhClient = await api.MtProtoApi.SetClientDHParamsAsync(nonce, serverNonce, encryptedInnerData, cancellationToken: cancellationToken);
                if (setDhClient.RpcCallFailed)
                {
                    return null;
                }

                if (setDhClient.Response is DhGenOk dhGenOk)
                {
                    if (!CheckNonce(nonce, dhGenOk.Nonce) || !CheckNonce(serverNonce, dhGenOk.ServerNonce))
                    {
                        return null;
                    }

                    var rawKey = CryptoTools.SkipFirstNulls(BigInteger.ModPow(new BigInteger(serverDhInnerData.GA, true, true), b, dhPrime).ToByteArray(isBigEndian: true));
                    Array.Resize(ref rawKey, 256);
                    var authKeyId = BitConverter.ToInt64(SHA1.HashData(rawKey).TakeLast(8).ToArray());
                    var serverSalt = BitConverter.ToInt64(KeyExchangeTools.ComputeServerSalt(serverNonce, newNonce));

                    _logger.Information("AuthKey successfully generated. AuthKeyId: {Id} ServerSalt: {Salt}", authKeyId, serverSalt);
                    return new AuthKeyObject(rawKey, authKeyId, serverSalt, duration > 0 ? (int)DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(duration)).ToUnixTimeSeconds() : null);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private bool CheckNonce(BigInteger bigInteger, BigInteger receivedBigInteger)
        {
            if (receivedBigInteger != bigInteger)
            {
                _logger.Error("Nonce mismatch. Received: {Received}, Expected: {Expected}", receivedBigInteger, bigInteger);
                return false;
            }

            _logger.Information("Nonces match. Received: {Received}, Expected: {Expected}", receivedBigInteger, bigInteger);
            return true;
        }

        private bool CheckHashData(byte[] sha, ServerDHInnerData data)
        {
            var trySer = data.ToArray(MergedProvider.Singleton, out var serialized);
            if (trySer.IsError)
            {
                _logger.Error("Could not TL-serialize ServerDHInnerData. Error: {Error}", trySer.GetError().Error);
                return false;
            }

            if (!sha.SequenceEqual(SHA1.HashData(serialized)))
            {
                _logger.Error("SHA1 of TL-Serialized payload mismatch");
                return false;
            }

            return true;
        }

        private bool CheckGLength(BigInteger g, BigInteger dhPrime, string which)
        {
            if (g <= 1 || g > dhPrime - 1)
            {
                _logger.Error("{Which} {G} is not a valid number. Checked against prime {Prime}", which, g, dhPrime);
                return false;
            }

            _logger.Verbose("{Which} {G} is a valid number. Checked against prime {Prime}", which, g, dhPrime);
            return true;
        }

        private bool CheckGABLength(BigInteger g, BigInteger dhPrime, string which)
        {
            var power = BigInteger.Pow(2, 2048 - 64);
            if (g > dhPrime - power && g < power)
            {
                _logger.Error("{Which} {G} does not fall between valid range. Checked against prime {Prime}", which, g, dhPrime);
                return false;
            }

            _logger.Verbose("{Which} {G} falls between valid range. Checked against prime {Prime}", which, g, dhPrime);
            return true;
        }
    }
}