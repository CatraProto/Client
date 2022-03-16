using System;
using CatraProto.Client.Collections;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.Database;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    internal class PeerDatabase
    {
        private readonly Cache<long, IObject> _peerFullCache;
        private readonly Cache<long, IObject> _peerCache;
        private readonly SqliteConnection _sqliteConnection;
        private readonly object _commonMutex;
        private readonly ILogger _logger;

        public PeerDatabase(SqliteConnection sqliteConnection, uint cacheSize, object commonMutex, ILogger logger)
        {
            _peerCache = new Cache<long, IObject>(cacheSize);
            _peerFullCache = new Cache<long, IObject>(cacheSize);
            _sqliteConnection = sqliteConnection;
            _commonMutex = commonMutex;
            _logger = logger.ForContext<PeerDatabase>();
        }

        public void DefineStructures()
        {
            lock (_commonMutex)
            {
                _logger.Information("Creating database table for peer database");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Peers(chatId INT8 PRIMARY KEY, data BLOB NOT NULL)");
                _sqliteConnection.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS PeersFull(chatId INT8 PRIMARY KEY, data BLOB NOT NULL)");
            }
        }

        public IObject? GetPeerObject(PeerId peerId, bool fetchFull, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                Cache<long, IObject>? cache = fetchFull ? _peerFullCache : _peerCache;
                var toId = IdTools.FromApiToTd(peerId.Id, peerId.Type);
                if(cache.TryGetValue(toId, out var cacheObject))
                {
                    return cacheObject;
                }

                _logger.Information("Couldn't find peer {Peer} in memory cache, fetch full: {Full}", peerId, fetchFull);
                var query = fetchFull ? "SELECT * FROM PeersFull WHERE chatId = @p0" : "SELECT * FROM Peers WHERE chatId = @p0";
                var result = _sqliteConnection.ExecuteReaderSingle(query, new object[] { toId }, sqliteTransaction);
                if (result is null)
                {
                    _logger.Warning(messageTemplate: "Couldn't find peer {Peer} inside database, fetch full: {Full}", peerId, fetchFull);
                    return null;
                }

                var serialized = ((byte[])result[1]).ToObject<IObject>(MergedProvider.Singleton);
                cache.CacheItem(toId, serialized, out _);
                return serialized;
            }
        }

        public void UpdateChat(IObject obj, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                bool full = false;
                long peerId;
                IObject toSerialize;
                switch (obj)
                {
                    case User user:
                        peerId = IdTools.FromApiToTd(user.Id, PeerType.User);
                        toSerialize = new DbPeer { AccessHash = user.AccessHash ?? 0, LayerVersion = MergedProvider.LayerId, Object = user };
                        break;
                    case UserFull userFull:
                        full = true;
                        peerId = IdTools.FromApiToTd(userFull.Id, PeerType.User);
                        toSerialize = new DbPeerFull { UpdatedAt = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), LayerVersion = MergedProvider.LayerId, Object = userFull };
                        break;
                    case Channel channel:
                        peerId = IdTools.FromApiToTd(channel.Id, PeerType.Channel);
                        toSerialize = new DbPeer { AccessHash = channel.AccessHash ?? 0, LayerVersion = MergedProvider.LayerId, Object = channel };
                        break;
                    case ChannelForbidden channelForbidden:
                        peerId = IdTools.FromApiToTd(channelForbidden.Id, PeerType.Channel);
                        toSerialize = new DbPeer { AccessHash = channelForbidden.AccessHash, LayerVersion = MergedProvider.LayerId, Object = channelForbidden };
                        break;
                    case ChannelFull channelFull:
                        full = true;
                        peerId = IdTools.FromApiToTd(channelFull.Id, PeerType.Channel);
                        toSerialize = new DbPeerFull { UpdatedAt = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), LayerVersion = MergedProvider.LayerId, Object = channelFull };
                        break;
                    case Chat:
                    case ChatForbidden:
                        peerId = IdTools.FromApiToTd(((ChatBase)obj).Id, PeerType.Group);
                        toSerialize = new DbPeer { AccessHash = 0, LayerVersion = MergedProvider.LayerId, Object = obj};
                        break;
                    case ChatFull chatFull:
                        full = true;
                        peerId = IdTools.FromApiToTd(chatFull.Id, PeerType.Group);
                        toSerialize = new DbPeerFull { UpdatedAt = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), LayerVersion = MergedProvider.LayerId, Object = chatFull };
                        break;
                    default:
                        _logger.Debug("Trying to update chat from object {Constructor}", obj.ToJson());
                        return;
                }

                var query = full ? "REPLACE INTO PeersFull VALUES (@p0, @p1)" : "REPLACE INTO Peers VALUES (@p0, @p1)";
                _sqliteConnection.ExecuteNonQuery(query, new object[] { peerId, toSerialize.ToArray(MergedProvider.Singleton) }, sqliteTransaction);
                (full ? _peerFullCache : _peerCache).CacheItem(peerId, toSerialize, out _);
            }
        }

        public long? GetPeerAccessHash(PeerId peer)
        {
            var obj = (DbPeer?)GetPeerObject(peer, false);
            if(obj is not null)
            {
                return obj.AccessHash; 
            }

            return null;
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
                var userHash = GetPeerAccessHash(PeerId.AsUser(id));
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