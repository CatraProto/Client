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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Collections;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.Vectors;
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
        public const int MaxChatFull = 60;
        public const int MaxChannelFullCache = 60;
        public const int MaxUserFullCache = 60;
        private readonly Cache<long, IObject> _peerFullCache;
        private readonly Cache<long, IObject> _peerCache;
        private readonly SqliteConnection _sqliteConnection;
        private readonly TelegramClient _client;
        private readonly object _commonMutex;
        private readonly ILogger _logger;

        public PeerDatabase(TelegramClient client, SqliteConnection sqliteConnection, object commonMutex, ILogger logger)
        {
            var cacheSize = client.ClientSession.Settings.SessionSettings.DatabaseSettings.PeerCacheSize;
            _client = client;
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
                var cache = fetchFull ? _peerFullCache : _peerCache;
                var toId = IdTools.FromApiToTd(peerId.Id, peerId.Type);
                if (cache.TryGetValue(toId, out var cacheObject))
                {
                    return cacheObject;
                }

                _logger.Verbose("Couldn't find peer {Peer} in memory cache, fetch full: {Full}", peerId, fetchFull);
                var query = fetchFull ? "SELECT * FROM PeersFull WHERE chatId = @p0" : "SELECT * FROM Peers WHERE chatId = @p0";
                var result = _sqliteConnection.ExecuteReaderSingle(query, new object[] { toId }, sqliteTransaction);
                if (result is null)
                {
                    _logger.Information(messageTemplate: "Couldn't find peer {Peer} inside database, fetch full: {Full}", peerId, fetchFull);
                    return null;
                }

                var serialized = ((byte[])result[1]).ToObject<IObject>(MergedProvider.Singleton);
                if (serialized.IsError)
                {
                    return null;
                }

                cache.CacheItem(toId, serialized.Value, out _);
                _logger.Information("Peer {Peer} found in database and stored in memory-cache, fetch full: {Full}", peerId, fetchFull);
                return serialized.Value;
            }
        }

        public void PushChatToDb(IObject obj, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                var full = false;
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
                        toSerialize = new DbPeer { AccessHash = 0, LayerVersion = MergedProvider.LayerId, Object = obj };
                        break;
                    case ChatFull chatFull:
                        full = true;
                        peerId = IdTools.FromApiToTd(chatFull.Id, PeerType.Group);
                        toSerialize = new DbPeerFull { UpdatedAt = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), LayerVersion = MergedProvider.LayerId, Object = chatFull };
                        break;
                    default:
                        _logger.Warning("Trying to update chat from object {Constructor}", obj.ToJson());
                        return;
                }

                var query = full ? "REPLACE INTO PeersFull VALUES (@p0, @p1)" : "REPLACE INTO Peers VALUES (@p0, @p1)";
                var trySer = toSerialize.ToArray(MergedProvider.Singleton, out var serialized);
                if (trySer.IsError)
                {
                    _logger.Error("Could not serialize TL-object before pushing to db. Error: {Error}", trySer.GetError().Error);
                }
                else
                {
                    _sqliteConnection.ExecuteNonQuery(query, new object[] { peerId, serialized }, sqliteTransaction);
                }

                (full ? _peerFullCache : _peerCache).CacheItem(peerId, toSerialize, out _);
            }
        }

        public void UpdatePeerObject(IObject peerObject, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                if (peerObject is Channel or ChannelForbidden or User or Chat or ChatForbidden)
                {
                    var peer = IdTools.GetPeerFromObject(peerObject);
                    if (peerObject is Channel asChannel && asChannel.Min || peerObject is User asUser && asUser.Min)
                    {
                        _logger.Information("Not updating peer {Chat} because a min update was received", peer);
                        return;
                    }

                    _logger.Information("Trying to fetch cached peer object of {Chat}", peer);
                    var fromDb = (DbPeer?)GetPeerObject(peer, false, sqliteTransaction);
                    var pushToDb = false;

                    if (fromDb is null)
                    {
                        _logger.Information("Don't have peer object of {Chat} stored, pushing to database", peer);
                        pushToDb = true;
                    }
                    else if (fromDb.Object is null)
                    {
                        _logger.Information("Could not deserialize store peer object of {Chat}, pushing to database", peer);
                        pushToDb = true;
                    }
                    else
                    {
                        pushToDb = fromDb.Object.Compare(peerObject);
                    }

                    if (pushToDb)
                    {
                        _logger.Information("Pushing updated peer object of {Chat} to database", peer);
                        PushChatToDb(peerObject, sqliteTransaction);
                    }
                }
                else
                {
                    _logger.Warning("Received {Obj} in UpdatePeerObject", peerObject);
                }
            }
        }

        public async Task<RpcResponse<RpcVector<IObject>>> GetPeersAsync(List<PeerId> ids, CancellationToken cancellationToken)
        {
            var inputChannels = new Lazy<List<InputChannelBase>>(LazyThreadSafetyMode.None);
            var inputChats = new Lazy<List<long>>(LazyThreadSafetyMode.None);
            var inputUsers = new Lazy<List<InputUserBase>>(LazyThreadSafetyMode.None);
            var result = new RpcVector<IObject>();
            foreach (var id in ids)
            {
                if (!(id.Type is PeerType.User || id.Type is PeerType.Channel || id.Type is PeerType.Group))
                {
                    return RpcResponse<RpcVector<IObject>>.FromError(new InvalidTypeError());
                }

                var dbResult = _client.DatabaseManager.PeerDatabase.GetPeerObject(id, false);
                if (dbResult is null || dbResult is not DbPeer dbPeer)
                {
                    continue;
                }

                if (dbPeer.Object is null || !PeerTypeMatches(dbPeer.Object, id.Type))
                {
                    switch (id.Type)
                    {
                        case PeerType.User:
                            inputUsers.Value.Add(new InputUser(id.Id, dbPeer.AccessHash));
                            break;
                        case PeerType.Channel:
                            inputChannels.Value.Add(new InputChannel(id.Id, dbPeer.AccessHash));
                            break;
                        case PeerType.Group:
                            inputChats.Value.Add(id.Id);
                            break;
                    }
                }
                else
                {
                    result.Add(dbPeer.Object);
                }
            }

            if (inputUsers.IsValueCreated)
            {
                var users = await _client.Api.CloudChatsApi.Users.InternalGetUsersAsync(inputUsers.Value);
                if (users.RpcCallFailed)
                {
                    return RpcResponse<RpcVector<IObject>>.FromError(users.Error);
                }

                result.AddRange(users.Response.Where(x => x is not UserEmpty));
            }

            if (inputChats.IsValueCreated)
            {
                var chats = await _client.Api.CloudChatsApi.Messages.InternalGetChatsAsync(inputChats.Value, cancellationToken: cancellationToken);
                if (chats.RpcCallFailed)
                {
                    return RpcResponse<RpcVector<IObject>>.FromError(chats.Error);
                }

                result.AddRange(chats.Response.ChatsField.Where(x => x is not ChatEmpty));
            }

            if (inputChannels.IsValueCreated)
            {
                var channels = await _client.Api.CloudChatsApi.Channels.InternalGetChannelsAsync(inputChannels.Value);
                if (channels.RpcCallFailed)
                {
                    return RpcResponse<RpcVector<IObject>>.FromError(channels.Error);
                }

                result.AddRange(channels.Response.ChatsField.Where(x => x is not ChatEmpty));
            }

            for (var i = 0; i < result.Count; i++)
            {
                result[i] = result[i].Clone()!;
            }

            return RpcResponse<RpcVector<IObject>>.FromResult(result);
        }

        public async Task<RpcResponse<T>> GetFullPeerAsync<T>(PeerId id, int maxCache, bool force, CancellationToken cancellationToken) where T : IObject
        {
            IObject? result = null;
            if (!force)
            {
                result = _client.DatabaseManager.PeerDatabase.GetPeerObject(id, true);
            }

            if (result is null || result is not DbPeerFull peer || peer.Object is null || !FullTypeMatches(result, id.Type) || DateTimeOffset.UtcNow.ToUnixTimeSeconds() - peer.UpdatedAt > maxCache)
            {
                switch (id.Type)
                {
                    case PeerType.User:
                        var getFullUser = await _client.Api.CloudChatsApi.Users.InternalGetFullUserAsync(id.Id, cancellationToken: cancellationToken);
                        if (getFullUser.RpcCallFailed)
                        {
                            return RpcResponse<T>.FromError(getFullUser.Error);
                        }

                        result = getFullUser.Response;
                        break;
                    case PeerType.Channel:
                        var getFullChannel = await _client.Api.CloudChatsApi.Channels.InternalGetFullChannelAsync(id.Id, cancellationToken: cancellationToken);
                        if (getFullChannel.RpcCallFailed)
                        {
                            return RpcResponse<T>.FromError(getFullChannel.Error);
                        }

                        result = getFullChannel.Response;
                        break;
                    case PeerType.Group:
                        var getFullChat = await _client.Api.CloudChatsApi.Messages.InternalGetFullChatAsync(id.Id, cancellationToken: cancellationToken);
                        if (getFullChat.RpcCallFailed)
                        {
                            return RpcResponse<T>.FromError(getFullChat.Error);
                        }

                        result = getFullChat.Response;
                        break;
                    default:
                        return RpcResponse<T>.FromError(new InvalidTypeError());
                }
            }

            if (result is not T)
            {
                return RpcResponse<T>.FromError(new InvalidTypeError());
            }

            return RpcResponse<T>.FromResult((T)result.Clone()!);
        }

        public long? GetPeerAccessHash(PeerId peer)
        {
            var obj = (DbPeer?)GetPeerObject(peer, false);
            if (obj is not null)
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
                        return new InputPeerChannel() { ChannelId = peerId.Id, AccessHash = accessHash.Value };
                    case PeerType.User:
                        return new InputPeerUser { UserId = peerId.Id, AccessHash = accessHash.Value };
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
                    return new InputChannel() { ChannelId = id, AccessHash = channelHash.Value };
                }

                return null;
            }
        }

        public InputUser? ResolveUser(long id)
        {
            lock (_commonMutex)
            {
                var userHash = GetPeerAccessHash(PeerId.AsUser(id));
                if (userHash.HasValue)
                {
                    return new InputUser() { UserId = id, AccessHash = userHash.Value };
                }

                return null;
            }
        }

        public bool HavePeer(PeerId peerId)
        {
            var getPeer = GetPeerObject(peerId, false);
            return getPeer is not null && getPeer is DbPeer db && db.Object is not null;
        }


        private static bool PeerTypeMatches<T>(T instance, PeerType type)
        {
            return (instance is User && type is PeerType.User) || ((instance is Channel || instance is ChannelForbidden) && type is PeerType.Channel) || ((instance is Chat || instance is ChatForbidden) && type is PeerType.Group);
        }

        private bool FullTypeMatches<T>(T instance, PeerType type)
        {
            return (instance is UserFull && type is PeerType.User) || (instance is ChannelFull && type is PeerType.Channel) || (instance is ChatFull && type is PeerType.Group);
        }
    }
}