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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    internal static partial class UpdatesTools
    {
        public static UpdateBase MergeUpdate(UpdateBase updateBase)
        {
            switch (updateBase)
            {
                case UpdateNewChannelMessage ch:
                    return new UpdateNewMessage(ch.Message, -1, -1);
                case UpdateEditChannelMessage eh:
                    return new UpdateEditMessage(eh.Message, -1, -1);
                default:
                    return updateBase;
            }
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
                Chat chat => !chat.Left,
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