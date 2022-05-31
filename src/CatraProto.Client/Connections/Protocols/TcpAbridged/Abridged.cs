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
                _logger.Error("Connection already established", ConnectionInfo);
                return;
            }

            _logger.Information("Establishing connection using Tcp Abridged");
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