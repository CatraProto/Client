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