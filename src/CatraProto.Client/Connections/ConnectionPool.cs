using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    class ConnectionPool
    {
        private readonly Dictionary<int, Connection> _connections = new Dictionary<int, Connection>();
        private readonly ClientSettings _clientSettings;
        private readonly object _mutex = new object();
        private readonly SessionData _sessionData;
        private Connection? _accountConnection;
        private readonly ILogger _logger;

        public ConnectionPool(SessionData sessionData, ClientSettings clientSettings, ILogger logger)
        {
            _sessionData = sessionData;
            _clientSettings = clientSettings;
            _clientSettings = clientSettings;
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

                var connectionInfo = new ConnectionInfo(IPAddress.Parse(datacenter.IpAddress), datacenter.Port, dc);
                return await GetConnectionAsync(connectionInfo);
            }
        }

        public async ValueTask<Connection> GetConnectionAsync(ConnectionInfo? connectionInfo = null)
        {
            connectionInfo ??= _clientSettings.ConnectionSettings.DefaultDatacenter;
            var connection = CreateConnection(connectionInfo, out var justCreated);
            if (justCreated)
            {
                connection.MtProtoState.StartLoops();
                await connection.ConnectAsync();
            }

            return connection;
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
                _accountConnection = connection;
            }
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
                    var newConnection = new Connection(connectionInfo, _clientSettings, ConnectionProtocol.TcpAbridged, _sessionData, _logger);
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
    }
}