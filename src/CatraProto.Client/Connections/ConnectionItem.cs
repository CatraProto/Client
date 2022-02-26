using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections
{
    internal class ConnectionItem : IAsyncDisposable
    {
        public Connection Connection
        {
            get
            {
                return _connection ?? throw new InvalidOperationException("Cannot access connection because item disposed");
            }
        }

        private Connection? _connection;
        private ConnectionPool _connectionPool;
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
    }
}
