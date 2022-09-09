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
using System.Threading.Tasks;

namespace CatraProto.Client.Connections
{
    internal class ConnectionItem : IAsyncDisposable
    {
        public Connection Connection
        {
            get => _connection ?? throw new InvalidOperationException("Cannot access connection because item disposed");
        }

        private Connection? _connection;
        private readonly ConnectionPool _connectionPool;

        public ConnectionItem(Connection connection, ConnectionPool connectionPool)
        {
            _connection = connection;
            _connectionPool = connectionPool;
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
            {
                await _connectionPool.DecreaseReferenceAsync(_connection);
                _connection = null;
            }
        }

        public void ReturnToPool()
        {
            if (_connection != null)
            {
                _connectionPool.DecreaseReference(_connection);
                _connection = null;
            }
        }
    }
}