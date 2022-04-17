using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace CatraProto.Client.Database
{
    internal static class QueryHelpers
    {
        public static object[][]? ExecuteReaderMulti(this SqliteConnection connection, string command, object[]? values = null, SqliteTransaction? transaction = null)
        {
            using var sqlCommand = CreateCommand(connection, command, values, transaction);
            var reader = sqlCommand.ExecuteReader();
            var list = new List<object[]>();
            var fieldCount = reader.FieldCount;

            while (reader.Read())
            {
                var result = new object[fieldCount];
                for (var i = 0; i < fieldCount; i++)
                {
                    result[i] = reader.GetValue(i);
                }

                list.Add(result);
            }

            return list.Count > 0 ? list.ToArray() : null;
        }


        public static object[]? ExecuteReaderSingle(this SqliteConnection connection, string command, object[]? values = null, SqliteTransaction? transaction = null)
        {
            using var sqlCommand = CreateCommand(connection, command, values, transaction);
            var reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                var fieldCount = reader.FieldCount;
                var result = new object[fieldCount];
                for (var i = 0; i < fieldCount; i++)
                {
                    result[i] = reader.GetValue(i);
                }

                return result;
            }

            return null;
        }

        public static int ExecuteNonQuery(this SqliteConnection connection, string command, object[]? values = null, SqliteTransaction? transaction = null)
        {
            using var sqlCommand = CreateCommand(connection, command, values, transaction);
            return sqlCommand.ExecuteNonQuery();
        }

        private static SqliteCommand CreateCommand(this SqliteConnection connection, string command, object[]? values = null, SqliteTransaction? transaction = null)
        {
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = command;
            sqlCommand.Transaction = transaction;
            AddParameters(sqlCommand, values);
            return sqlCommand;
        }

        private static void AddParameters(SqliteCommand command, object[]? values)
        {
            if (values is null)
            {
                return;
            }

            for (var i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue($"@p{i}", values[i]);
            }
        }
    }
}