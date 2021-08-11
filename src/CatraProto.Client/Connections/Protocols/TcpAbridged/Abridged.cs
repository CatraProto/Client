using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    class Abridged : IProtocol, IDisposable
    {
        public bool IsConnected
        {
            get => _client.Connected;
        }

        public IProtocolWriter? Writer { get; set; }
        public IProtocolReader? Reader { get; set; }
        public ConnectionInfo ConnectionInfo { get; init; }
        private readonly TcpClient _client;
        private readonly ILogger _logger;

        public Abridged(ConnectionInfo connectionInfo, ILogger logger)
        {
            _logger = logger.ForContext<Abridged>();
            ConnectionInfo = connectionInfo;
            _client = new TcpClient { NoDelay = true };
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task ConnectAsync(CancellationToken token = default)
        {
            if (!IsConnected)
            {
                _logger.Information("Establishing connection using Tcp Abridged. IpAddress: {Address}", ConnectionInfo);

                await _client.ConnectAsync(ConnectionInfo.IpAddress, ConnectionInfo.Port, token);

                var stream = _client.GetStream();
                await stream.WriteAsync(0xef, token);

                Writer ??= new AbridgedWriter(stream, _logger);
                Reader ??= new AbridgedReader(stream, _logger);
            }
            else
            {
                _logger.Warning("Connect called but we're already connected, request ignored");
            }
        }

        public Task CloseAsync()
        {
            _client.Close();
            return Task.CompletedTask;
        }
    }
}