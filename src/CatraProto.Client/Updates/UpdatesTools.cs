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
    internal static partial class UpdatesTools
    {
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