using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    static class Tools
    {
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

        public static bool IsFromChannel(IObject update, out int? channelId)
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