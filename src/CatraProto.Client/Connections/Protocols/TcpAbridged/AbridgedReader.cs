using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    class AbridgedReader : IProtocolReader
    {
        private NetworkStream _networkStream;
        private ILogger _logger;

        public AbridgedReader(NetworkStream stream, ILogger logger)
        {
            _logger = logger.ForContext<AbridgedReader>();
            _networkStream = stream;
        }

        public async Task<byte[]> ReadIncomingMessage(CancellationToken token = default)
        {
            var firstByte = await _networkStream.ReadByte(0, token);
            var length = await GetMessageLength(firstByte, token);
            return await _networkStream.ReadBytesAsync(length, cancellationToken: token);
        }

        private async Task<int> GetMessageLength(int firstByte, CancellationToken token = default)
        {
            var length = firstByte;
            if (length >= 0x7f)
            {
                length = await _networkStream.ReadByte(0, token) |
                         await _networkStream.ReadByte(0, token) << 8 |
                         await _networkStream.ReadByte(0, token) << 16;
            }

            length *= 4;
            _logger.Debug("Length is {Length}. First byte {Byte}", length, firstByte);
            return length;
        }
    }
}