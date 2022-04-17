using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Exceptions;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    internal class AbridgedReader : IProtocolReader
    {
        private readonly NetworkStream _networkStream;
        private readonly ILogger _logger;

        public AbridgedReader(NetworkStream stream, ILogger logger)
        {
            _logger = logger.ForContext<AbridgedReader>();
            _networkStream = stream;
        }

        private async Task<int> GetMessageLength(int firstByte, CancellationToken token = default)
        {
            var length = firstByte;
            if (length >= 0x7f)
            {
                length = await _networkStream.ReadByteAsync(token) | await _networkStream.ReadByteAsync(token) << 8 | await _networkStream.ReadByteAsync(token) << 16;
            }

            length *= 4;
            _logger.Verbose("Transport received a message of {Length} ({Byte})", length, firstByte);
            return length;
        }

        public async Task<byte[]> ReadMessageAsync(CancellationToken token = default)
        {
            try
            {
                var firstByte = await _networkStream.ReadByteAsync(token);
                var length = await GetMessageLength(firstByte, token);
                return await _networkStream.ReadBytesAsync(length, cancellationToken: token);
            }
            catch (ObjectDisposedException e) when (e.ObjectName == "System.Net.Sockets.NetworkStream")
            {
                throw new ConnectionClosedException();
            }
        }
    }
}