using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.TL;
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

        public async Task<bool> SendAsync(byte[] message, CancellationToken cancellationToken = default)
        {
            try
            {
                // ReSharper disable once UseAwaitUsing
                using var toStream = message.ToMemoryStream();
                // ReSharper disable once UseAwaitUsing
                using var headedMessage = SetProtocolHeaders(toStream);
                await _stream.WriteAsync(headedMessage.ToArray(), cancellationToken);
            }
            catch (IOException)
            {
                return false;
            }
            catch (ObjectDisposedException e) when (e.ObjectName == "System.Net.Sockets.NetworkStream")
            {
                return false;
            }

            return true;
        }
    }
}