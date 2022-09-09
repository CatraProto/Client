//auto-generated

using System;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    static partial class UpdatesTools
    {
        public static void ExtractChats(CatraProto.TL.Interfaces.IObject obj, out System.Collections.Generic.IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>? chatsVector, out System.Collections.Generic.IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase>? usersVector)
        {
            chatsVector = null;
            usersVector = null;

            switch (obj)
            {
                case CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization authorization:
                    usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1) { authorization.User };
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
                    usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1) { support.User };
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
                    chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1) { chatInviteAlready.Chat };
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChatInvite chatInvite:
                    usersVector = chatInvite.Participants;
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChatInvitePeek chatInvitePeek:
                    chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1) { chatInvitePeek.Chat };
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
                    chatsVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(1) { pageBlockChannel.Channel };
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
                    usersVector = new System.Collections.Generic.List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(1) { urlAuthResultRequest.Bot };
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
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsList messageReactionsList:
                    chatsVector = messageReactionsList.Chats;
                    usersVector = messageReactionsList.Users;
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBots attachMenuBots:
                    usersVector = attachMenuBots.Users;
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBot attachMenuBotsBot:
                    usersVector = attachMenuBotsBot.Users;
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromo premiumPromo:
                    usersVector = premiumPromo.Users;
                    break;
            }
        }

        public static bool TryExtractPeerId(CatraProto.TL.Interfaces.IObject update, out CatraProto.Client.MTProto.PeerId? peerId)
        {
            switch (update)
            {
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateNewMessage updateNewMessage:
                    switch (
                        updateNewMessage.Message)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.Message message:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
                            if (messageEmpty.PeerId is null)
                            {
                                break;
                            }

                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserTyping updateUserTyping:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserTyping.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatUserTyping updateChatUserTyping:
                    peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateChatUserTyping.ChatId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipants updateChatParticipants:
                    switch (
                        updateChatParticipants.Participants)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.ChatParticipants chatParticipants:
                            peerId = CatraProto.Client.MTProto.PeerId.AsGroup(chatParticipants.ChatId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsForbidden chatParticipantsForbidden:
                            peerId = CatraProto.Client.MTProto.PeerId.AsGroup(chatParticipantsForbidden.ChatId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserStatus updateUserStatus:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserStatus.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserName updateUserName:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserName.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhoto updateUserPhoto:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserPhoto.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdd updateChatParticipantAdd:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantAdd.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantDelete updateChatParticipantDelete:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantDelete.UserId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateNotifySettings updateNotifySettings:
                    switch (
                        updateNotifySettings.Peer)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.NotifyPeer notifyPeer:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(notifyPeer.Peer);
                            return true;
                    }

                    break;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification updateServiceNotification:
                    switch (
                        updateServiceNotification.Media)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaContact messageMediaContact:
                            peerId = CatraProto.Client.MTProto.PeerId.AsUser(messageMediaContact.UserId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhone updateUserPhone:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateUserPhone.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryInbox updateReadHistoryInbox:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateReadHistoryInbox.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryOutbox updateReadHistoryOutbox:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateReadHistoryOutbox.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelTooLong updateChannelTooLong:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelTooLong.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannel updateChannel:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannel.ChannelId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage updateNewChannelMessage:
                    switch (
                        updateNewChannelMessage.Message)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.Message message:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
                            if (messageEmpty.PeerId is null)
                            {
                                break;
                            }

                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox updateReadChannelInbox:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelInbox.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteChannelMessages updateDeleteChannelMessages:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateDeleteChannelMessages.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageViews updateChannelMessageViews:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelMessageViews.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdmin updateChatParticipantAdmin:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipantAdmin.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineQuery updateBotInlineQuery:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotInlineQuery.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineSend updateBotInlineSend:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotInlineSend.UserId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage updateEditChannelMessage:
                    switch (
                        updateEditChannelMessage.Message)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.Message message:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
                            if (messageEmpty.PeerId is null)
                            {
                                break;
                            }

                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCallbackQuery updateBotCallbackQuery:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotCallbackQuery.UserId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage updateEditMessage:
                    switch (
                        updateEditMessage.Message)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.Message message:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
                            if (messageEmpty.PeerId is null)
                            {
                                break;
                            }

                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateInlineBotCallbackQuery updateInlineBotCallbackQuery:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateInlineBotCallbackQuery.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelOutbox updateReadChannelOutbox:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelOutbox.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateDraftMessage updateDraftMessage:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateDraftMessage.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage updateChannelWebPage:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelWebPage.ChannelId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogPinned updateDialogPinned:
                    switch (
                        updateDialogPinned.Peer)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.DialogPeer dialogPeer:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(dialogPeer.Peer);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotShippingQuery updateBotShippingQuery:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotShippingQuery.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotPrecheckoutQuery updateBotPrecheckoutQuery:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotPrecheckoutQuery.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelReadMessagesContents updateChannelReadMessagesContents:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelReadMessagesContents.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelAvailableMessages updateChannelAvailableMessages:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelAvailableMessages.ChannelId);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogUnreadMark updateDialogUnreadMark:
                    switch (
                        updateDialogUnreadMark.Peer)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.DialogPeer dialogPeer:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(dialogPeer.Peer);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatDefaultBannedRights updateChatDefaultBannedRights:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateChatDefaultBannedRights.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerSettings updatePeerSettings:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerSettings.Peer);
                    return true;
                case
                    CatraProto.Client.TL.Schemas.CloudChats.UpdateNewScheduledMessage updateNewScheduledMessage:
                    switch (
                        updateNewScheduledMessage.Message)
                    {
                        case CatraProto.Client.TL.Schemas.CloudChats.Message message:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(message.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageService messageService:
                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageService.PeerId);
                            return true;
                        case CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty messageEmpty:
                            if (messageEmpty.PeerId is null)
                            {
                                break;
                            }

                            peerId = CatraProto.Client.MTProto.PeerId.FromPeer(messageEmpty.PeerId);
                            return true;
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteScheduledMessages updateDeleteScheduledMessages:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateDeleteScheduledMessages.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateGeoLiveViewed updateGeoLiveViewed:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateGeoLiveViewed.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePollVote updateMessagePollVote:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateMessagePollVote.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageForwards updateChannelMessageForwards:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelMessageForwards.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionInbox updateReadChannelDiscussionInbox:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelDiscussionInbox.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionOutbox updateReadChannelDiscussionOutbox:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateReadChannelDiscussionOutbox.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerBlocked updatePeerBlocked:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerBlocked.PeerId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelUserTyping updateChannelUserTyping:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updateChannelUserTyping.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedMessages updatePinnedMessages:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePinnedMessages.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedChannelMessages updatePinnedChannelMessages:
                    peerId = CatraProto.Client.MTProto.PeerId.AsChannel(updatePinnedChannelMessages.ChannelId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChat updateChat:
                    peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateChat.ChatId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateGroupCall updateGroupCall:
                    peerId = CatraProto.Client.MTProto.PeerId.AsGroup(updateGroupCall.ChatId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerHistoryTTL updatePeerHistoryTTL:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePeerHistoryTTL.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipant updateChatParticipant:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChatParticipant.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelParticipant updateChannelParticipant:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateChannelParticipant.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotStopped updateBotStopped:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotStopped.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCommands updateBotCommands:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateBotCommands.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatePendingJoinRequests updatePendingJoinRequests:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updatePendingJoinRequests.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateBotChatInviteRequester updateBotChatInviteRequester:
                    peerId = CatraProto.Client.MTProto.PeerId.AsUser(updateBotChatInviteRequester.UserId);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateMessageReactions updateMessageReactions:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateMessageReactions.Peer);
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateTranscribedAudio updateTranscribedAudio:
                    peerId = CatraProto.Client.MTProto.PeerId.FromPeer(updateTranscribedAudio.Peer);
                    return true;
            }

            peerId = null;
            return false;
        }

        public static bool TryExtractQts(CatraProto.TL.Interfaces.IObject update, out int? qts)
        {
            switch (update)
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
            switch (update)
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
                    ptsCount = 0;
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage updateNewChannelMessage:
                    pts = updateNewChannelMessage.Pts;
                    ptsCount = updateNewChannelMessage.PtsCount;
                    return true;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox updateReadChannelInbox:
                    pts = updateReadChannelInbox.Pts;
                    ptsCount = 0;
                    return true;
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

        public static void OnFileReceived(CatraProto.TL.Interfaces.IObject socketObject, CatraProto.TL.Interfaces.IObject context, bool preserveContext, List<IObject>? tree = null, Action<IObject, IObject, List<IObject>>? callback = null)
        {
            callback ??= (cSocketObject, cContext, cTree) => CatraProto.Client.ApiManagers.Files.FileLocation.UpdateId(cSocketObject, cContext, cTree);
            if (tree is null)
            {
                tree ??= new List<IObject>();
                if (context is not CatraProto.Client.TL.Schemas.CloudChats.Document && socketObject is not CatraProto.Client.TL.Schemas.CloudChats.Photo)
                {
                    tree.Add(context);
                }

                if (socketObject is not CatraProto.Client.TL.Schemas.CloudChats.Document && socketObject is not CatraProto.Client.TL.Schemas.CloudChats.Photo && socketObject != context)
                {
                    tree.Add(socketObject);
                }
            }

            switch (socketObject)
            {
                case CatraProto.Client.TL.Schemas.CloudChats.ChatFull catraProtoClientTLSchemasCloudChatsChatFull:
                    if (catraProtoClientTLSchemasCloudChatsChatFull.ChatPhoto is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsChatFull.ChatPhoto);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChatFull.ChatPhoto, catraProtoClientTLSchemasCloudChatsChatFull, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelFull catraProtoClientTLSchemasCloudChatsChannelFull:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelFull.ChatPhoto);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelFull.ChatPhoto, catraProtoClientTLSchemasCloudChatsChannelFull, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaPhoto catraProtoClientTLSchemasCloudChatsMessageMediaPhoto:
                    if (catraProtoClientTLSchemasCloudChatsMessageMediaPhoto.Photo is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageMediaPhoto.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageMediaPhoto.Photo, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessageMediaPhoto, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaDocument catraProtoClientTLSchemasCloudChatsMessageMediaDocument:
                    if (catraProtoClientTLSchemasCloudChatsMessageMediaDocument.Document is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageMediaDocument.Document);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageMediaDocument.Document, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessageMediaDocument, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditPhoto catraProtoClientTLSchemasCloudChatsMessageActionChatEditPhoto:
                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageActionChatEditPhoto.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageActionChatEditPhoto.Photo, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessageActionChatEditPhoto, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.WallPaper catraProtoClientTLSchemasCloudChatsWallPaper:
                    tree.Add(catraProtoClientTLSchemasCloudChatsWallPaper.Document);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsWallPaper.Document, catraProtoClientTLSchemasCloudChatsWallPaper, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UserFull catraProtoClientTLSchemasCloudChatsUserFull:
                    if (catraProtoClientTLSchemasCloudChatsUserFull.ProfilePhoto is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsUserFull.ProfilePhoto);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUserFull.ProfilePhoto, catraProtoClientTLSchemasCloudChatsUserFull, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Photos.ApiPhotos catraProtoClientTLSchemasCloudChatsPhotosApiPhotos:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsPhotosApiPhotos.Photos)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsPhotosApiPhotos, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosSlice catraProtoClientTLSchemasCloudChatsPhotosPhotosSlice:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsPhotosPhotosSlice.Photos)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsPhotosPhotosSlice, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Photos.Photo catraProtoClientTLSchemasCloudChatsPhotosPhoto:
                    tree.Add(catraProtoClientTLSchemasCloudChatsPhotosPhoto.PhotoField);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsPhotosPhoto.PhotoField, preserveContext ? context : catraProtoClientTLSchemasCloudChatsPhotosPhoto, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdate catraProtoClientTLSchemasCloudChatsHelpAppUpdate:
                    if (catraProtoClientTLSchemasCloudChatsHelpAppUpdate.Document is null)
                    {
                        break;
                    }

                    var catraProtoClientTLSchemasCloudChatsHelpAppUpdateTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsHelpAppUpdateTree0.Add(catraProtoClientTLSchemasCloudChatsHelpAppUpdate.Document);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsHelpAppUpdate.Document, preserveContext ? context : catraProtoClientTLSchemasCloudChatsHelpAppUpdate, preserveContext, catraProtoClientTLSchemasCloudChatsHelpAppUpdateTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.Stickers catraProtoClientTLSchemasCloudChatsMessagesStickers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesStickers.StickersField)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesStickers, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.WebPage catraProtoClientTLSchemasCloudChatsWebPage:
                    if (catraProtoClientTLSchemasCloudChatsWebPage.Photo is null)
                    {
                        break;
                    }

                    var catraProtoClientTLSchemasCloudChatsWebPageTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsWebPageTree0.Add(catraProtoClientTLSchemasCloudChatsWebPage.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsWebPage.Photo, catraProtoClientTLSchemasCloudChatsWebPage, true, catraProtoClientTLSchemasCloudChatsWebPageTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChatInvite catraProtoClientTLSchemasCloudChatsChatInvite:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChatInvite.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChatInvite.Photo, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChatInvite, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet catraProtoClientTLSchemasCloudChatsMessagesStickerSet:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesStickerSet.Documents)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesStickerSet, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.BotInfo catraProtoClientTLSchemasCloudChatsBotInfo:
                    if (catraProtoClientTLSchemasCloudChatsBotInfo.DescriptionPhoto is null)
                    {
                        break;
                    }

                    var catraProtoClientTLSchemasCloudChatsBotInfoTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsBotInfoTree0.Add(catraProtoClientTLSchemasCloudChatsBotInfo.DescriptionPhoto);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsBotInfo.DescriptionPhoto, preserveContext ? context : catraProtoClientTLSchemasCloudChatsBotInfo, preserveContext, catraProtoClientTLSchemasCloudChatsBotInfoTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifs catraProtoClientTLSchemasCloudChatsMessagesSavedGifs:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesSavedGifs.Gifs)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesSavedGifs, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.BotInlineMediaResult catraProtoClientTLSchemasCloudChatsBotInlineMediaResult:
                    if (catraProtoClientTLSchemasCloudChatsBotInlineMediaResult.Photo is null)
                    {
                        break;
                    }

                    var catraProtoClientTLSchemasCloudChatsBotInlineMediaResultTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsBotInlineMediaResultTree0.Add(catraProtoClientTLSchemasCloudChatsBotInlineMediaResult.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsBotInlineMediaResult.Photo, preserveContext ? context : catraProtoClientTLSchemasCloudChatsBotInlineMediaResult, preserveContext, catraProtoClientTLSchemasCloudChatsBotInlineMediaResultTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickers catraProtoClientTLSchemasCloudChatsMessagesRecentStickers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesRecentStickers.Stickers)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesRecentStickers, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.StickerSetCovered catraProtoClientTLSchemasCloudChatsStickerSetCovered:
                    tree.Add(catraProtoClientTLSchemasCloudChatsStickerSetCovered.Cover);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsStickerSetCovered.Cover, preserveContext ? context : catraProtoClientTLSchemasCloudChatsStickerSetCovered, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.StickerSetMultiCovered catraProtoClientTLSchemasCloudChatsStickerSetMultiCovered:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsStickerSetMultiCovered.Covers)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsStickerSetMultiCovered, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Game catraProtoClientTLSchemasCloudChatsGame:
                    var catraProtoClientTLSchemasCloudChatsGameTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsGameTree0.Add(catraProtoClientTLSchemasCloudChatsGame.Photo);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsGame.Photo, preserveContext ? context : catraProtoClientTLSchemasCloudChatsGame, preserveContext, catraProtoClientTLSchemasCloudChatsGameTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangePhoto catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhoto:
                    var catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhotoTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhotoTree0.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhoto.PrevPhoto);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhoto.PrevPhoto, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhoto, preserveContext, catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionChangePhotoTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickers catraProtoClientTLSchemasCloudChatsMessagesFavedStickers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesFavedStickers.Stickers)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesFavedStickers, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Page catraProtoClientTLSchemasCloudChatsPage:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsPage.Photos)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsPage, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Theme catraProtoClientTLSchemasCloudChatsTheme:
                    if (catraProtoClientTLSchemasCloudChatsTheme.Document is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsTheme.Document);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsTheme.Document, preserveContext ? context : catraProtoClientTLSchemasCloudChatsTheme, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeTheme catraProtoClientTLSchemasCloudChatsWebPageAttributeTheme:
                    if (catraProtoClientTLSchemasCloudChatsWebPageAttributeTheme.Documents is null)
                    {
                        break;
                    }

                    foreach (var item in catraProtoClientTLSchemasCloudChatsWebPageAttributeTheme.Documents)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsWebPageAttributeTheme, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AvailableReaction catraProtoClientTLSchemasCloudChatsAvailableReaction:
                    var catraProtoClientTLSchemasCloudChatsAvailableReactionTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsAvailableReactionTree0.Add(catraProtoClientTLSchemasCloudChatsAvailableReaction.StaticIcon);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsAvailableReaction.StaticIcon, catraProtoClientTLSchemasCloudChatsAvailableReaction, true, catraProtoClientTLSchemasCloudChatsAvailableReactionTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIcon catraProtoClientTLSchemasCloudChatsAttachMenuBotIcon:
                    tree.Add(catraProtoClientTLSchemasCloudChatsAttachMenuBotIcon.Icon);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsAttachMenuBotIcon.Icon, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAttachMenuBotIcon, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtones catraProtoClientTLSchemasCloudChatsAccountSavedRingtones:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsAccountSavedRingtones.Ringtones)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsAccountSavedRingtones, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneConverted catraProtoClientTLSchemasCloudChatsAccountSavedRingtoneConverted:
                    tree.Add(catraProtoClientTLSchemasCloudChatsAccountSavedRingtoneConverted.Document);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsAccountSavedRingtoneConverted.Document, catraProtoClientTLSchemasCloudChatsAccountSavedRingtoneConverted, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromo catraProtoClientTLSchemasCloudChatsHelpPremiumPromo:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsHelpPremiumPromo.Videos)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsHelpPremiumPromo, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Message catraProtoClientTLSchemasCloudChatsMessage:
                    if (catraProtoClientTLSchemasCloudChatsMessage.Media is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsMessage.Media);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessage.Media, catraProtoClientTLSchemasCloudChatsMessage, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageService catraProtoClientTLSchemasCloudChatsMessageService:
                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageService.Action);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageService.Action, catraProtoClientTLSchemasCloudChatsMessageService, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaWebPage catraProtoClientTLSchemasCloudChatsMessageMediaWebPage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageMediaWebPage.Webpage);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageMediaWebPage.Webpage, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessageMediaWebPage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.MessageMediaGame catraProtoClientTLSchemasCloudChatsMessageMediaGame:
                    tree.Add(catraProtoClientTLSchemasCloudChatsMessageMediaGame.Game);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessageMediaGame.Game, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessageMediaGame, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFull catraProtoClientTLSchemasCloudChatsMessagesChatFull:
                    tree.Add(catraProtoClientTLSchemasCloudChatsMessagesChatFull.FullChat);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsMessagesChatFull.FullChat, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesChatFull, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification catraProtoClientTLSchemasCloudChatsUpdateServiceNotification:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateServiceNotification.Media);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateServiceNotification.Media, catraProtoClientTLSchemasCloudChatsUpdateServiceNotification, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateWebPage catraProtoClientTLSchemasCloudChatsUpdateWebPage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateWebPage.Webpage);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateWebPage.Webpage, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateWebPage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewStickerSet catraProtoClientTLSchemasCloudChatsUpdateNewStickerSet:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateNewStickerSet.Stickerset);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateNewStickerSet.Stickerset, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateNewStickerSet, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage catraProtoClientTLSchemasCloudChatsUpdateChannelWebPage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateChannelWebPage.Webpage);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateChannelWebPage.Webpage, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateChannelWebPage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateTheme catraProtoClientTLSchemasCloudChatsUpdateTheme:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateTheme.Theme);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateTheme.Theme, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateTheme, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateShortSentMessage catraProtoClientTLSchemasCloudChatsUpdateShortSentMessage:
                    if (catraProtoClientTLSchemasCloudChatsUpdateShortSentMessage.Media is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateShortSentMessage.Media);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateShortSentMessage.Media, catraProtoClientTLSchemasCloudChatsUpdateShortSentMessage, true, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResults catraProtoClientTLSchemasCloudChatsMessagesBotResults:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesBotResults.Results)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesBotResults, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickers catraProtoClientTLSchemasCloudChatsMessagesFeaturedStickers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesFeaturedStickers.Sets)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesFeaturedStickers, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickers catraProtoClientTLSchemasCloudChatsMessagesArchivedStickers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesArchivedStickers.Sets)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesArchivedStickers, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultArchive catraProtoClientTLSchemasCloudChatsMessagesStickerSetInstallResultArchive:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesStickerSetInstallResultArchive.Sets)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, catraProtoClientTLSchemasCloudChatsMessagesStickerSetInstallResultArchive, true, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEvent catraProtoClientTLSchemasCloudChatsChannelAdminLogEvent:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEvent.Action);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEvent.Action, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEvent, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlChatInvite catraProtoClientTLSchemasCloudChatsRecentMeUrlChatInvite:
                    tree.Add(catraProtoClientTLSchemasCloudChatsRecentMeUrlChatInvite.ChatInvite);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsRecentMeUrlChatInvite.ChatInvite, preserveContext ? context : catraProtoClientTLSchemasCloudChatsRecentMeUrlChatInvite, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlStickerSet catraProtoClientTLSchemasCloudChatsRecentMeUrlStickerSet:
                    tree.Add(catraProtoClientTLSchemasCloudChatsRecentMeUrlStickerSet.Set);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsRecentMeUrlStickerSet.Set, preserveContext ? context : catraProtoClientTLSchemasCloudChatsRecentMeUrlStickerSet, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSets catraProtoClientTLSchemasCloudChatsMessagesFoundStickerSets:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesFoundStickerSets.Sets)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesFoundStickerSets, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapers catraProtoClientTLSchemasCloudChatsAccountWallPapers:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsAccountWallPapers.Wallpapers)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAccountWallPapers, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Account.Themes catraProtoClientTLSchemasCloudChatsAccountThemes:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsAccountThemes.ThemesField)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAccountThemes, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ThemeSettings catraProtoClientTLSchemasCloudChatsThemeSettings:
                    if (catraProtoClientTLSchemasCloudChatsThemeSettings.Wallpaper is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsThemeSettings.Wallpaper);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsThemeSettings.Wallpaper, preserveContext ? context : catraProtoClientTLSchemasCloudChatsThemeSettings, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.SponsoredMessage catraProtoClientTLSchemasCloudChatsSponsoredMessage:
                    if (catraProtoClientTLSchemasCloudChatsSponsoredMessage.ChatInvite is null)
                    {
                        break;
                    }

                    tree.Add(catraProtoClientTLSchemasCloudChatsSponsoredMessage.ChatInvite);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsSponsoredMessage.ChatInvite, preserveContext ? context : catraProtoClientTLSchemasCloudChatsSponsoredMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Users.UserFull catraProtoClientTLSchemasCloudChatsUsersUserFull:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUsersUserFull.FullUser);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUsersUserFull.FullUser, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUsersUserFull, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactions catraProtoClientTLSchemasCloudChatsMessagesAvailableReactions:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesAvailableReactions.Reactions)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesAvailableReactions, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBot catraProtoClientTLSchemasCloudChatsAttachMenuBot:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsAttachMenuBot.Icons)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAttachMenuBot, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.Dialogs catraProtoClientTLSchemasCloudChatsMessagesDialogs:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesDialogs.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesDialogs, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsSlice catraProtoClientTLSchemasCloudChatsMessagesDialogsSlice:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesDialogsSlice.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesDialogsSlice, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.ApiMessages catraProtoClientTLSchemasCloudChatsMessagesApiMessages:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesApiMessages.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesApiMessages, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesSlice catraProtoClientTLSchemasCloudChatsMessagesMessagesSlice:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesMessagesSlice.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesMessagesSlice, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.ChannelMessages catraProtoClientTLSchemasCloudChatsMessagesChannelMessages:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesChannelMessages.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesChannelMessages, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewMessage catraProtoClientTLSchemasCloudChatsUpdateNewMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateNewMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateNewMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateNewMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage catraProtoClientTLSchemasCloudChatsUpdateNewChannelMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateNewChannelMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateNewChannelMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateNewChannelMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage catraProtoClientTLSchemasCloudChatsUpdateEditChannelMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateEditChannelMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateEditChannelMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateEditChannelMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage catraProtoClientTLSchemasCloudChatsUpdateEditMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateEditMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateEditMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateEditMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateNewScheduledMessage catraProtoClientTLSchemasCloudChatsUpdateNewScheduledMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateNewScheduledMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateNewScheduledMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateNewScheduledMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Updates.Difference catraProtoClientTLSchemasCloudChatsUpdatesDifference:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsUpdatesDifference.NewMessages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdatesDifference, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceSlice catraProtoClientTLSchemasCloudChatsUpdatesDifferenceSlice:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsUpdatesDifferenceSlice.NewMessages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdatesDifferenceSlice, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdateShort catraProtoClientTLSchemasCloudChatsUpdateShort:
                    tree.Add(catraProtoClientTLSchemasCloudChatsUpdateShort.Update);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsUpdateShort.Update, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdateShort, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.UpdatesCombined catraProtoClientTLSchemasCloudChatsUpdatesCombined:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsUpdatesCombined.Updates)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdatesCombined, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ApiUpdates catraProtoClientTLSchemasCloudChatsApiUpdates:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsApiUpdates.Updates)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsApiUpdates, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceTooLong catraProtoClientTLSchemasCloudChatsUpdatesChannelDifferenceTooLong:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsUpdatesChannelDifferenceTooLong.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdatesChannelDifferenceTooLong, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifference catraProtoClientTLSchemasCloudChatsUpdatesChannelDifference:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsUpdatesChannelDifference.NewMessages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsUpdatesChannelDifference, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogs catraProtoClientTLSchemasCloudChatsMessagesPeerDialogs:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesPeerDialogs.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesPeerDialogs, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResult catraProtoClientTLSchemasCloudChatsPaymentsPaymentResult:
                    tree.Add(catraProtoClientTLSchemasCloudChatsPaymentsPaymentResult.Updates);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsPaymentsPaymentResult.Updates, preserveContext ? context : catraProtoClientTLSchemasCloudChatsPaymentsPaymentResult, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionUpdatePinned catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionUpdatePinned:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionUpdatePinned.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionUpdatePinned.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionUpdatePinned, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionEditMessage catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessage:
                    var catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessageTree0 = new List<IObject>(tree);
                    catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessageTree0.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessage.PrevMessage);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessage.PrevMessage, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessage, preserveContext, catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionEditMessageTree0, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionDeleteMessage catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionDeleteMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionDeleteMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionDeleteMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionDeleteMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionStopPoll catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionStopPoll:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionStopPoll.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionStopPoll.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionStopPoll, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionSendMessage catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionSendMessage:
                    tree.Add(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionSendMessage.Message);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionSendMessage.Message, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelAdminLogEventActionSendMessage, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResults catraProtoClientTLSchemasCloudChatsChannelsAdminLogResults:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsChannelsAdminLogResults.Events)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsChannelsAdminLogResults, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrls catraProtoClientTLSchemasCloudChatsHelpRecentMeUrls:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsHelpRecentMeUrls.Urls)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsHelpRecentMeUrls, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessage catraProtoClientTLSchemasCloudChatsMessagesDiscussionMessage:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesDiscussionMessage.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesDiscussionMessage, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessages catraProtoClientTLSchemasCloudChatsMessagesSponsoredMessages:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesSponsoredMessages.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesSponsoredMessages, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendar catraProtoClientTLSchemasCloudChatsMessagesSearchResultsCalendar:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsMessagesSearchResultsCalendar.Messages)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsMessagesSearchResultsCalendar, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBots catraProtoClientTLSchemasCloudChatsAttachMenuBots:
                    foreach (var item in catraProtoClientTLSchemasCloudChatsAttachMenuBots.Bots)
                    {
                        var newTree = new List<IObject>(tree);
                        newTree.Add(item);
                        OnFileReceived(item, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAttachMenuBots, preserveContext, newTree, callback);
                    }

                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBot catraProtoClientTLSchemasCloudChatsAttachMenuBotsBot:
                    tree.Add(catraProtoClientTLSchemasCloudChatsAttachMenuBotsBot.Bot);
                    OnFileReceived(catraProtoClientTLSchemasCloudChatsAttachMenuBotsBot.Bot, preserveContext ? context : catraProtoClientTLSchemasCloudChatsAttachMenuBotsBot, preserveContext, tree, callback);
                    break;
                case CatraProto.Client.TL.Schemas.CloudChats.Photo:
                case CatraProto.Client.TL.Schemas.CloudChats.Document:
                    callback(socketObject, context, tree);
                    break;
            }
        }
    }
}