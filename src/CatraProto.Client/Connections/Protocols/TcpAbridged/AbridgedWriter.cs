using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    class AbridgedWriter : IProtocolWriter
    {
        private readonly NetworkStream _stream;
        private ILogger _logger;
        public AbridgedWriter(NetworkStream stream, ILogger logger)
        {
            _logger = logger.ForContext<AbridgedWriter>();
            _stream = stream;
        }

        private MemoryStream SetProtocolHeaders(MemoryStream stream)
        {
            var streamLenght = stream.Length / 4;
            using var streamWriter = new BinaryWriter(new MemoryStream(), Encoding.Default, true);
            if (streamLenght >= 127)
            {
                streamWriter.Write((byte)127);
                streamWriter.Write((byte)streamLenght);
                streamWriter.Write((byte)streamLenght >> 8);
                streamWriter.Write((byte)streamLenght >> 16);
            }
            else
            {
                streamWriter.Write((byte)streamLenght);
            }
            streamWriter.Write(stream.ToArray());
            return (MemoryStream)streamWriter.BaseStream;
        }
        
        public Task SendMessage(byte[] message, CancellationToken cancellationToken = default)
        {
            using var toStream = message.ToMemoryStream();
            using var headedMessage = SetProtocolHeaders(toStream);
            return _stream.WriteAsync(headedMessage.ToArray(), cancellationToken).AsTask();
        }

        public Task SendMessage(MessageBase message, CancellationToken token = default)
        {
            var serialized = message.Serialize();
            return SendMessage(serialized, token);
        }
    }
}
