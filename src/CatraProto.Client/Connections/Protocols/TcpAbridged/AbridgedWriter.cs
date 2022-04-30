/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
    internal class AbridgedWriter : IProtocolWriter
    {
        private readonly NetworkStream _stream;
        private readonly ILogger _logger;

        public AbridgedWriter(NetworkStream stream, ILogger logger)
        {
            _logger = logger.ForContext<AbridgedWriter>();
            _stream = stream;
        }

        private MemoryStream SetProtocolHeaders(MemoryStream stream)
        {
            var streamLength = stream.Length / 4;
            using var streamWriter = new BinaryWriter(new MemoryStream(), Encoding.UTF8, true);
            if (streamLength >= 127)
            {
                streamWriter.Write((byte)127);
                streamWriter.Write((byte)streamLength);
                streamWriter.Write((byte)(streamLength >> 8));
                streamWriter.Write((byte)(streamLength >> 16));
            }
            else
            {
                streamWriter.Write((byte)streamLength);
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