using System;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Crypto;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.Crypto.KeyExchange;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client
{
    public class Client
    {
        public Api Api { get; private set; }
        private Connection _connection;
        private ILogger _logger;
        private Session _session;

        public Client(Session session)
        {
            _session = session;
            _logger = _session.Logger.ForContext<Client>();
            _connection = new Connection(_session, new ConnectionInfo(IPAddress.Parse("149.154.167.40"), 443, 2));
            Api = new Api(_connection.MessagesHandler);
        }

        public async Task StartAsync()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            await _connection.ConnectAsync();
        }

        public async Task Test()
        {
            _logger.Information("Generating auth key...");
            var nonce = CryptoTools.GenerateBigInt(128);
            var reqPq = await Api.MtProtoApi.ReqPqAsync(nonce);
            if (!reqPq.RpcCallFailed)
            {
                KeyExchangeChecks.CheckNonce(nonce, reqPq.Response.Nonce);

                var serverNonce = reqPq.Response.ServerNonce;
                var pq = reqPq.Response.Pq;

                _logger.Information("Received ServerNonce from server with value {SNonce} and Pq with value {Pq}", serverNonce, pq);
                var (foundKey, rsaKey) = Rsa.FindByFingerprints(reqPq.Response.ServerPublicKeyFingerprints);
                if (rsaKey == null)
                {
                    _logger.Error("None of the fingerprints provided were found in the array of RSA keys");
                    return;
                }

                var decomposedPq = CryptoTools.GetFastPq(BitConverter.ToUInt64(pq.Reverse().ToArray()));
                var newNonce = CryptoTools.GenerateBigInt(256);
                var toHash = new PQInnerData
                {
                    Nonce = nonce,
                    ServerNonce = reqPq.Response.ServerNonce,
                    NewNonce = newNonce,
                    P = decomposedPq.Item1,
                    Q = decomposedPq.Item2,
                    Pq = reqPq.Response.Pq
                };
                var encryptedData = rsaKey.EncryptData(Hashing.ComputeDataHashedFilling(toHash, MergedProvider.Singleton));
                _logger.Information("Sending ReqDHParams request...");
                var reqDh = await Api.MtProtoApi.ReqDHParamsAsync(nonce, serverNonce, decomposedPq.Item1, decomposedPq.Item2, foundKey, encryptedData);
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
                            .DecryptMessage(igeEncryptor, ok.EncryptedAnswer)
                            .ToObject<ServerDHInnerData>(MergedProvider.Singleton);

                        _logger.Information("Message decrypted, checking nonce ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", serverDhInnerData.Nonce, nonce, serverDhInnerData.ServerNonce, serverNonce);
                        KeyExchangeChecks.CheckNonce(serverDhInnerData.Nonce, nonce);
                        KeyExchangeChecks.CheckNonce(serverDhInnerData.ServerNonce, serverNonce);

                        var b = CryptoTools.GenerateBigInt(2048, true);
                        var dhPrime = new BigInteger(serverDhInnerData.DhPrime);
                        var gbMod = BigInteger.ModPow(serverDhInnerData.G, b, dhPrime);
                        var clientDhInnerData = new ClientDHInnerData
                        {
                            Nonce = nonce,
                            ServerNonce = serverNonce,
                            GB = gbMod.ToByteArray()
                        };
                        var hashedPadding = Hashing.ComputeDataHashedPadding(clientDhInnerData, MergedProvider.Singleton);
                        var encryptedInnerData = igeEncryptor.Encrypt(hashedPadding);

                        _logger.Information("gbMod computed, sending setClientDHParams...");
                        var setDhClient = await Api.MtProtoApi.SetClientDHParamsAsync(nonce, serverNonce, null);
                        if (!setDhClient.RpcCallFailed)
                        {
                            if (setDhClient.Response is DhGenOk dhGenOk)
                            {
                                _logger.Information("Received dhGenOk checking ({SSNonce} == {Nonce}) and serverNonce ({SSSNonce} == {SNonce})", dhGenOk.Nonce, nonce, dhGenOk.ServerNonce, serverNonce);
                                KeyExchangeChecks.CheckNonce(dhGenOk.Nonce, nonce);
                                KeyExchangeChecks.CheckNonce(dhGenOk.ServerNonce, serverNonce);

                                var authKey = BigInteger.ModPow(new BigInteger(serverDhInnerData.GA), b, dhPrime).ToByteArray();
                                var authKeyId = SHA1.HashData(authKey).TakeLast(8).ToArray();
                                _logger.Information("Nonce and serverNonce match, AuthKey successfully generated, AuthKeyId: {Id}", authKeyId);
                            }
                        }
                    }
                    else if (reqDh.Response is ServerDHParamsFail fail)
                    {
                    }
                }
                else
                {
                    _logger.Error("Received {Code} from Telegram server", reqDh.Error);
                }

                rsaKey.Dispose();
            }
        }
    }
}