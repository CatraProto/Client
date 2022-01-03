using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client.Connections
{
    class ConnectionPool : IAsyncDisposable
    {
        private readonly Dictionary<int, Connection> _connections = new Dictionary<int, Connection>();
        private readonly ClientSession _clientSession;
        private readonly object _mutex = new object();
        private Connection? _accountConnection;
        private readonly ILogger _logger;

        public ConnectionPool(ClientSession clientSession, ILogger logger)
        {
            _clientSession = clientSession;
            _logger = logger.ForContext<ConnectionPool>();
        }

        public async ValueTask<Connection> GetConnectionByDcAsync(int dc)
        {
            if (GetConnection(dc, out var connection))
            {
                return connection;
            }

            var defaultConnection = await GetConnectionAsync();
            if (defaultConnection.ConnectionInfo.DcId == dc)
            {
                return defaultConnection;
            }
            else
            {
                var config = await defaultConnection.MtProtoState.Api.CloudChatsApi.Help.GetConfigAsync();
                var datacenter = config.Response!.DcOptions.FirstOrDefault(x => !x.MediaOnly && !x.TcpoOnly && x.Id == dc && !x.Ipv6);
                if (datacenter == null)
                {
                    throw new Exception("Datacenter could not be found");
                }

                var connectionInfo = new ConnectionInfo(ConnectionProtocol.TcpAbridged, IPAddress.Parse(datacenter.IpAddress), datacenter.Port, dc);
                return await GetConnectionAsync(connectionInfo);
            }
        }

        public async ValueTask<Connection> GetConnectionAsync(ConnectionInfo? connectionInfo = null)
        {
            Connection connection;
            bool justCreated;
            lock (_mutex)
            {
                connectionInfo ??= _clientSession.Settings.ConnectionSettings.DefaultDatacenter;
                connection = CreateConnection(connectionInfo, out justCreated);
                _accountConnection ??= connection;
            }

            if (!justCreated)
            {
                return connection;
            }

            await connection.ConnectAsync();
            return connection;
        }

        public Connection CreateConnection(ConnectionInfo connectionInfo, out bool justCreated)
        {
            lock (_mutex)
            {
                if (_connections.TryGetValue(connectionInfo.DcId, out var connection))
                {
                    justCreated = false;
                    return connection;
                }
                else
                {
                    var newConnection = new Connection(connectionInfo, _clientSession);
                    _connections.TryAdd(connectionInfo.DcId, newConnection);

                    justCreated = true;
                    return newConnection;
                }
            }
        }

        public bool GetConnection(int dcId, [MaybeNullWhen(false)] out Connection connection)
        {
            lock (_mutex)
            {
                return _connections.TryGetValue(dcId, out connection);
            }
        }

        public Connection? GetAccountConnection()
        {
            lock (_mutex)
            {
                return _accountConnection;
            }
        }

        public void SetAccountConnection(Connection connection)
        {
            lock (_mutex)
            {
                if (_accountConnection != null)
                {
                    connection.MessagesDispatcher.UpdatesHandler = null;
                    _accountConnection.ConnectionInfo.Main = false;
                }

                connection.MessagesDispatcher.UpdatesHandler = _clientSession.UpdatesHandler;
                connection.ConnectionInfo.Main = true;
                _accountConnection = connection;
            }
        }

        public async ValueTask DisposeAsync()
        {
            ValueTask[] toWait;
            lock (_mutex)
            {
                toWait = new ValueTask[_connections.Count];
                var i = 0;
                foreach (var connection in _connections)
                {
                    _logger.Information("Disposing connection {Connection}", connection);
                    toWait[i++] = connection.Value.DisposeAsync();
                }
            }

            foreach (var vTask in toWait)
            {
                await vTask;
            }
            
            _logger.Information("Connection pool disposed");
        }
    }
}