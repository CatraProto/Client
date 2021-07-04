using System;
using System.Net;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.AuthKeyHandler;
using CatraProto.Client.TL.Requests.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using Serilog;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;

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
            _connection = new Connection(_session, new ConnectionInfo(IPAddress.Parse("149.154.167.40"), 443, 2), ConnectionProtocol.TcpAbridged);
            Api = new Api(_connection.MessagesHandler);
        }

        public async Task StartAsync()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            await _connection.ConnectAsync();
        }
    }
}