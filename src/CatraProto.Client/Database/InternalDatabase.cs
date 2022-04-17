using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    public class InternalDatabase
    {
        private const int CurrentDbVersion = 1;
        private readonly SqliteConnection _sqliteConnection;
        private readonly ILogger _logger;
        private readonly object _mutex;

        public InternalDatabase(SqliteConnection sqliteConnection, object commonMutex, ILogger logger)
        {
            _sqliteConnection = sqliteConnection;
            _mutex = commonMutex;
            _logger = logger.ForContext<InternalDatabase>();
        }

        public void DefineStructures()
        {
            lock (_mutex)
            {
                _logger.Information("Creating database table for internal database");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS InternalDatabase(dbVersion INT, data BLOB)");
            }
        }

        public int GetDatabaseVersion()
        {
            lock (_mutex)
            {
                var res = _sqliteConnection.ExecuteReaderSingle("SELECT * FROM InternalDatabase");
                if (res is not null)
                {
                    return (int)res[0];
                }

                return CurrentDbVersion;
            }
        }

        public void UpdateData()
        {
            lock (_mutex)
            {
                _sqliteConnection.ExecuteNonQuery("DELETE FROM InternalDatabase");
                _sqliteConnection.ExecuteNonQuery("INSERT INTO InternalDatabase (dbVersion, data) VALUES (@p0, @p1)", new object[] { CurrentDbVersion, new byte[] { } });
            }
        }
    }
}