using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    internal class Abridged : IProtocol, IDisposable
    {
        private TcpClient _client;
        private ILogger _logger;

        public Abridged(ConnectionInfo connectionInfo, ILogger logger)
        {
            _logger = logger.ForContext<Abridged>();
            ConnectionInfo = connectionInfo;
            _client = new TcpClient {NoDelay = true};
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public IProtocolWriter Writer { get; set; }
        public IProtocolReader Reader { get; set; }
        public ConnectionInfo ConnectionInfo { get; init; }
        public bool IsConnected => _client.Connected;


        public async Task Connect(CancellationToken token = default)
        {
            if (!IsConnected)
            {
                _logger.Information("Establishing connection using Tcp Abridged. IpAddress: {Address}",
                    ConnectionInfo);

                await _client.ConnectAsync(ConnectionInfo.IPAddress, ConnectionInfo.Port, token);

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

        public Task Close()
        {
            _client.Close();
            return Task.CompletedTask;
        }

        /*
        public async Task<Task<UnencryptedMessage>> SendUnencryptedMessage(UnencryptedMessage message) 
        {
            var task = await _readLoop.WaitUnencryptedMessage();
            await _writeLoop.QueueMessage(message, task);
            return task;
        }*/
    }
}