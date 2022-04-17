using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.Tools;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    static partial class UpdatesTools
    {
        public static UpdateBase ConvertUpdate(UpdatesBase updatesBase, IMethod? query = null)
        {
            UpdateBase converted;
            switch (updatesBase)
            {
                case UpdateShortMessage updateShortMessage:
                    var toNewMessage = new UpdateNewMessage();
                    var message = new Message();

                    toNewMessage.Pts = updateShortMessage.Pts;
                    toNewMessage.PtsCount = updateShortMessage.PtsCount;
                    toNewMessage.Message = message;

                    message.Date = updateShortMessage.Date;
                    message.Out = updateShortMessage.Out;
                    message.Mentioned = updateShortMessage.Mentioned;
                    message.MediaUnread = updateShortMessage.MediaUnread;
                    message.Silent = updateShortMessage.Silent;
                    message.Id = updateShortMessage.Id;
                    message.PeerId = new PeerUser { UserId = updateShortMessage.UserId };
                    message.MessageField = updateShortMessage.Message;
                    message.FwdFrom = updateShortMessage.FwdFrom;
                    message.ViaBotId = updateShortMessage.ViaBotId;
                    message.ReplyTo = updateShortMessage.ReplyTo;
                    message.Entities = updateShortMessage.Entities;
                    message.TtlPeriod = updateShortMessage.TtlPeriod;

                    converted = toNewMessage;
                    break;
                case UpdateShort updateShort:
                    return updateShort.Update;
                case UpdateShortSentMessage updateShortSentMessage:
                    if (query is null)
                    {
                        throw new ArgumentNullException(nameof(query));
                    }

                    if (query is not SendMessage sendMessage)
                    {
                        throw new InvalidOperationException($"Received updateShortSentMessage from method {query}");
                    }

                    var messageObj = new Message()
                    {
                        PeerId = PeerTools.FromInputToPeer(sendMessage.Peer),
                        Media = updateShortSentMessage.Media,
                        Date = updateShortSentMessage.Date,
                        TtlPeriod = updateShortSentMessage.TtlPeriod,
                        Entities = updateShortSentMessage.Entities,
                        Out = updateShortSentMessage.Out,
                        Id = updateShortSentMessage.Id,
                        MessageField = sendMessage.Message
                    };

                    converted = sendMessage.Peer switch
                    {
                        InputPeerChannel => new UpdateNewChannelMessage() { Message = messageObj, Pts = updateShortSentMessage.Pts, PtsCount = updateShortSentMessage.PtsCount },
                        _ => new UpdateNewMessage { Message = messageObj, Pts = updateShortSentMessage.Pts, PtsCount = updateShortSentMessage.PtsCount }
                    };
                    messageObj.UpdateFlags();
                    break;
                case UpdateShortChatMessage updateShortChatMessage:
                    var toChatMessage = new UpdateNewMessage();
                    var originalMessage = new Message();
                    toChatMessage.Pts = updateShortChatMessage.Pts;
                    toChatMessage.PtsCount = updateShortChatMessage.PtsCount;

                    originalMessage.Date = updateShortChatMessage.Date;
                    originalMessage.Out = updateShortChatMessage.Out;
                    originalMessage.Mentioned = updateShortChatMessage.Mentioned;
                    originalMessage.MediaUnread = updateShortChatMessage.MediaUnread;
                    originalMessage.Silent = updateShortChatMessage.Silent;
                    originalMessage.Id = updateShortChatMessage.Id;
                    originalMessage.PeerId = new PeerChat() { ChatId = updateShortChatMessage.ChatId };
                    originalMessage.MessageField = updateShortChatMessage.Message;
                    originalMessage.FwdFrom = updateShortChatMessage.FwdFrom;
                    originalMessage.ViaBotId = updateShortChatMessage.ViaBotId;
                    originalMessage.ReplyTo = updateShortChatMessage.ReplyTo;
                    originalMessage.Entities = updateShortChatMessage.Entities;
                    originalMessage.TtlPeriod = updateShortChatMessage.TtlPeriod;
                    toChatMessage.Message = originalMessage;
                    converted = toChatMessage;
                    break;
                default:
                    throw new NotImplementedException($"{updatesBase} can't be converted");
            }

            converted.UpdateFlags();
            return converted;
        }

        public static UpdateBase FromMessageToUpdate(MessageBase messageBase)
        {
            UpdateBase? updateBase = null;
            switch (messageBase)
            {
                case Message { PeerId: PeerChat or PeerUser } message:
                {
                    updateBase = new UpdateNewMessage
                    {
                        Pts = -1,
                        PtsCount = -1,
                        Message = message
                    };
                    break;
                }
                case Message message:
                {
                    updateBase = new UpdateNewChannelMessage
                    {
                        Message = message,
                        Pts = -1,
                        PtsCount = -1
                    };
                    break;
                }
                case MessageService { PeerId: PeerChat or PeerUser } messageService:
                {
                    updateBase = new UpdateNewMessage
                    {
                        Pts = -1,
                        PtsCount = -1,
                        Message = messageService
                    };
                    break;
                }
                case MessageService messageService:
                {
                    updateBase = new UpdateNewChannelMessage
                    {
                        Message = messageService,
                        Pts = -1,
                        PtsCount = -1
                    };
                    break;
                }
                case MessageEmpty { PeerId: PeerChat or PeerUser } messageEmpty:
                {
                    updateBase = new UpdateNewMessage
                    {
                        Pts = -1,
                        PtsCount = -1,
                        Message = messageEmpty
                    };
                    break;
                }
                case MessageEmpty messageEmpty:
                {
                    updateBase = new UpdateNewChannelMessage
                    {
                        Message = messageEmpty,
                        Pts = -1,
                        PtsCount = -1
                    };
                    break;
                }
            }

            return updateBase!;
        }

        public static bool GetSeq(UpdatesBase updatesBase, out int? finalSeq, out int? seqStart, out int? date)
        {
            switch (updatesBase)
            {
                case ApiUpdates apiUpdates:
                    finalSeq = apiUpdates.Seq;
                    seqStart = apiUpdates.Seq;
                    date = apiUpdates.Date;
                    return true;
                case UpdatesCombined updatesCombined:
                    finalSeq = updatesCombined.Seq;
                    seqStart = updatesCombined.SeqStart;
                    date = updatesCombined.Date;
                    return true;
            }

            date = null;
            finalSeq = null;
            seqStart = null;
            return false;
        }

        public static bool GetUpdatesData(UpdatesBase updatesBase, [MaybeNullWhen(false)] out IList<UpdateBase> updates)
        {
            switch (updatesBase)
            {
                case ApiUpdates apiUpdates:
                    updates = apiUpdates.Updates;
                    return true;
                case UpdatesCombined updatesCombined:
                    updates = updatesCombined.Updates;
                    return true;
            }

            updates = null;
            return false;
        }

        public static bool GetApplyOnPts(IObject update, out int? pts)
        {
            switch (update)
            {
                case UpdateReadChannelInbox updateReadChannelInbox:
                    pts = updateReadChannelInbox.Pts;
                    return true;
            }

            pts = null;
            return false;
        }

        public static bool TryExtractChannelId(ChatBase chatBase, out long? channelId)
        {
            channelId = chatBase switch
            {
                Channel channel => channel.Id,
                ChannelForbidden channelForbidden => channelForbidden.Id,
                _ => null
            };

            return channelId is not null;
        }

        public static bool IsInChat(ChatBase chatBase)
        {
            return chatBase switch
            {
                Chat chat => !(chat.Kicked || chat.Left),
                ChatEmpty => false,
                ChatForbidden => false,
                Channel channel => !channel.Left,
                ChannelForbidden => false,
                _ => false
            };
        }

        public static bool IsFromChannel(IObject update, out long? channelId)
        {
            if (!TryExtractQts(update, out _) && TryExtractPeerId(update, out var peerId))
            {
                if (peerId?.Type is PeerType.Channel)
                {
                    channelId = peerId.Value.Id;
                    return true;
                }
            }

            channelId = null;
            return false;
        }
    }
}