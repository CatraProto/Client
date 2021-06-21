using System;
using System.Net;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto;
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
            _logger = session.Logger.ForContext<Client>();
            _session = session;
        }

        public async Task StartAsync()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            _connection = new Connection(_session, new ConnectionInfo(IPAddress.Parse("149.154.167.40"), 443, 2));
            Api = new Api(_connection.MessagesHandler);
            await _connection.ConnectAsync();
        }

        public async Task Test()
        {
            var result = await Api.MtProtoApi.ReqPq(CreateRandom());
            _logger.Information(JsonSerializer.Serialize(result));
        }

        public BigInteger CreateRandom()
        {
            var byteArray = new byte[128 / 8];
            new Random().NextBytes(byteArray);
            return new BigInteger(byteArray);
        }
    }
}