using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                Cache<long, IObject>? cache = fetchFull ? _peerFullCache : _peerCache;
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
                    _logger.Warning(messageTemplate: "Couldn't find peer {Peer} inside database, fetch full: {Full}", peerId, fetchFull);
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

        public void UpdateUser(UserBase userObject, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                if (userObject is not User user)
                {
                    _logger.Warning("Expected user but {Obj} received", userObject);
                    return;
                }

                var peer = IdTools.GetPeerFromObject(userObject);
                if (user.Min)
                {
                    _logger.Information("Not updating user {User} because a min update was received", peer);
                    return;
                }

                _logger.Information("Trying to fetch cached peer object of user {Chat}", peer);
                var fromDb = (DbPeer?)GetPeerObject(peer, false, sqliteTransaction);
                var pushToDb = false;

                if (fromDb is null)
                {
                    _logger.Information("Don't have peer object of User {Chat} stored, pushing to database", peer);
                    pushToDb = true;
                }
                else if (fromDb.Object is null)
                {
                    _logger.Information("Could not deserialize store peer object of User {Chat}, pushing new one to database", peer);
                    pushToDb = true;
                }
                else
                {
                    //Self, Contact, MutualContact, Deleted, Bot, BotChatHistory, BotNochats, Verified, Restricted, Min, BotInlineGeo, Support, Scam, ApplyMinPhoto are boolean flags
                    var storedObject = (User)fromDb!.Object!;
                    if (user.Flags != storedObject.Flags || user.Username != storedObject.Username || user.AccessHash != storedObject.AccessHash || user.LastName != storedObject.LastName || user.FirstName != storedObject.FirstName
                        || user.Phone != storedObject.Phone || user.LangCode != storedObject.LangCode || user.BotInfoVersion != storedObject.BotInfoVersion || user.BotInlinePlaceholder != storedObject.BotInlinePlaceholder
                        || user.Restricted != storedObject.Restricted)
                    {
                        pushToDb = true;
                    }

                    if (user.Status is null && storedObject.Status is not null || user.Status is not null && storedObject.Status is null)
                    {
                        pushToDb = true;
                    }
                    else if (user.Status is not null && storedObject.Status is not null)
                    {
                        if (user.Status.GetConstructorId() == storedObject.Status.GetConstructorId())
                        {
                            if (user.Status is UserStatusOffline offline)
                            {
                                if (offline.WasOnline != ((UserStatusOffline)storedObject.Status).WasOnline)
                                {
                                    pushToDb = true;
                                }
                            }
                            else if (user.Status is UserStatusOnline online)
                            {
                                if (online.Expires != ((UserStatusOnline)storedObject.Status).Expires)
                                {
                                    pushToDb = true;
                                }
                            }
                        }
                        else
                        {
                            pushToDb = true;
                        }
                    }


                    if (storedObject.RestrictionReason is null && user.RestrictionReason is not null || storedObject.RestrictionReason is not null && user.RestrictionReason is null)
                    {
                        pushToDb = true;
                    }
                    else if (storedObject.RestrictionReason is not null && user.RestrictionReason is not null && CompareRestrictionReason(storedObject.RestrictionReason, user.RestrictionReason))
                    {
                        pushToDb = true;
                    }


                    if (storedObject.Photo is null && user.Photo is not null || storedObject.Photo is not null && user.Photo is null)
                    {
                        pushToDb = true;
                    }
                    else if (storedObject.Photo is not null && user.Photo is not null)
                    {
                        if (user.Photo.GetConstructorId() == storedObject.Photo.GetConstructorId())
                        {
                            if (user.Photo is UserProfilePhoto newPhoto)
                            {
                                var oldPhoto = (UserProfilePhoto)storedObject.Photo;
                                if (oldPhoto.PhotoId != newPhoto.PhotoId || oldPhoto.HasVideo != newPhoto.HasVideo || oldPhoto.DcId != newPhoto.DcId)
                                {
                                    pushToDb = true;
                                }

                                if (newPhoto.StrippedThumb is null && oldPhoto.StrippedThumb is not null || newPhoto.StrippedThumb is not null && oldPhoto.StrippedThumb is null ||
                                    (oldPhoto.StrippedThumb is not null && newPhoto.StrippedThumb is not null && !oldPhoto.StrippedThumb.SequenceEqual(newPhoto.StrippedThumb)))
                                {
                                    pushToDb = true;
                                }
                            }
                        }
                        else
                        {
                            pushToDb = true;
                        }
                    }
                }

                if (pushToDb)
                {
                    _logger.Information("Pushing updated User {Chat} to database", peer);
                    PushChatToDb(userObject, sqliteTransaction);
                }
            }
        }

        public void UpdateChat(ChatBase chat, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                if (chat is not Chat && chat is not ChatForbidden)
                {
                    _logger.Warning("Expected chat but {Obj} received", chat);
                    return;
                }

                var peer = IdTools.GetPeerFromObject(chat);
                _logger.Information("Trying to fetch cached peer object of chat {Chat}", peer);
                var fromDb = (DbPeer?)GetPeerObject(peer, false, sqliteTransaction);
                var pushToDb = false;

                if (fromDb is null)
                {
                    _logger.Information("Don't have peer object of chat {Chat} stored, pushing to database", peer);
                    pushToDb = true;
                }
                else if (fromDb.Object is null)
                {
                    _logger.Information("Could not deserialize store peer object of chat {Chat}, pushing new one to database", peer);
                    pushToDb = true;
                }
                else
                {
                    if (chat is Chat receivedChat)
                    {
                        if (fromDb!.Object is Chat storedChat)
                        {
                            //Creator, Kicked, Left, Deactivated, CallActive, CallNotEmpty, Noforwards are boolean-flags
                            if (receivedChat.Flags != storedChat.Flags || receivedChat.Date != storedChat.Date || receivedChat.Title != storedChat.Title || receivedChat.MigratedTo != storedChat.MigratedTo)
                            {
                                pushToDb = true;
                            }

                            if (CompareChatPhoto(storedChat.Photo, receivedChat.Photo))
                            {
                                pushToDb = true;
                            }

                            if (receivedChat.Version > storedChat.Version)
                            {
                                if (storedChat.Version + 1 != receivedChat.Version)
                                {
                                    _logger.Information("Requesting chat full of chat {ChatId} because of version mismatch", storedChat.Id);
                                    _ = _client.Api.CloudChatsApi.Messages.GetFullChatAsync(receivedChat.Id);
                                    pushToDb = false;
                                }
                                else
                                {
                                    pushToDb = true;
                                }
                            }
                        }
                        else if (fromDb.Object is ChatForbidden)
                        {
                            _logger.Information("Pushing chat object {Chat} because locally-stored is ChatForbidden", peer);
                            pushToDb = true;
                        }
                    }
                    else if (chat is ChatForbidden receivedForbidden)
                    {
                        if (fromDb!.Object is ChatForbidden storedForbidden)
                        {
                            //Creator, Kicked, Left, Deactivated, CallActive, CallNotEmpty, Noforwards are boolean-flags
                            if (storedForbidden.Title != storedForbidden.Title)
                            {
                                pushToDb = true;
                            }
                        }
                        else if (fromDb.Object is Chat)
                        {
                            _logger.Information("Pushing chat object {Chat} because locally-stored is Chat", peer);
                            pushToDb = true;
                        }
                    }
                }

                if (pushToDb)
                {
                    _logger.Information("Pushing updated chat {Chat} to database", peer);
                    PushChatToDb(chat, sqliteTransaction);
                }
            }
        }

        public void UpdateChannel(ChatBase chat, SqliteTransaction? sqliteTransaction = null)
        {
            lock (_commonMutex)
            {
                if (chat is Channel && chat is ChannelForbidden)
                {
                    _logger.Warning("Expected channel but {Obj} received", chat);
                    return;
                }

                var peer = IdTools.GetPeerFromObject(chat);
                if (chat is Channel asChannel && asChannel.Min)
                {
                    _logger.Information("Not updating channel {Channel} because a min update was received", peer);
                    return;
                }

                _logger.Information("Trying to fetch cached peer object of channel {Chat}", peer);
                var fromDb = (DbPeer?)GetPeerObject(peer, false, sqliteTransaction);
                var pushToDb = false;

                if (fromDb is null)
                {
                    _logger.Information("Don't have peer object of channel {Chat} stored, pushing to database", peer);
                    pushToDb = true;
                }
                else if (fromDb.Object is null)
                {
                    _logger.Information("Could not deserialize store peer object of channel {Chat}, pushing new one to database", peer);
                    pushToDb = true;
                }
                else
                {
                    if (chat is Channel receivedChannel)
                    {
                        if (fromDb!.Object is Channel storedChannel)
                        {
                            //Creator, Left, Broadcast, Verified, Megagroup, Restricted, Signatures, Min, Scam, HasLink, HasGeo, SlowmodeEnabled, CallActive, CallNotEmpty, Fake, Gigagroup, Noforwards
                            //are all boolean-flags
                            if (receivedChannel.Flags != storedChannel.Flags || receivedChannel.AccessHash != storedChannel.AccessHash || receivedChannel.Title != storedChannel.Title || receivedChannel.Username != storedChannel.Username
                                || receivedChannel.Date != storedChannel.Date || receivedChannel.ParticipantsCount != storedChannel.ParticipantsCount)
                            {
                                pushToDb = true;
                            }

                            if (receivedChannel.AdminRights is null && receivedChannel.AdminRights is not null || receivedChannel.AdminRights is not null && receivedChannel.AdminRights is null)
                            {
                                pushToDb = true;
                            }
                            else if (receivedChannel.AdminRights is not null && storedChannel.AdminRights is not null &&
                                    ((ChatAdminRights)receivedChannel.AdminRights).Flags != ((ChatAdminRights)storedChannel.AdminRights).Flags)
                            {
                                pushToDb = true;
                            }


                            if (receivedChannel.BannedRights is null && receivedChannel.BannedRights is not null || receivedChannel.BannedRights is not null && receivedChannel.BannedRights is null)
                            {
                                pushToDb = true;
                            }
                            else if (receivedChannel.BannedRights is not null && storedChannel.BannedRights is not null &&
                                ((ChatBannedRights)receivedChannel.BannedRights).Flags != ((ChatBannedRights)storedChannel.BannedRights).Flags)
                            {
                                pushToDb = true;
                            }


                            if (receivedChannel.DefaultBannedRights is null && receivedChannel.DefaultBannedRights is not null || receivedChannel.DefaultBannedRights is not null && receivedChannel.DefaultBannedRights is null)
                            {
                                pushToDb = true;
                            }
                            else if (receivedChannel.DefaultBannedRights is not null && storedChannel.DefaultBannedRights is not null &&
                                ((ChatBannedRights)receivedChannel.DefaultBannedRights).Flags != ((ChatBannedRights)storedChannel.DefaultBannedRights).Flags)
                            {
                                pushToDb = true;
                            }

                        }
                        else if (fromDb.Object is ChannelForbidden)
                        {
                            _logger.Information("Pushing channel object {Channel} because locally-stored is ChannelForbidden", peer);
                            pushToDb = true;
                        }
                    }
                    else if (chat is ChannelForbidden receivedForbidden)
                    {
                        if (fromDb!.Object is ChannelForbidden storedForbidden)
                        {
                            //Skipping Megagroup and Broadcast because they are boolean flags
                            if (receivedForbidden.Flags != storedForbidden.Flags || receivedForbidden.UntilDate != storedForbidden.UntilDate || receivedForbidden.Title != storedForbidden.Title || receivedForbidden.AccessHash != storedForbidden.AccessHash)
                            {
                                pushToDb = true;
                            }
                        }
                        else if (fromDb.Object is Channel)
                        {
                            _logger.Information("Pushing ChannelForbidden object {Channel} because locally-stored is Channel", peer);
                            pushToDb = true;
                        }
                    }
                }

                if (pushToDb)
                {
                    _logger.Information("Pushing updated channel {Chat} to database", peer);
                    PushChatToDb(chat, sqliteTransaction);
                }
            }
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

        public bool HavePeer(PeerId peerId)
        {
            return GetPeerObject(peerId, false) != null;
        }

        private bool CompareRestrictionReason(IList<RestrictionReasonBase> oldReasons, IList<RestrictionReasonBase> newReasons)
        {
            if (newReasons.Count == oldReasons.Count)
            {
                for (int i = 0; i < newReasons.Count; i++)
                {
                    var newReason = newReasons[i];
                    var oldReason = oldReasons[i];
                    if (newReason.Platform != oldReason.Platform || newReason.Reason != oldReason.Reason || newReason.Text != oldReason.Text)
                    {
                        return true;
                    }
                }
                return false;
            }

            return true;
        }

        private bool CompareChatPhoto(ChatPhotoBase oldChatPhotoBase, ChatPhotoBase newChatPhotoBase)
        {
            if (oldChatPhotoBase.GetConstructorId() != newChatPhotoBase.GetConstructorId())
            {
                return true;
            }

            if (oldChatPhotoBase is ChatPhotoEmpty && newChatPhotoBase is ChatPhotoEmpty)
            {
                return false;
            }

            if (oldChatPhotoBase is ChatPhoto oldPhoto && newChatPhotoBase is ChatPhoto newPhoto)
            {
                return oldPhoto.PhotoId != newPhoto.PhotoId || oldPhoto.HasVideo != newPhoto.HasVideo || oldPhoto.DcId != newPhoto.DcId || !oldPhoto.StrippedThumb.SequenceEqual(newPhoto.StrippedThumb);
            }

            return false;
        }
    }
}