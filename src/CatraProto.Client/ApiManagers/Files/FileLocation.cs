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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.ApiManagers.Files.Download;
using CatraProto.Client.ApiManagers.Files.Enums;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Files;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Channels;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.CloudChats.Photos;
using CatraProto.Client.TL.Schemas.FileContexts;
using CatraProto.Client.Tools;
using CatraProto.Client.Updates;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using ChatFull = CatraProto.Client.TL.Schemas.CloudChats.ChatFull;
using Photo = CatraProto.Client.TL.Schemas.CloudChats.Photo;
using StickerSet = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet;
using UpdateTheme = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme;

namespace CatraProto.Client.ApiManagers.Files;

internal readonly struct FileLocation
{
    public long Id { get; }
    public long AccessHash { get; }
    public int DcId { get; }
    public long Size { get; }
    public List<PhotoSize>? StaticSizes { get; }
    public List<VideoSize>? VideoSizes { get; }
    public byte[] FileReference { get; }
    public FileType Type { get; }
    public ContextBase Context { get; }

    internal FileLocation(long id, long accessHash, int dcId, long size, List<PhotoSize>? staticSizes, List<VideoSize>? videoSizes, byte[] fileReference, FileType type, ContextBase context)
    {
        FileReference = fileReference;
        DcId = dcId;
        Id = id;
        AccessHash = accessHash;
        Type = type;
        Context = context;
        Size = size;
        StaticSizes = staticSizes ?? new List<PhotoSize>();
        VideoSizes = videoSizes;
    }

    public byte[] GetFileId()
    {
        var stream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
        using var writer = new Writer(MergedProvider.Singleton, stream);
        writer.WriteUInt16((ushort)UniqueIdVersion.BaseVersion);
        writer.WriteUInt16((ushort)Type);
        writer.WriteInt64(Id);
        writer.WriteInt64(AccessHash);
        writer.WriteInt32(DcId);
        writer.WriteInt64(Size);
        writer.WriteInt32(StaticSizes?.Count ?? 0);
        foreach (var size in StaticSizes ?? Enumerable.Empty<PhotoSize>())
        {
            size.Serialize(writer);
        }

        writer.WriteInt32(VideoSizes?.Count ?? 0);
        foreach (var size in VideoSizes ?? Enumerable.Empty<VideoSize>())
        {
            size.Serialize(writer);
        }

        writer.WriteBytes(FileReference);
        writer.WriteObject(Context);
        return stream.ToArray();
    }

    public byte[] GetUniqueId()
    {
        var stream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
        using var writer = new Writer(MergedProvider.Singleton, stream);
        writer.WriteUInt16((ushort)UniqueIdVersion.BaseVersion);
        writer.WriteUInt16((ushort)Type);
        writer.WriteInt64(Id);
        writer.WriteInt32(DcId);
        return stream.ToArray();
    }

    public RpcResponse<InputFileLocationBase> GetInputFile(FileDownloadOptions options)
    {
        var thumbSize = options.PhotoSize?.Type ?? options.VideoSize?.Type ?? string.Empty;
        return Type switch
        {
            FileType.Document => RpcResponse<InputFileLocationBase>.FromResult(new InputDocumentFileLocation(Id, AccessHash, FileReference, thumbSize)),
            FileType.Photo => RpcResponse<InputFileLocationBase>.FromResult(new InputPhotoFileLocation(Id, AccessHash, FileReference, thumbSize)),
            _ => RpcResponse<InputFileLocationBase>.FromError(new InternalClientError("INPUT_FILE_UNKNOWN_CONTEXT"))
        };
    }

    public static ReadResult<FileLocation> FromFileId(byte[] fileId)
    {
        using var reader = new Reader(MergedProvider.Singleton, MemoryHelper.RecyclableMemoryStreamManager.GetStream(fileId));
        var checkSize = reader.CheckLength<FileLocation>((16 + 16 + 64 + 64 + 32 + 64 + 32 + 32) / 8);
        if (checkSize.IsError)
        {
            return checkSize;
        }

        var getVersion = reader.ReadUInt16();
        var version = (FileIdVersion)getVersion.Value;
        if (version > FileIdVersion.BaseVersion)
        {
            return new ReadResult<FileLocation>($"Unsupported fileId version {getVersion.Value}", ParserErrors.ExternalError);
        }

        var getFileType = reader.ReadUInt16();

        var fileType = (FileType)getFileType.Value;
        if (fileType != FileType.Document && fileType != FileType.Photo)
        {
            return new ReadResult<FileLocation>($"Unsupported fileType {fileType}", ParserErrors.ExternalError);
        }

        var getId = reader.ReadInt64();
        var getAccessHash = reader.ReadInt64();
        var getDcId = reader.ReadInt32();
        var getSize = reader.ReadInt64();

        List<PhotoSize>? photoSizeBases = null;
        if (reader.ReadInt32().Value > 0)
        {
            reader.Stream.Seek(-4, SeekOrigin.Current);
            var getVideoSizes = reader.ReadVector<PhotoSize>(ParserTypes.Object, true);
            if (getVideoSizes.IsError)
            {
                return ReadResult<FileLocation>.Move(getVideoSizes);
            }

            photoSizeBases = getVideoSizes.Value;
        }

        List<VideoSize>? videoSizeBases = null;
        if (reader.ReadInt32().Value > 0)
        {
            reader.Stream.Seek(-4, SeekOrigin.Current);
            var getVideoSizes = reader.ReadVector<VideoSize>(ParserTypes.Object, true);
            if (getVideoSizes.IsError)
            {
                return ReadResult<FileLocation>.Move(getVideoSizes);
            }

            videoSizeBases = getVideoSizes.Value;
        }

        var getFileReference = reader.ReadBytes();
        if (getFileReference.IsError)
        {
            return ReadResult<FileLocation>.Move(getFileReference);
        }

        var getContext = reader.ReadObject<ContextBase>();
        ContextBase context;
        if (getContext.IsError)
        {
            if (getContext.GetError().ParserError is ParserErrors.InvalidConstructor)
            {
                context = new ContextUnknown();
            }
            else
            {
                return ReadResult<FileLocation>.Move(getContext);
            }
        }
        else
        {
            context = getContext.Value;
        }

        return new ReadResult<FileLocation>(new FileLocation(getId.Value, getAccessHash.Value, getDcId.Value, getSize.Value, photoSizeBases, videoSizeBases, getFileReference.Value, (FileType)getFileType.Value, context));
    }

    private static ContextBase FromSendMessage(IObject context, List<IObject> tree)
    {
        if (context is not UpdateShortSentMessage sentMessage)
        {
            return new ContextUnknown();
        }

        return tree[0] switch
        {
            SendMessage sendMessage => new ContextFromMessage(IdTools.FromApiToTd(PeerId.FromPeer(PeerTools.FromInputToPeer(sendMessage.Peer)!)), sentMessage.Id),
            SendMedia sendMedia => new ContextFromMessage(IdTools.FromApiToTd(PeerId.FromPeer(PeerTools.FromInputToPeer(sendMedia.Peer)!)), sentMessage.Id),
            _ => new ContextUnknown()
        };
    }

    private static ContextBase FromInputTheme(InputThemeBase updateTheme, string format)
    {
        return updateTheme switch
        {
            InputTheme inputTheme => new ContextFromTheme(format, string.Empty, inputTheme.Id, inputTheme.AccessHash),
            InputThemeSlug slug => new ContextFromTheme(format, slug.Slug, 0, 0),
            _ => new ContextUnknown()
        };
    }

    private static FileLocation? GetLocationFromObject(IObject obj, IObject context, List<IObject> tree)
    {
        if (context is Message { PeerId: PeerChannel } || context is MessageService { PeerId: PeerChannel } && tree.Count > 0 && tree[0] is GetAdminLog)
        {
            context = tree[0];
        }

        ContextBase? serContext = null;
        if (obj is Document document)
        {
            var findStickerSet = document.Attributes.FirstOrDefault(x => x is DocumentAttributeSticker { Stickerset: InputStickerSetID });
            if (findStickerSet is not null)
            {
                var castedSet = (InputStickerSetID)((DocumentAttributeSticker)findStickerSet).Stickerset;
                serContext = new ContextFromStickerSet(castedSet.Id, castedSet.AccessHash);
            }
        }

        serContext ??= context switch
        {
            ContextBase contextBase => contextBase,
            SearchStickerSets => new ContextUnrecoverable((int)UnrecoverableContext.SearchedStickers),
            StickerSetInstallResultArchive => new ContextFromArchivedStickers(),
            ArchivedStickers => new ContextFromArchivedStickers(),
            FeaturedStickers => new ContextFromFeaturedStickers(),
            GetUserPhotos { UserId: InputUser user } => new ContextFromPeerPhotos(IdTools.FromApiToTd(PeerId.AsUser(user.UserId))),
            GetSponsoredMessages { Channel: InputChannel ch } => new ContextFromSponsoredMessage(IdTools.FromApiToTd(PeerId.AsChannel(ch.ChannelId))),
            GetRecentMeUrls query => new ContextFromRecentMeUrl(query.Referer),
            UpdateServiceNotification => new ContextUnrecoverable((int)UnrecoverableContext.ServiceNotification),
            PremiumPromo => new ContextFromPremium(),
            SavedRingtoneConverted => new ContextFromRingtones(),
            SavedRingtone => new ContextFromRingtones(),
            AttachMenuBots => new ContextFromAttachMenu(),
            AttachMenuBotsBot => new ContextFromAttachMenu(),
            AvailableReaction => new ContextFromAvailableReactions(),
            UpdateTheme theme => FromInputTheme(theme.Theme, theme.Format),
            GetTheme getTheme => FromInputTheme(getTheme.Theme, getTheme.Format),
            FavedStickers => new ContextFromSavedStickers(),
            GetAdminLog { Channel: InputChannel ch } => new ContextFromAdminLog(ch.ChannelId),
            StickerSetMultiCovered => new ContextUnrecoverable((int)UnrecoverableContext.StickerSetCovered),
            StickerSetCovered => new ContextUnrecoverable((int)UnrecoverableContext.StickerSetCovered),
            GetRecentStickers getRecentStickers => new ContextFromRecentStickers(getRecentStickers.Attached),
            BotInlineMediaResult => new ContextUnrecoverable((int)UnrecoverableContext.InlineResult),
            BotResults => new ContextUnrecoverable((int)UnrecoverableContext.InlineResult),
            SavedGifs => new ContextFromSavedGifs(),
            StickerSet stickerSet => new ContextFromStickerSet(stickerSet.Set.Id, stickerSet.Set.AccessHash),
            CheckChatInvite chatInvite => new ContextFromChatInvite(chatInvite.Hash),
            WebPage webPage => new ContextFromWebPage(webPage.Url),
            GetStickers query => new ContextFromGetStickers(query.Emoticon),
            GetAppUpdate appUpdate => new ContextFromAppUpdate(appUpdate.Source),
            UploadProfilePhoto => new ContextFromOwnPhotos(),
            UpdateProfilePhoto => new ContextFromOwnPhotos(),
            WallPaper wallPaper => new ContextFromWallPaper(wallPaper.Id, wallPaper.AccessHash),
            UserFull userFull => new ContextFromPeerFull(IdTools.FromApiToTd(userFull.Id, PeerType.User)),
            ChannelFull channelFull => new ContextFromPeerFull(IdTools.FromApiToTd(channelFull.Id, PeerType.Channel)),
            ChatFull chatFull => new ContextFromPeerFull(IdTools.FromApiToTd(chatFull.Id, PeerType.Group)),
            Message message => new ContextFromMessage(IdTools.FromApiToTd(PeerId.FromPeer(message.PeerId)), message.Id),
            MessageService msgService => new ContextFromMessage(IdTools.FromApiToTd(PeerId.FromPeer(msgService.PeerId)), msgService.Id),
            UpdateShortSentMessage => FromSendMessage(context, tree),
            UpdateShortMessage shortMsg => new ContextFromMessage(IdTools.FromApiToTd(shortMsg.UserId, PeerType.User), shortMsg.Id),
            UpdateShortChatMessage shortChatMsg => new ContextFromMessage(IdTools.FromApiToTd(shortChatMsg.ChatId, PeerType.Group), shortChatMsg.Id),
            _ => new ContextUnknown(),
        };

        switch (obj)
        {
            case Document doc:
                {
                    var newSizes = doc.Thumbs?
                        .OfType<PhotoSize>()
                        .ToList();
                    return new FileLocation(doc.Id, doc.AccessHash, doc.DcId, doc.Size, newSizes, doc.VideoThumbs?.OfType<VideoSize>().ToList(), doc.FileReference, FileType.Document, serContext);
                }
            case Photo photo:
                {
                    var newSizes = photo.Sizes
                        .OfType<PhotoSize>()
                        .ToList();

                    var biggestSize = newSizes
                        .OrderByDescending(x => x.Size)
                        .Select(x => x.Size)
                        .FirstOrDefault(0);

                    return new FileLocation(photo.Id, photo.AccessHash, photo.DcId, biggestSize, newSizes, photo.VideoSizes?.OfType<VideoSize>().ToList(), photo.FileReference, FileType.Photo, serContext);
                }
        }

        return null;
    }

    public static void UpdateId(IObject obj, IObject context, List<IObject> tree)
    {
        var getLoc = GetLocationFromObject(obj, context, tree);
        if (!getLoc.HasValue)
        {
            return;
        }

        switch (obj)
        {
            case Document document:
                document.FileId = new FileId(getLoc.Value);
                break;
            case Photo photo:
                photo.FileId = new FileId(getLoc.Value);
                break;
        }
    }

    public static async Task<RpcResponse<FileLocation>> RefreshFileReferenceAsync(TelegramClient client, FileLocation oldFileLocation, CancellationToken cancellationToken = default)
    {
        IEnumerable<IObject>? objectToWalkThrough = null;
        IRpcResponse? response = null;
        var logger = client.GetLogger<FileLocation>();

        var context = oldFileLocation.Context;
        if (oldFileLocation.Context is ContextFromOwnPhotos)
        {
            var getSelf = await client.Api.CloudChatsApi.Users.GetSelfAsync(cancellationToken);
            if (getSelf.RpcCallFailed)
            {
                return RpcResponse<FileLocation>.FromError(getSelf.Error);
            }

            context = new ContextFromPeerPhotos(PeerId.AsUser(getSelf.Response.Id).ToDatabase());
        }

        switch (context)
        {
            case ContextFromPeerPhotos contextFromPeerPhotos:
                response = await client.Api.CloudChatsApi.Photos.GetUserPhotosAsync(PeerId.FromDatabase(contextFromPeerPhotos.Peer).Id, 0, oldFileLocation.Id + 1, 1, cancellationToken: cancellationToken);
                break;
            case ContextFromTheme contextFromTheme:
                InputThemeBase inputTheme = contextFromTheme.Slug.Length > 0 ? new InputThemeSlug(contextFromTheme.Slug) : new InputTheme(contextFromTheme.Id, contextFromTheme.AccessHash);
                response = await client.Api.CloudChatsApi.Account.GetThemeAsync(contextFromTheme.Format, inputTheme, oldFileLocation.Id, cancellationToken: cancellationToken);
                break;
            case ContextFromRingtones contextFromRingtones:
                response = await client.Api.CloudChatsApi.Account.GetSavedRingtonesAsync(0, cancellationToken: cancellationToken);
                break;
            case ContextFromSavedGifs contextFromSavedGifs:
                response = await client.Api.CloudChatsApi.Messages.GetSavedGifsAsync(0, cancellationToken: cancellationToken);
                break;
            case ContextFromSponsoredMessage contextFromSponsoredMessage:
                response = await client.Api.CloudChatsApi.Channels.GetSponsoredMessagesAsync(PeerId.FromDatabase(contextFromSponsoredMessage.Id).Id, cancellationToken: cancellationToken);
                break;
            case ContextFromAppUpdate contextFromAppUpdate:
                response = await client.Api.CloudChatsApi.Help.GetAppUpdateAsync(contextFromAppUpdate.Source, cancellationToken: cancellationToken);
                break;
            case ContextFromAttachMenu contextFromAttachMenu:
                response = await client.Api.CloudChatsApi.Messages.GetAttachMenuBotsAsync(0, cancellationToken: cancellationToken);
                break;
            case ContextFromAvailableReactions:
                response = await client.Api.CloudChatsApi.Messages.GetAvailableReactionsAsync(0, cancellationToken: cancellationToken);
                break;
            case ContextFromChatInvite contextFromChatInvite:
                response = await client.Api.CloudChatsApi.Messages.CheckChatInviteAsync(contextFromChatInvite.Hash, cancellationToken: cancellationToken);
                break;
            case ContextFromWebPage contextFromWebPage:
                response = await client.Api.CloudChatsApi.Messages.GetWebPageAsync(contextFromWebPage.Url, 0, cancellationToken: cancellationToken);
                break;
            case ContextFromRecentStickers contextFromRecentStickers:
                response = await client.Api.CloudChatsApi.Messages.GetRecentStickersAsync(0, contextFromRecentStickers.IsAttached, cancellationToken: cancellationToken);
                break;
            case ContextFromGetStickers contextFromGetStickers:
                response = await client.Api.CloudChatsApi.Messages.GetStickersAsync(contextFromGetStickers.Emoji, 0, cancellationToken: cancellationToken);
                break;
            case ContextFromStickerSet contextFromStickerSet:
                response = await client.Api.CloudChatsApi.Messages.GetStickerSetAsync(new InputStickerSetID(contextFromStickerSet.Id, contextFromStickerSet.AccessHash), 0, cancellationToken: cancellationToken);
                break;
            case ContextFromPeerFull contextFromPeerFull:
                response = await client.DatabaseManager.PeerDatabase.GetFullPeerAsync<IObject>(PeerId.FromDatabase(contextFromPeerFull.Peer), 0, true, cancellationToken);
                break;
            case ContextFromWallPaper wallPaper:
                response = await client.Api.CloudChatsApi.Account.GetWallPaperAsync(new InputWallPaper(wallPaper.Id, wallPaper.AccessHash), cancellationToken: cancellationToken);
                break;
            case ContextFromMessage message:
                var getPeer = PeerId.FromDatabase(message.Peer);
                var messagesToGet = new List<InputMessageBase>(1)
                {
                    new InputMessageID(message.MsgId)
                };
                if (getPeer.Type is PeerType.Channel)
                {
                    response = await client.Api.CloudChatsApi.Channels.GetMessagesAsync(getPeer.Id, messagesToGet, messageSendingOptions: new MessageSendingOptions(TimeSpan.FromSeconds(30)), cancellationToken: cancellationToken);
                }
                else
                {
                    response = await client.Api.CloudChatsApi.Messages.GetMessagesAsync(messagesToGet, messageSendingOptions: new MessageSendingOptions(TimeSpan.FromSeconds(30)), cancellationToken: cancellationToken);
                }

                break;
            case ContextFromPremium contextFromPremium:
                response = await client.Api.CloudChatsApi.Help.GetPremiumPromoAsync(cancellationToken: cancellationToken);
                break;
            case ContextFromRecentMeUrl contextFromRecentMeUrl:
                response = await client.Api.CloudChatsApi.Help.GetRecentMeUrlsAsync(contextFromRecentMeUrl.Referer, cancellationToken: cancellationToken);
                break;
            case ContextFromArchivedStickers contextFromArchivedStickers:
                // TODO WITH PAGINATION
                break;
            case ContextFromOwnPhotos contextFromOwnPhotos:
                // Unreachable
                break;
            case ContextUnknown contextUnknown:
                break;
            case ContextUnrecoverable contextUnrecoverable:
                break;
            case ContextFromAdminLog contextFromAdminLog:
                // TODO WITH PAGINATION
                break;
            case ContextFromSavedStickers contextFromSavedStickers:
                break;
        }

        if (response is not null)
        {
            if (response.RpcCallFailed)
            {
                if (response.Error.ErrorCode != 500 && response.Error is not FloodWaitError)
                {
                    logger.Information("File access to file with id {FileId} is now forbidden due to error {Error}", oldFileLocation.Id, response.Error);
                    return RpcResponse<FileLocation>.FromError(new FileAccessForbidden());
                }

                logger.Information("Failed to recover context for file with id {FileId} due to error {Error}", oldFileLocation.Id, response.Error);
                return RpcResponse<FileLocation>.FromError(response.Error);
            }

            if (objectToWalkThrough is null)
            {
                switch (response.Response)
                {
                    case IList { Count: > 0 } iList when iList[0] is IObject:
                        objectToWalkThrough = iList.Cast<IObject>();
                        break;
                    case IList { Count: 0 }:
                        objectToWalkThrough = Enumerable.Empty<IObject>();
                        break;
                    case IObject iObj:
                        objectToWalkThrough = Enumerable.Repeat(iObj, 1);
                        break;
                    default:
                        logger.Error("Invalid response received for context recovering. Received object {Obj}", response.Response);
                        return RpcResponse<FileLocation>.FromError(new InternalClientError("CONTEXT_RECOVERING_FAILED", "The recovery of the context failed because an invalid response was received"));
                }
            }
        }
        else if (objectToWalkThrough is null && response is null)
        {
            logger.Error("Failed to recover context {Context}", oldFileLocation.Context);
            return RpcResponse<FileLocation>.FromError(new InternalClientError("CONTEXT_RECOVER_FAILED", "The recovery of the context failed because no attempt was made"));
        }

        List<IObject>? tree = null;
        IObject? docObject = null;
        foreach (var obj in objectToWalkThrough ?? Enumerable.Empty<IObject>())
        {
            UpdatesTools.OnFileReceived(obj, obj, false, null, (finalObject, _, receivedTree) =>
            {
                tree = receivedTree;
                switch (finalObject)
                {
                    case Document document when document.Id == oldFileLocation.Id:
                        docObject = document;
                        break;
                    case Photo photo when photo.Id == oldFileLocation.Id:
                        docObject = photo;
                        break;
                }
            });
        }

        if (docObject is not null && tree is not null)
        {
            var getLoc = GetLocationFromObject(docObject, context, tree);
            if (!getLoc.HasValue)
            {
                return RpcResponse<FileLocation>.FromError(new FileAccessForbidden());
            }

            client.FileManager.NotifyNewFileId(oldFileLocation.GetFileId(), getLoc.Value.GetFileId());
            return RpcResponse<FileLocation>.FromResult(getLoc.Value);
        }

        logger.Information("Failed to refresh file reference, object id was not found in the context");
        return RpcResponse<FileLocation>.FromError(new FileAccessForbidden());
    }
}