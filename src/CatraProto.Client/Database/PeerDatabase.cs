using System.Threading;
using CatraProto.Client.Collections;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    public class PeerDatabase
    {
        private readonly Cache<long, IObject> _peerCache;
        private readonly SqliteConnection _sqliteConnection;
        private readonly object _commonMutex;
        private readonly ILogger _logger;

        public PeerDatabase(SqliteConnection sqliteConnection, uint cacheSize, object commonMutex, ILogger logger)
        {
            _peerCache = new Cache<long, IObject>(cacheSize);
            _sqliteConnection = sqliteConnection;
            _commonMutex = commonMutex;
            _logger = logger.ForContext<PeerDatabase>();
        }

        public void DefineStructures()
        {
            lock (_commonMutex)
            {
                _logger.Information("Creating database table for peer database");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Chats(chatId INT8 PRIMARY KEY UNIQUE, data BLOB)");
            }
        }

        private long? GetPeerAccessHash(PeerId peer, SqliteTransaction? sqliteTransaction = null)
        {
            var item = GetPeerObject(peer);
            if (item is null)
            {
                return null;
            }

            switch (item)
            {
                case Channel channel:
                    return channel.AccessHash != null ? channel.AccessHash.Value : 0;
                case ChannelForbidden channelForbidden:
                    return channelForbidden.AccessHash;
                case User user:
                    return user.AccessHash != null ? user.AccessHash.Value : 0;
                default:
                    _logger.Warning("Trying to fetch access hash from type {Type}", item);
                    return 0;
            }
        }

        private IObject? GetPeerObject(PeerId peerId, SqliteTransaction? sqliteTransaction = null)
        {
            IObject? item;
            var toTdId = IdTools.FromApiToTd(peerId.Id, peerId.Type);
            if (!_peerCache.TryGetValue(toTdId, out item))
            {
                item = FetchFromDatabase(toTdId, sqliteTransaction);
            }

            return item;
        }

        private IObject? FetchFromDatabase(long peerId, SqliteTransaction? sqliteTransaction = null)
        {
            _logger.Information("Fetching peer {Peer} from database", peerId);
            var result = _sqliteConnection.ExecuteReaderSingle("SELECT data FROM Chats WHERE chatId = @p0", new object[] { peerId }, sqliteTransaction);
            if (result is null)
            {
                _logger.Warning(messageTemplate: "Couldn't find peer {Peer}", peerId);
                return null;
            }

            var serialized = ((byte[])result[0]).ToObject<IObject>(MergedProvider.Singleton);
            _peerCache.CacheItem(peerId, serialized, out _);
            return serialized;
        }

        public void UpdateChat(IObject obj, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                long peerId;
                switch (obj)
                {
                    case User user:
                        peerId = IdTools.FromApiToTd(user.Id, PeerType.User);
                        break;
                    case Channel:
                    case ChannelForbidden:
                        peerId = IdTools.FromApiToTd(((ChatBase)obj).Id, PeerType.Channel);
                        break;
                    case Chat:
                    case ChatForbidden ch:
                        peerId = IdTools.FromApiToTd(((ChatBase)obj).Id, PeerType.Group);
                        break;
                    default:
                        _logger.Warning("Can't update database data from received object {Obj}", obj);
                        return;
                }

                _logger.Information("Updating stored object for peer {Peer}", peerId);
                _sqliteConnection.ExecuteNonQuery("REPLACE INTO Chats VALUES (@p0, @p1)", new object[] {peerId, obj.ToArray(MergedProvider.Singleton)}, sqliteTransaction);
                _peerCache.CacheItem(peerId, obj, out _);
            }
        }

        public InputPeerBase? ResolvePeer(PeerId peerId)
        {
            lock (_commonMutex)
            {
                var accessHash = GetPeerAccessHash(peerId);
                if (accessHash is null)
                {
                    return null;
                }

                switch (peerId.Type)
                {
                    case PeerType.Channel:
                        return new InputPeerChannel()
                        {
                            ChannelId = peerId.Id,
                            AccessHash = accessHash.Value
                        };
                    case PeerType.User:
                        return new InputPeerUser
                        {
                            UserId = peerId.Id,
                            AccessHash = accessHash.Value
                        };
                    case PeerType.Group:
                        return new InputPeerChat() { ChatId = peerId.Id };
                    default:
                        _logger.Warning("Cannot retrieve access hash for peer type {Type}", peerId.Type);
                        return null;
                }
            }
        }

        public InputChannelBase? ResolveChannel(long id)
        {
            lock (_commonMutex)
            {
                var channelHash = GetPeerAccessHash(PeerId.AsChannel(id));
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
                var userHash = GetPeerAccessHash(PeerId.AsChannel(id));
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
    }
}