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
using CatraProto.Client.Crypto;
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

        private Stream SetProtocolHeaders(Stream stream)
        {
            var streamLength = stream.Length / 4;
            var outputStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using var streamWriter = new BinaryWriter(outputStream, Encoding.UTF8, true);
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

            stream.CopyTo(outputStream);
            outputStream.Seek(0, SeekOrigin.Begin);
            return outputStream;
        }

        public async ValueTask<bool> SendAsync(Stream message, CancellationToken cancellationToken = default)
        {
            try
            {
                using var headedMessage = SetProtocolHeaders(message);
                await headedMessage.CopyToAsync(_stream, cancellationToken);
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