//auto-generated
namespace CatraProto.Client.Updates
{
    static partial class UpdatesTools
    {
        public static void ExtractChats(CatraProto.TL.Interfaces.IObject obj, out System.Collections.Generic.IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>? chatsVector, out System.Collections.Generic.IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase>? usersVector)
        {
            chatsVector = null;
            usersVector = null;

            switch(obj)
            {
                case CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization authorization:
usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1){ authorization.User};
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.ApiContacts apiApiContacts:
usersVector = apiApiContacts.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContacts importedContacts:
usersVector = importedContacts.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.Blocked blocked:
chatsVector = blocked.Chats;
usersVector = blocked.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedSlice blockedSlice:
chatsVector = blockedSlice.Chats;
usersVector = blockedSlice.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.Dialogs dialogs:
chatsVector = dialogs.Chats;
usersVector = dialogs.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsSlice dialogsSlice:
chatsVector = dialogsSlice.Chats;
usersVector = dialogsSlice.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ApiMessages apiApiMessages:
chatsVector = apiApiMessages.Chats;
usersVector = apiApiMessages.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesSlice messagesSlice:
chatsVector = messagesSlice.Chats;
usersVector = messagesSlice.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChannelMessages channelMessages:
chatsVector = channelMessages.Chats;
usersVector = channelMessages.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.Chats chats:
chatsVector = chats.ChatsField;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsSlice chatsSlice:
chatsVector = chatsSlice.ChatsField;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFull chatFull:
chatsVector = chatFull.Chats;
usersVector = chatFull.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Updates.Difference difference:
chatsVector = difference.Chats;
usersVector = difference.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceSlice differenceSlice:
chatsVector = differenceSlice.Chats;
usersVector = differenceSlice.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatesCombined updatesCombined:
chatsVector = updatesCombined.Chats;
usersVector = updatesCombined.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.ApiUpdates apiApiUpdates:
chatsVector = apiApiUpdates.Chats;
usersVector = apiApiUpdates.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Photos.ApiPhotos apiApiPhotos:
usersVector = apiApiPhotos.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosSlice photosSlice:
usersVector = photosSlice.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Photos.Photo photo:
usersVector = photo.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Help.Support support:
usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1){ support.User};
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.Found found:
chatsVector = found.Chats;
usersVector = found.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRules privacyRules:
chatsVector = privacyRules.Chats;
usersVector = privacyRules.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.ChatInviteAlready chatInviteAlready:
chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1){ chatInviteAlready.Chat};
break;
case CatraProto.Client.TL.Schemas.CloudChats.ChatInvite chatInvite:
usersVector = chatInvite.Participants;
break;
case CatraProto.Client.TL.Schemas.CloudChats.ChatInvitePeek chatInvitePeek:
chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1){ chatInvitePeek.Chat};
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvedPeer resolvedPeer:
chatsVector = resolvedPeer.Chats;
usersVector = resolvedPeer.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceTooLong channelDifferenceTooLong:
chatsVector = channelDifferenceTooLong.Chats;
usersVector = channelDifferenceTooLong.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifference channelDifference:
chatsVector = channelDifference.Chats;
usersVector = channelDifference.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipants channelParticipants:
chatsVector = channelParticipants.Chats;
usersVector = channelParticipants.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipant channelParticipant:
chatsVector = channelParticipant.Chats;
usersVector = channelParticipant.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResults botResults:
usersVector = botResults.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogs peerDialogs:
chatsVector = peerDialogs.Chats;
usersVector = peerDialogs.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeers topPeers:
chatsVector = topPeers.Chats;
usersVector = topPeers.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScores highScores:
usersVector = highScores.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.PageBlockChannel pageBlockChannel:
chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1){ pageBlockChannel.Channel};
break;
case CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentForm paymentForm:
usersVector = paymentForm.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceipt paymentReceipt:
usersVector = paymentReceipt.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCall phoneCall:
usersVector = phoneCall.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResults adminLogResults:
chatsVector = adminLogResults.Chats;
usersVector = adminLogResults.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrls recentMeUrls:
chatsVector = recentMeUrls.Chats;
usersVector = recentMeUrls.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizations webAuthorizations:
usersVector = webAuthorizations.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationForm authorizationForm:
usersVector = authorizationForm.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultRequest urlAuthResultRequest:
usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1){ urlAuthResultRequest.Bot};
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChats inactiveChats:
chatsVector = inactiveChats.Chats;
usersVector = inactiveChats.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesList votesList:
usersVector = votesList.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Help.PromoData promoData:
chatsVector = promoData.Chats;
usersVector = promoData.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStats megagroupStats:
usersVector = megagroupStats.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViews messageViews:
chatsVector = messageViews.Chats;
usersVector = messageViews.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessage discussionMessage:
chatsVector = discussionMessage.Chats;
usersVector = discussionMessage.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCall groupCall:
chatsVector = groupCall.Chats;
usersVector = groupCall.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipants groupParticipants:
chatsVector = groupParticipants.Chats;
usersVector = groupParticipants.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvites exportedChatInvites:
usersVector = exportedChatInvites.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvite exportedChatInvite:
usersVector = exportedChatInvite.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteReplaced exportedChatInviteReplaced:
usersVector = exportedChatInviteReplaced.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImporters chatInviteImporters:
usersVector = chatInviteImporters.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvites chatAdminsWithInvites:
usersVector = chatAdminsWithInvites.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeers joinAsPeers:
chatsVector = joinAsPeers.Chats;
usersVector = joinAsPeers.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessages sponsoredMessages:
chatsVector = sponsoredMessages.Chats;
usersVector = sponsoredMessages.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendar searchResultsCalendar:
chatsVector = searchResultsCalendar.Chats;
usersVector = searchResultsCalendar.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeers sendAsPeers:
chatsVector = sendAsPeers.Chats;
usersVector = sendAsPeers.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Users.UserFull userFull:
chatsVector = userFull.Chats;
usersVector = userFull.Users;
break;
case CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettings peerSettings:
chatsVector = peerSettings.Chats;
usersVector = peerSettings.Users;
break;

            }

        }

        public static bool TryExtractPeerId(CatraProto.TL.Interfaces.IObject update, out CatraProto.Client.MTProto.PeerId? peerId)
        {
            switch(update)
            {
                case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateNewMessage updateNewMessage:switch(
updateNewMessage.Message)
{case CatraProto.Client.TL.Schemas.CloudChats.Message message:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
if(messageEmpty.PeerId is null)
{break;}peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserTyping updateUserTyping:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserTyping.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatUserTyping updateChatUserTyping:
peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateChatUserTyping.ChatId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipants updateChatParticipants:switch(
updateChatParticipants.Participants)
{case CatraProto.Client.TL.Schemas.CloudChats.ChatParticipants chatParticipants:
peerId = CatraProto.Client.MTProto.PeerId.AsGroup(chatParticipants.ChatId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsForbidden chatParticipantsForbidden:
peerId = CatraProto.Client.MTProto.PeerId.AsGroup(chatParticipantsForbidden.ChatId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserStatus updateUserStatus:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserStatus.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserName updateUserName:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserName.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhoto updateUserPhoto:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserPhoto.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdd updateChatParticipantAdd:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantAdd.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantDelete updateChatParticipantDelete:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantDelete.UserId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateNotifySettings updateNotifySettings:switch(
updateNotifySettings.Peer)
{case CatraProto.Client.TL.Schemas.CloudChats.NotifyPeer notifyPeer:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(notifyPeer.Peer);return true;
}
break;case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification updateServiceNotification:switch(
updateServiceNotification.Media)
{case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaContact messageMediaContact:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(messageMediaContact.UserId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhone updateUserPhone:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserPhone.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryInbox updateReadHistoryInbox:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateReadHistoryInbox.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryOutbox updateReadHistoryOutbox:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateReadHistoryOutbox.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelTooLong updateChannelTooLong:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelTooLong.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannel updateChannel:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannel.ChannelId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage updateNewChannelMessage:switch(
updateNewChannelMessage.Message)
{case CatraProto.Client.TL.Schemas.CloudChats.Message message:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
if(messageEmpty.PeerId is null)
{break;}peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox updateReadChannelInbox:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelInbox.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteChannelMessages updateDeleteChannelMessages:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateDeleteChannelMessages.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageViews updateChannelMessageViews:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelMessageViews.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdmin updateChatParticipantAdmin:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantAdmin.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineQuery updateBotInlineQuery:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotInlineQuery.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineSend updateBotInlineSend:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotInlineSend.UserId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage updateEditChannelMessage:switch(
updateEditChannelMessage.Message)
{case CatraProto.Client.TL.Schemas.CloudChats.Message message:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
if(messageEmpty.PeerId is null)
{break;}peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCallbackQuery updateBotCallbackQuery:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotCallbackQuery.UserId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage updateEditMessage:switch(
updateEditMessage.Message)
{case CatraProto.Client.TL.Schemas.CloudChats.Message message:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
if(messageEmpty.PeerId is null)
{break;}peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateInlineBotCallbackQuery updateInlineBotCallbackQuery:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateInlineBotCallbackQuery.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelOutbox updateReadChannelOutbox:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelOutbox.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateDraftMessage updateDraftMessage:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateDraftMessage.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage updateChannelWebPage:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelWebPage.ChannelId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogPinned updateDialogPinned:switch(
updateDialogPinned.Peer)
{case CatraProto.Client.TL.Schemas.CloudChats.DialogPeer dialogPeer:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(dialogPeer.Peer);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotShippingQuery updateBotShippingQuery:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotShippingQuery.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotPrecheckoutQuery updateBotPrecheckoutQuery:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotPrecheckoutQuery.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelReadMessagesContents updateChannelReadMessagesContents:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelReadMessagesContents.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelAvailableMessages updateChannelAvailableMessages:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelAvailableMessages.ChannelId);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogUnreadMark updateDialogUnreadMark:switch(
updateDialogUnreadMark.Peer)
{case CatraProto.Client.TL.Schemas.CloudChats.DialogPeer dialogPeer:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(dialogPeer.Peer);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatDefaultBannedRights updateChatDefaultBannedRights:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateChatDefaultBannedRights.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerSettings updatePeerSettings:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerSettings.Peer);return true;
case 
CatraProto.Client.TL.Schemas.CloudChats.UpdateNewScheduledMessage updateNewScheduledMessage:switch(
updateNewScheduledMessage.Message)
{case CatraProto.Client.TL.Schemas.CloudChats.Message message:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
if(messageEmpty.PeerId is null)
{break;}peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);return true;
}
break;case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteScheduledMessages updateDeleteScheduledMessages:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateDeleteScheduledMessages.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateGeoLiveViewed updateGeoLiveViewed:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateGeoLiveViewed.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePollVote updateMessagePollVote:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateMessagePollVote.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageForwards updateChannelMessageForwards:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelMessageForwards.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionInbox updateReadChannelDiscussionInbox:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelDiscussionInbox.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionOutbox updateReadChannelDiscussionOutbox:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelDiscussionOutbox.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerBlocked updatePeerBlocked:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerBlocked.PeerId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelUserTyping updateChannelUserTyping:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelUserTyping.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedMessages updatePinnedMessages:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePinnedMessages.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedChannelMessages updatePinnedChannelMessages:
peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updatePinnedChannelMessages.ChannelId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChat updateChat:
peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateChat.ChatId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateGroupCall updateGroupCall:
peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateGroupCall.ChatId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerHistoryTTL updatePeerHistoryTTL:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerHistoryTTL.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipant updateChatParticipant:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipant.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelParticipant updateChannelParticipant:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChannelParticipant.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotStopped updateBotStopped:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotStopped.UserId);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCommands updateBotCommands:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateBotCommands.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePendingJoinRequests updatePendingJoinRequests:
peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePendingJoinRequests.Peer);return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotChatInviteRequester updateBotChatInviteRequester:
peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotChatInviteRequester.UserId);return true;

            }
            
            peerId = null;
            return false;
        }        
        
        public static bool TryExtractQts(CatraProto.TL.Interfaces.IObject update, out int? qts)
        {
            switch(update)
            {
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewEncryptedMessage updateNewEncryptedMessage:
qts = updateNewEncryptedMessage.Qts;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePollVote updateMessagePollVote:
qts = updateMessagePollVote.Qts;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipant updateChatParticipant:
qts = updateChatParticipant.Qts;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelParticipant updateChannelParticipant:
qts = updateChannelParticipant.Qts;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotStopped updateBotStopped:
qts = updateBotStopped.Qts;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotChatInviteRequester updateBotChatInviteRequester:
qts = updateBotChatInviteRequester.Qts;
return true;

            }
            
            qts = null;
            return false;
        }
        
        public static bool TryExtractPts(CatraProto.TL.Interfaces.IObject update, out int? pts, out int? ptsCount)
        {
            switch(update)
            {
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewMessage updateNewMessage:
pts = updateNewMessage.Pts;
ptsCount = updateNewMessage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteMessages updateDeleteMessages:
pts = updateDeleteMessages.Pts;
ptsCount = updateDeleteMessages.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryInbox updateReadHistoryInbox:
pts = updateReadHistoryInbox.Pts;
ptsCount = updateReadHistoryInbox.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryOutbox updateReadHistoryOutbox:
pts = updateReadHistoryOutbox.Pts;
ptsCount = updateReadHistoryOutbox.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateWebPage updateWebPage:
pts = updateWebPage.Pts;
ptsCount = updateWebPage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadMessagesContents updateReadMessagesContents:
pts = updateReadMessagesContents.Pts;
ptsCount = updateReadMessagesContents.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelTooLong updateChannelTooLong:
pts = updateChannelTooLong.Pts;
ptsCount = 0;return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage updateNewChannelMessage:
pts = updateNewChannelMessage.Pts;
ptsCount = updateNewChannelMessage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox updateReadChannelInbox:
pts = updateReadChannelInbox.Pts;
ptsCount = 0;return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteChannelMessages updateDeleteChannelMessages:
pts = updateDeleteChannelMessages.Pts;
ptsCount = updateDeleteChannelMessages.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage updateEditChannelMessage:
pts = updateEditChannelMessage.Pts;
ptsCount = updateEditChannelMessage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage updateEditMessage:
pts = updateEditMessage.Pts;
ptsCount = updateEditMessage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage updateChannelWebPage:
pts = updateChannelWebPage.Pts;
ptsCount = updateChannelWebPage.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdateFolderPeers updateFolderPeers:
pts = updateFolderPeers.Pts;
ptsCount = updateFolderPeers.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedMessages updatePinnedMessages:
pts = updatePinnedMessages.Pts;
ptsCount = updatePinnedMessages.PtsCount;
return true;
case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedChannelMessages updatePinnedChannelMessages:
pts = updatePinnedChannelMessages.Pts;
ptsCount = updatePinnedChannelMessages.PtsCount;
return true;

            }
            
            pts = null;
            ptsCount = null;
            return false;
        }
    }
}