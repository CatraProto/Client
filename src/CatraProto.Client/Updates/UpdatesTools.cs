using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    static class UpdatesTools
    {
        public static UpdateBase ConvertUpdate(UpdatesBase updatesBase)
        {
            UpdateBase converted;
            switch (updatesBase)
            {
                case UpdateShortMessage updateShortMessage:
                    var toNewMessage = new UpdateNewMessage();
                    var message = new Message();

                    toNewMessage.Pts = updateShortMessage.Pts;
                    toNewMessage.PtsCount = updateShortMessage.PtsCount;

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
                    throw new InvalidOperationException("Couldn't convert this object because of missing data (destination chat)");
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
                    converted = toChatMessage;
                    break;
                default:
                    throw new NotImplementedException($"{updatesBase} can't be converted");
            }

            converted.UpdateFlags();
            return converted;
        }

        public static void GetDifferenceChanges(DifferenceBase differenceBase, out IList<MessageBase> newMessages, out IList<EncryptedMessageBase> newEncryptedMessages, out IList<UpdateBase> newUpdates, out IList<ChatBase> chats, out IList<UserBase> users, out StateBase state)
        {
            switch (differenceBase)
            {
                case Difference difference:
                    newMessages = difference.NewMessages;
                    newEncryptedMessages = difference.NewEncryptedMessages;
                    newUpdates = difference.OtherUpdates;
                    chats = difference.Chats;
                    users = difference.Users;
                    state = difference.State;
                    return;
                case DifferenceSlice differenceSlice:
                    newMessages = differenceSlice.NewMessages;
                    newEncryptedMessages = differenceSlice.NewEncryptedMessages;
                    newUpdates = differenceSlice.OtherUpdates;
                    chats = differenceSlice.Chats;
                    users = differenceSlice.Users;
                    state = differenceSlice.IntermediateState;
                    return;
                default:
                    throw new InvalidOperationException($"This difference {differenceBase} result can't be extracted");
            }
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
        
        public static bool GetUpdatesData(UpdatesBase updatesBase, [MaybeNullWhen(false)]out IList<ChatBase> chats, [MaybeNullWhen(false)]out IList<UserBase> users, [MaybeNullWhen(false)]out IList<UpdateBase> updates)
        {
            switch (updatesBase)
            {
                case ApiUpdates apiUpdates:
                    chats = apiUpdates.Chats;
                    users = apiUpdates.Users;
                    updates = apiUpdates.Updates;
                    return true;
                case UpdatesCombined updatesCombined:
                    chats = updatesCombined.Chats;
                    users = updatesCombined.Users;
                    updates = updatesCombined.Updates;
                    return true;
            }

            chats = null;
            users = null;
            updates = null;
            return false;
        }

        public static bool GetPts(IObject update, out int? pts, out int? ptsCount)
        {
            switch (update)
            {
                case UpdateNewMessage updateNewMessage:
                    pts = updateNewMessage.Pts;
                    ptsCount = updateNewMessage.PtsCount;
                    return true;
                case UpdateDeleteMessages updateDeleteMessages:
                    pts = updateDeleteMessages.Pts;
                    ptsCount = updateDeleteMessages.PtsCount;
                    return true;
                case UpdateReadHistoryInbox updateReadHistoryInbox:
                    pts = updateReadHistoryInbox.Pts;
                    ptsCount = updateReadHistoryInbox.PtsCount;
                    return true;
                case UpdateReadHistoryOutbox updateReadHistoryOutbox:
                    pts = updateReadHistoryOutbox.Pts;
                    ptsCount = updateReadHistoryOutbox.PtsCount;
                    return true;
                case UpdateWebPage updateWebPage:
                    pts = updateWebPage.Pts;
                    ptsCount = updateWebPage.PtsCount;
                    return true;
                // ReSharper disable once MergeIntoPattern
                case UpdateChannelTooLong updateChannelTooLong when (updateChannelTooLong.Pts != null):
                    pts = updateChannelTooLong.Pts.Value;
                    ptsCount = 1;
                    return true;
                case UpdateNewChannelMessage updateNewChannelMessage:
                    pts = updateNewChannelMessage.Pts;
                    ptsCount = updateNewChannelMessage.PtsCount;
                    return true;
                case UpdateDeleteChannelMessages updateDeleteChannelMessages:
                    pts = updateDeleteChannelMessages.Pts;
                    ptsCount = updateDeleteChannelMessages.PtsCount;
                    return true;
                case UpdateEditChannelMessage updateEditChannelMessage:
                    pts = updateEditChannelMessage.Pts;
                    ptsCount = updateEditChannelMessage.PtsCount;
                    return true;
                case UpdateEditMessage updateEditMessage:
                    pts = updateEditMessage.Pts;
                    ptsCount = updateEditMessage.PtsCount;
                    return true;
                case UpdateChannelWebPage updateChannelWebPage:
                    pts = updateChannelWebPage.Pts;
                    ptsCount = updateChannelWebPage.PtsCount;
                    return true;
                case UpdateFolderPeers updateFolderPeers:
                    pts = updateFolderPeers.Pts;
                    ptsCount = updateFolderPeers.PtsCount;
                    return true;
                case UpdatePinnedMessages updatePinnedMessages:
                    pts = updatePinnedMessages.Pts;
                    ptsCount = updatePinnedMessages.PtsCount;
                    return true;
                case UpdateShortMessage updateShortMessage:
                    pts = updateShortMessage.Pts;
                    ptsCount = updateShortMessage.PtsCount;
                    return true;
                case UpdateShortSentMessage updateShortSentMessage:
                    pts = updateShortSentMessage.Pts;
                    ptsCount = updateShortSentMessage.PtsCount;
                    return true;
                case UpdateShortChatMessage updateShortChatMessage:
                    pts = updateShortChatMessage.Pts;
                    ptsCount = updateShortChatMessage.PtsCount;
                    return true;
            }

            pts = null;
            ptsCount = null;
            return false;
        }
        
        public static bool GetQts(IObject update, out int? qts)
        {
            switch (update)
            {
                case UpdateNewEncryptedMessage updateNewEncryptedMessage:
                    qts = updateNewEncryptedMessage.Qts;
                    return true;
                case UpdateMessagePollVote updateMessagePollVote:
                    qts = updateMessagePollVote.Qts;
                    return true;
                case UpdateChatParticipant updateChatParticipant:
                    qts = updateChatParticipant.Qts;
                    return true;
                case UpdateBotStopped updateBotStopped:
                    qts = updateBotStopped.Qts;
                    return true;
                case UpdateChannelParticipant updateChannelParticipant:
                    qts = updateChannelParticipant.Qts;
                    return true;
            }

            qts = null;
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

        public static bool IsFromChannel(IObject update, out long? channelId)
        {
            switch (update)
            {
                case UpdateChannelTooLong updateChannelTooLong:
                    channelId = updateChannelTooLong.ChannelId;
                    return true;
                case UpdateChannel updateChannel:
                    channelId = updateChannel.ChannelId;
                    return true;
                case UpdateChannelWebPage updateChannelWebPage:
                    channelId = updateChannelWebPage.ChannelId;
                    return true;
                case UpdateReadChannelInbox updateReadChannelInbox:
                    channelId = updateReadChannelInbox.ChannelId;
                    return true;
                case UpdateDeleteChannelMessages updateDeleteChannelMessages:
                    channelId = updateDeleteChannelMessages.ChannelId;
                    return true;
                case UpdateChannelMessageViews updateChannelMessageViews:
                    channelId = updateChannelMessageViews.ChannelId;
                    return true;
                case UpdateReadChannelOutbox updateReadChannelOutbox:
                    channelId = updateReadChannelOutbox.ChannelId;
                    return true;
                case UpdateChannelReadMessagesContents updateChannelReadMessagesContents:
                    channelId = updateChannelReadMessagesContents.ChannelId;
                    return true;
                case UpdateChannelAvailableMessages updateChannelAvailableMessages:
                    channelId = updateChannelAvailableMessages.ChannelId;
                    return true;
                case UpdateChannelMessageForwards updateChannelMessageForwards:
                    channelId = updateChannelMessageForwards.ChannelId;
                    return true;
                case UpdateReadChannelDiscussionInbox updateReadChannelDiscussionInbox:
                    channelId = updateReadChannelDiscussionInbox.ChannelId;
                    return true;
                case UpdateChannelUserTyping updateChannelUserTyping:
                    channelId = updateChannelUserTyping.ChannelId;
                    return true;
                case UpdatePinnedChannelMessages updatePinnedChannelMessages:
                    channelId = updatePinnedChannelMessages.ChannelId;
                    return true;
                case UpdateNewChannelMessage updateNewChannelMessage:
                {
                    switch (updateNewChannelMessage.Message)
                    {
                        case MessageService messageService:
                            channelId = messageService.PeerId.ExtractPeerId();
                            return true;
                        case Message message:
                            channelId = message.PeerId.ExtractPeerId();
                            return true;
                    }

                    break;
                }
            }

            channelId = null;
            return false;
        }
    }
}