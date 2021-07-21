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
    public class Client
    {
        public Api Api { get; private set; }
        private Connection _connection;
        private ILogger _logger;
        private ClientSession _clientSession;
        private SessionManager _sessionManager;
        private FileStream _fileStream;
        public Client(ClientSession clientSession)
        {
            _clientSession = clientSession;
            _logger = _clientSession.Logger.ForContext<Client>();
            _connection = new Connection(new ConnectionInfo(IPAddress.Parse(/*"149.154.167.50"*/ "149.154.167.91"), 443, 2), new ConnectionState(_logger), ConnectionProtocol.TcpAbridged, _logger);
            _sessionManager = new SessionManager();
            _fileStream = _clientSession.GetSessionStream();
        }

        public async Task StartAsync()
        {
            _logger.Information("Initializing CatraProto, the gayest MTProto client in the world");
            _connection.ConnectionState.RegisterSerializer(_sessionManager);
            await _sessionManager.ReadAsync(_fileStream);
            Api = _connection.ConnectionState.Api;
            await _connection.ConnectAsync();
        }

        public async Task SaveSession()
        {
             await _sessionManager.SaveAsync(_fileStream);
             _fileStream.Flush();
        }
    }
}