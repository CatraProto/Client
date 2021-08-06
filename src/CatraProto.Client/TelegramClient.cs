using System;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client
{
    public class TelegramClient
    {
        public Api Api { get; private set; }
        private readonly SessionManager _sessionManager;
        private readonly ClientSession _clientSession;
        private readonly FileStream _fileStream;
        private readonly Connection _connection;
        private readonly ILogger _logger;
        public TelegramClient(ClientSession clientSession)
        {
            _clientSession = clientSession;
            _logger = _clientSession.Logger.ForContext<TelegramClient>();
            var connectionInfo = new ConnectionInfo(IPAddress.Parse(clientSession.Settings.DatacenterAddress), 443, 2);
            _connection = new Connection(connectionInfo, clientSession.Settings, ConnectionProtocol.TcpAbridged, _logger);
            _sessionManager = new SessionManager();
            _fileStream = _clientSession.GetSessionStream();
        }

        public async Task StartAsync()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            _connection.MtProtoState.RegisterSerializer(_sessionManager);
            await _sessionManager.ReadAsync(_fileStream);
            _connection.MtProtoState.StartLoops();
            Api = _connection.MtProtoState.Api;
            await _connection.ConnectAsync();
        }

        public async Task SaveSession()
        {
             await _sessionManager.SaveAsync(_fileStream);
             _fileStream.Flush();
        }
    }
}