using System;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto;
using Serilog;

namespace CatraProto.Client
{
    public class Client
    {
        private Connection _connection;
        private ILogger _logger;
        public Api Api { get; init; }
        private Session _session;

        public Client(Session session)
        {
            _session = session;
            _logger = session.Logger.ForContext<Client>();
        }


        public async Task Start()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            /*_connection = await Connection.Create(_session, new ConnectionInfo
            {
                IpAddress = IPAddress.Parse("149.154.167.40"),
                Port = 443
            });*/
        }

        public async Task Test()
        {
            /*var obj = new ReqPq
            {
                Nonce = CreateRandom()
            };
            var toArray = obj.ToArray(MergedProvider.DefaultInstance);
            var value = toArray.ToMemoryStream();
            using var unencryptedMessage = new UnencryptedMessage()
            {
                Message = value
            };
            var response = await _connection.MessagesHandler.QueueUnencryptedMessage(unencryptedMessage).Unwrap();
            _logger.Debug("Sent Nonce {Nonce}", obj.Nonce);
            var message = response.Message.ToObject<ResPQ>(MergedProvider.DefaultInstance);
            _logger.Debug("Received Nonce {Nonce}", message.Nonce);*/
            /*var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            var mammt = new EncryptedMessage()
            {
                Token = cancellationToken.Token
            }; 
            _connection.MessagesHandler.QueueEncryptedMessage(mammt, out var completion);
            try
            {
                await completion;
            }
            catch (OperationCanceledException e)
            {
                _logger.Warning($"Operation canceled");
            }*/
        }

        public BigInteger CreateRandom()
        {
            var byteArray = new byte[128 / 8];
            new Random().NextBytes(byteArray);
            return new BigInteger(byteArray);
        }
    }
}