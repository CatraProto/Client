using System.Threading;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    public class PeerDatabase
    {
        private readonly SqliteConnection _sqliteConnection;
        private readonly object _commonMutex;
        private readonly ILogger _logger;

        public PeerDatabase(SqliteConnection sqliteConnection, object commonMutex, ILogger logger)
        {
            _sqliteConnection = sqliteConnection;
            _commonMutex = commonMutex;
            _logger = logger.ForContext<PeerDatabase>();
        }

        public void DefineStructures(CancellationToken token = default)
        {
            lock (_commonMutex)
            {
                _logger.Information("Creating database tables");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS PeerDb_Channels(chat_id bigint PRIMARY KEY UNIQUE, access_hash bigint)");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS PeerDb_Users(chat_id bigint PRIMARY KEY UNIQUE, access_hash bigint)");
            }
        }

        public InputPeerBase? ResolvePeer(PeerId peerId)
        {
            lock (_commonMutex)
            {
                switch (peerId.Type)
                {
                    case PeerType.Channel:
                        var channelHash = GetChannelHash(peerId.Id);
                        if (channelHash.HasValue)
                        {
                            return new InputPeerChannel()
                            {
                                ChannelId = peerId.Id,
                                AccessHash = channelHash.Value
                            };
                        }

                        break;
                    case PeerType.User:
                        var userHash = GetUserHash(peerId.Id);
                        if (userHash.HasValue)
                        {
                            return new InputPeerUser
                            {
                                UserId = peerId.Id,
                                AccessHash = userHash.Value
                            };
                        }

                        break;
                    case PeerType.Group:
                        return new InputPeerChat() { ChatId = peerId.Id };
                }

                return null;
            }
        }

        public InputChannelBase? ResolveChannel(long id)
        {
            lock (_commonMutex)
            {
                var channelHash = GetChannelHash(id);
                if (channelHash.HasValue)
                {
                    return new InputChannel()
                    {
                        ChannelId = id,
                        AccessHash = channelHash.Value
                    };
                }

                return null;
            }
        }

        public InputUserBase? ResolveUser(long id)
        {
            lock (_commonMutex)
            {
                var userHash = GetUserHash(id);
                if (userHash.HasValue)
                {
                    return new InputUser()
                    {
                        UserId = id,
                        AccessHash = userHash.Value
                    };
                }

                return null;
            }
        }

        private long? GetChannelHash(long chatId, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                var result = _sqliteConnection.ExecuteReaderSingle("SELECT access_hash FROM PeerDb_Channels WHERE chat_id = @p0", new object[] { chatId }, sqliteTransaction);
                return (long?)result?[0];
            }
        }

        private long? GetUserHash(long chatId, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                var result = _sqliteConnection.ExecuteReaderSingle("SELECT access_hash FROM PeerDb_Users WHERE chat_id = @p0", new object[] { chatId }, sqliteTransaction);
                return (long?)result?[0];
            }
        }

        public void UpdateChannel(long chatId, long accessHash, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                _sqliteConnection.ExecuteNonQuery("INSERT INTO PeerDb_Channels (chat_id, access_hash) VALUES (@p0, @p1) ON CONFLICT(chat_id) DO UPDATE SET access_hash = @p1", new object[] { chatId, accessHash }, sqliteTransaction);
            }
        }

        public void UpdateUser(long chatId, long accessHash, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                _sqliteConnection.ExecuteNonQuery("INSERT INTO PeerDb_Users (chat_id, access_hash) VALUES (@p0, @p1) ON CONFLICT(chat_id) DO UPDATE SET access_hash = @p1", new object[] { chatId, accessHash }, sqliteTransaction);
            }
        }
    }
}