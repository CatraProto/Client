using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    internal class Abridged : IProtocol
    {
        public IProtocolWriter Writer
        {
            get => _protocolWriter ?? throw new InvalidOperationException("Can't get protocol writer when stream is not connected");
        }

        public IProtocolReader Reader
        {
            get => _protocolReader ?? throw new InvalidOperationException("Can't get protocol writer when stream is not connected");
        }

        public ConnectionInfo ConnectionInfo { get; init; }
        private IProtocolWriter? _protocolWriter;
        private IProtocolReader? _protocolReader;
        private readonly TcpClient _client;
        private readonly ILogger _logger;

        public Abridged(ConnectionInfo connectionInfo, ILogger logger)
        {
            _logger = logger.ForContext<Abridged>();
            ConnectionInfo = connectionInfo;
            _client = new TcpClient { NoDelay = true };
        }

        public async Task ConnectAsync(CancellationToken token = default)
        {
            if (_protocolWriter != null || _protocolReader != null)
            {
                _logger.Error("Connection to {Connection} already established", ConnectionInfo);
                throw new InvalidOperationException("Connection already established");
            }

            _logger.Information("Establishing connection using Tcp Abridged. IpAddress: {Address}", ConnectionInfo);
            await _client.ConnectAsync(ConnectionInfo.IpAddress, ConnectionInfo.Port, token);

            var stream = _client.GetStream();
            await stream.WriteAsync(0xef, token);

            _protocolWriter = new AbridgedWriter(stream, _logger);
            _protocolReader = new AbridgedReader(stream, _logger);
        }

        public Task CloseAsync()
        {
            _client.Dispose();
            return Task.CompletedTask;
        }
    }
}