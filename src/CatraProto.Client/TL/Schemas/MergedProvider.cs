using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public override IObject ResolveConstructorId(int constructorId)
        {
            if (InternalResolveConstructorId(constructorId, out var obj))
            {
                return obj!;
            }

            switch (constructorId)
            {
                case -1132882121:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BoolFalse();
                case -1720552011:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BoolTrue();
                case 1450380236:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Null();
                case 2134579434:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerEmpty();
                case 2107670217:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerSelf();
                case 396093539:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChat();
                case 2072935910:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerUser();
                case 548253432:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChannel();
                case 398123750:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerUserFromMessage();
                case -1667893317:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChannelFromMessage();
                case -1182234929:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUserEmpty();
                case -138301121:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUserSelf();
                case -668391402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUser();
                case 756118935:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUserFromMessage();
                case -208488460:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhoneContact();
                case -181407105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputFile();
                case -95482955:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputFileBig();
                case -1771768449:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaEmpty();
                case 505969924:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaUploadedPhoto();
                case -1279654347:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaPhoto();
                case -104578748:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaGeoPoint();
                case -122978821:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaContact();
                case 1530447553:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaUploadedDocument();
                case 598418386:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaDocument();
                case -1052959727:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaVenue();
                case -440664550:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaPhotoExternal();
                case -78455655:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaDocumentExternal();
                case -750828557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaGame();
                case -186607933:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaInvoice();
                case -1759532989:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaGeoLive();
                case 261416433:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaPoll();
                case -428884101:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaDice();
                case 480546647:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoEmpty();
                case -968723890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChatUploadedPhoto();
                case -1991004873:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChatPhoto();
                case -457104426:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointEmpty();
                case 1210199983:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGeoPoint();
                case 483901197:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhotoEmpty();
                case 1001634122:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhoto();
                case -539317279:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputFileLocation();
                case -182231723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileLocation();
                case -1160743548:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputDocumentFileLocation();
                case -876089816:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileLocation();
                case 700340377:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputTakeoutFileLocation();
                case 1075322878:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhotoFileLocation();
                case -667654413:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhotoLegacyFileLocation();
                case 668375447:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerPhotoFileLocation();
                case 230353641:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetThumb();
                case -1649296275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerUser();
                case -1160714821:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerChat();
                case -1109531342:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerChannel();
                case -1432995067:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileUnknown();
                case 1086091090:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FilePartial();
                case 8322574:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileJpeg();
                case -891180321:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileGif();
                case 172975040:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FilePng();
                case -1373745011:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FilePdf();
                case 1384777335:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileMp3();
                case 1258941372:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileMov();
                case -1278304028:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileMp4();
                case 276907596:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Storage.FileWebp();
                case 537022650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserEmpty();
                case -1820043071:
                    return new CatraProto.Client.TL.Schemas.CloudChats.User();
                case 1326562017:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoEmpty();
                case 1775479590:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhoto();
                case 164646985:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusEmpty();
                case -306628279:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusOnline();
                case 9203775:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusOffline();
                case -496024847:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusRecently();
                case 129960444:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusLastWeek();
                case 2011940674:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserStatusLastMonth();
                case -1683826688:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatEmpty();
                case 1004149726:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Chat();
                case 120753115:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatForbidden();
                case -753232354:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channel();
                case 681420594:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelForbidden();
                case 461151667:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatFull();
                case -253335766:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelFull();
                case -925415106:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipant();
                case -636267638:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantCreator();
                case -489233354:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantAdmin();
                case -57668565:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsForbidden();
                case 1061556205:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipants();
                case 935395612:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoEmpty();
                case -770990276:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatPhoto();
                case -2082087340:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty();
                case 1487813065:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Message();
                case 678405636:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageService();
                case 1038967584:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaEmpty();
                case 1766936791:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaPhoto();
                case 1457575028:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaGeo();
                case -873313984:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaContact();
                case -1618676578:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaUnsupported();
                case -1666158377:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaDocument();
                case -1557277184:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaWebPage();
                case 784356159:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaVenue();
                case -38694904:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaGame();
                case -2074799289:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaInvoice();
                case -1186937242:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaGeoLive();
                case 1272375192:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaPoll();
                case 1065280907:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaDice();
                case -1230047312:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionEmpty();
                case -1503425638:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatCreate();
                case -1247687078:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditTitle();
                case 2144015272:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditPhoto();
                case -1780220945:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatDeletePhoto();
                case 1217033015:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatAddUser();
                case -1297179892:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatDeleteUser();
                case -123931160:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatJoinedByLink();
                case -1781355374:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChannelCreate();
                case 1371385889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatMigrateTo();
                case -1336546578:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChannelMigrateFrom();
                case -1799538451:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPinMessage();
                case -1615153660:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionHistoryClear();
                case -1834538890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionGameScore();
                case -1892568281:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPaymentSentMe();
                case 1080663248:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPaymentSent();
                case -2132731265:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPhoneCall();
                case 1200788123:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionScreenshotTaken();
                case -85549226:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionCustomAction();
                case -1410748418:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionBotAllowed();
                case 455635795:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionSecureValuesSentMe();
                case -648257196:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionSecureValuesSent();
                case -202219658:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionContactSignUp();
                case -1730095465:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionGeoProximityReached();
                case 739712882:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Dialog();
                case 1908216652:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFolder();
                case 590459437:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoEmpty();
                case -82216347:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photo();
                case 236446268:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeEmpty();
                case 2009052699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSize();
                case -374917894:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoCachedSize();
                case -525288402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoStrippedSize();
                case 1520986705:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeProgressive();
                case -668906175:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoPathSize();
                case 286776671:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GeoPointEmpty();
                case -1297942941:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GeoPoint();
                case 1577067778:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCode();
                case -855308010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization();
                case 1148485274:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationSignUpRequired();
                case -543777747:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorization();
                case -1195615476:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeer();
                case 423314455:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyUsers();
                case 1251338318:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyChats();
                case -1311015810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyBroadcasts();
                case -1673717362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettings();
                case -1353671392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettings();
                case 1933519201:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerSettings();
                case -1539849235:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaper();
                case -1963717851:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaperNoFile();
                case 1490799288:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonSpam();
                case 505595789:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonViolence();
                case 777640226:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonPornography();
                case -1376497949:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonChildAbuse();
                case -512463606:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonOther();
                case -1685456582:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonCopyright();
                case -606798099:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonGeoIrrelevant();
                case -302941166:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserFull();
                case -116274796:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contact();
                case -805141448:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ImportedContact();
                case -748155807:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ContactStatus();
                case -1219778094:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsNotModified();
                case -353862078:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.CContacts();
                case 2010127419:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContacts();
                case 182326673:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Blocked();
                case -513392236:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedSlice();
                case 364538944:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Dialogs();
                case 1910543603:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsSlice();
                case -253500010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsNotModified();
                case -1938715001:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MMessages();
                case 978610270:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesSlice();
                case 1682413576:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ChannelMessages();
                case 1951620897:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesNotModified();
                case 1694474197:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Chats();
                case -1663561404:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsSlice();
                case -438840932:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFull();
                case -1269012015:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistory();
                case 1474492012:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterEmpty();
                case -1777752804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterPhotos();
                case -1614803355:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterVideo();
                case 1458172132:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterPhotoVideo();
                case -1629621880:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterDocument();
                case 2129714567:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterUrl();
                case -3644025:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterGif();
                case 1358283666:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterVoice();
                case 928101534:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterMusic();
                case 975236280:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterChatPhotos();
                case -2134272152:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterPhoneCalls();
                case 2054952868:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterRoundVoice();
                case -1253451181:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterRoundVideo();
                case -1040652646:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterMyMentions();
                case -419271411:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterGeo();
                case -530392189:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterContacts();
                case 464520273:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagesFilterPinned();
                case 522914557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewMessage();
                case 1318109142:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateMessageID();
                case -1576161051:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteMessages();
                case 1548249383:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserTyping();
                case -1704596961:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatUserTyping();
                case 125178264:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipants();
                case 469489699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserStatus();
                case -1489818765:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserName();
                case -1791935732:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhoto();
                case 314359194:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewEncryptedMessage();
                case 386986326:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryptedChatTyping();
                case -1264392051:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryption();
                case 956179895:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryptedMessagesRead();
                case -364179876:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdd();
                case 1851755554:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantDelete();
                case -1906403213:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDcOptions();
                case -1094555409:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNotifySettings();
                case -337352679:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification();
                case -298113238:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePrivacy();
                case 314130811:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhone();
                case -1667805217:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryInbox();
                case 791617983:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryOutbox();
                case 2139689491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateWebPage();
                case 1757493555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadMessagesContents();
                case -352032773:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelTooLong();
                case -1227598250:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannel();
                case 1656358105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage();
                case 856380452:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox();
                case -1015733815:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteChannelMessages();
                case -1734268085:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageViews();
                case -1232070311:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdmin();
                case 1753886890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewStickerSet();
                case 196268545:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateStickerSetsOrder();
                case 1135492588:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateStickerSets();
                case -1821035490:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateSavedGifs();
                case 1417832080:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineQuery();
                case 239663460:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineSend();
                case 457133559:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage();
                case -415938591:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCallbackQuery();
                case -469536605:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage();
                case -103646630:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateInlineBotCallbackQuery();
                case 634833351:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelOutbox();
                case -299124375:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDraftMessage();
                case 1461528386:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadFeaturedStickers();
                case -1706939360:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateRecentStickers();
                case -1574314746:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateConfig();
                case 861169551:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePtsChanged();
                case 1081547008:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage();
                case 1852826908:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogPinned();
                case -99664734:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedDialogs();
                case -2095595325:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotWebhookJSON();
                case -1684914010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotWebhookJSONQuery();
                case -523384512:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotShippingQuery();
                case 1563376297:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotPrecheckoutQuery();
                case -1425052898:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePhoneCall();
                case 1180041828:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateLangPackTooLong();
                case 1442983757:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateLangPack();
                case -451831443:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateFavedStickers();
                case -1987495099:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelReadMessagesContents();
                case 1887741886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateContactsReset();
                case 1893427255:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelAvailableMessages();
                case -513517117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogUnreadMark();
                case -1398708869:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePoll();
                case 1421875280:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatDefaultBannedRights();
                case 422972864:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateFolderPeers();
                case 1786671974:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerSettings();
                case -1263546448:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerLocated();
                case 967122427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewScheduledMessage();
                case -1870238482:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteScheduledMessages();
                case -2112423005:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateTheme();
                case -2027964103:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateGeoLiveViewed();
                case 1448076945:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateLoginToken();
                case 1123585836:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePollVote();
                case 654302845:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilter();
                case -1512627963:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilterOrder();
                case 889491791:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilters();
                case 643940105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePhoneCallSignalingData();
                case 1708307556:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelParticipant();
                case 1854571743:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageForwards();
                case 482860628:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionInbox();
                case 1178116716:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionOutbox();
                case 610945826:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerBlocked();
                case -13975905:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelUserTyping();
                case -309990731:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedMessages();
                case -2054649973:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedChannelMessages();
                case -1519637954:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.State();
                case 1567990072:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceEmpty();
                case 16030880:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.Difference();
                case -1459938943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceSlice();
                case 1258196845:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceTooLong();
                case -484987010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatesTooLong();
                case 580309704:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortMessage();
                case 1076714939:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortChatMessage();
                case 2027216577:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShort();
                case 1918567619:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatesCombined();
                case 1957577280:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UUpdates();
                case 301019932:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortSentMessage();
                case -1916114267:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.PPhotos();
                case 352657236:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosSlice();
                case 539045032:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.Photo();
                case 157948117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.File();
                case -242427324:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.FileCdnRedirect();
                case 414687501:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DcOption();
                case 856375399:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Config();
                case -1910892683:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NearestDc();
                case 497489295:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdate();
                case -1000708810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.NoAppUpdate();
                case 415997816:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.InviteText();
                case -1417756512:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatEmpty();
                case 1006044124:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatWaiting();
                case 1651608194:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatRequested();
                case -94974410:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChat();
                case 332848423:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatDiscarded();
                case -247351839:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChat();
                case -1038136962:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileEmpty();
                case 1248893260:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedFile();
                case 406307684:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileEmpty();
                case 1690108678:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileUploaded();
                case 1511503333:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFile();
                case 767652808:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBigUploaded();
                case -317144808:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessage();
                case 594758406:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageService();
                case -1058912715:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigNotModified();
                case 740433629:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfig();
                case 1443858741:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessage();
                case -1802240206:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedFile();
                case 1928391342:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputDocumentEmpty();
                case 448771445:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputDocument();
                case 922273905:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentEmpty();
                case 512177195:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Document();
                case 398898678:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.Support();
                case -1613493288:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotifyPeer();
                case -1261946036:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotifyUsers();
                case -1073230141:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotifyChats();
                case -703403793:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotifyBroadcasts();
                case 381645902:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageTypingAction();
                case -44119819:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageCancelAction();
                case -1584933265:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageRecordVideoAction();
                case -378127636:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageUploadVideoAction();
                case -718310409:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageRecordAudioAction();
                case -212740181:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageUploadAudioAction();
                case -774682074:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageUploadPhotoAction();
                case -1441998364:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageUploadDocumentAction();
                case 393186209:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageGeoLocationAction();
                case 1653390447:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageChooseContactAction();
                case -580219064:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageGamePlayAction();
                case -1997373508:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageRecordRoundAction();
                case 608050278:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageUploadRoundAction();
                case -1290580579:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Found();
                case 1335282456:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyStatusTimestamp();
                case -1107622874:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyChatInvite();
                case -88417185:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyPhoneCall();
                case -610373422:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyPhoneP2P();
                case -1529000952:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyForwards();
                case 1461304012:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyProfilePhoto();
                case 55761658:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyPhoneNumber();
                case -786326563:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyAddedByPhone();
                case -1137792208:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyStatusTimestamp();
                case 1343122938:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyChatInvite();
                case 1030105979:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyPhoneCall();
                case 961092808:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyPhoneP2P();
                case 1777096355:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyForwards();
                case -1777000467:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyProfilePhoto();
                case -778378131:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyPhoneNumber();
                case 1124062251:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyAddedByPhone();
                case 218751099:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueAllowContacts();
                case 407582158:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueAllowAll();
                case 320652927:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueAllowUsers();
                case 195371015:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueDisallowContacts();
                case -697604407:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueDisallowAll();
                case -1877932953:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueDisallowUsers();
                case 1283572154:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueAllowChatParticipants();
                case -668769361:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueDisallowChatParticipants();
                case -123988:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowContacts();
                case 1698855810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowAll();
                case 1297858060:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowUsers();
                case -125240806:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowContacts();
                case -1955338397:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowAll();
                case 209668535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowUsers();
                case 415136107:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowChatParticipants();
                case -1397881200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowChatParticipants();
                case 1352683077:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRules();
                case -1194283041:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTL();
                case 1815593308:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeImageSize();
                case 297109817:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeAnimated();
                case 1662637586:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeSticker();
                case 250621158:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeVideo();
                case -1739392570:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeAudio();
                case 358154344:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeFilename();
                case -1744710921:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeHasStickers();
                case -244016606:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersNotModified();
                case -463889475:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Stickers();
                case 313694676:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerPack();
                case -395967805:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersNotModified();
                case -302170017:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickers();
                case -2066640507:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessages();
                case -350980120:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPageEmpty();
                case -981018084:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPagePending();
                case -392411726:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPage();
                case 1930545681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPageNotModified();
                case -1392388579:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Authorization();
                case 307276766:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Authorizations();
                case -1390001672:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Password();
                case -1705233435:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettings();
                case -1036572727:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettings();
                case 326715557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecovery();
                case -1551583367:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessage();
                case 1776236393:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteEmpty();
                case -64092740:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteExported();
                case 1516793212:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteAlready();
                case -540871282:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInvite();
                case 1634294960:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInvitePeek();
                case -4838507:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetEmpty();
                case -1645763991:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetID();
                case -2044933984:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetShortName();
                case 42402760:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetAnimatedEmoji();
                case -427863538:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetDice();
                case -290164953:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerSet();
                case -1240849242:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet();
                case -1032140601:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommand();
                case -1729618630:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInfo();
                case -1560655744:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButton();
                case 629866245:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonUrl();
                case 901503851:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonCallback();
                case -1318425559:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRequestPhone();
                case -59151553:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRequestGeoLocation();
                case 90744648:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonSwitchInline();
                case 1358175439:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonGame();
                case -1344716869:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBuy();
                case 280464681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonUrlAuth();
                case -802258988:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputKeyboardButtonUrlAuth();
                case -1144565411:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRequestPoll();
                case 2002815875:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRow();
                case -1606526075:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyKeyboardHide();
                case -200242528:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyKeyboardForceReply();
                case 889353612:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyKeyboardMarkup();
                case 1218642516:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyInlineMarkup();
                case -1148011883:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityUnknown();
                case -100378723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityMention();
                case 1868782349:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityHashtag();
                case 1827637959:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBotCommand();
                case 1859134776:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityUrl();
                case 1692693954:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityEmail();
                case -1117713463:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBold();
                case -2106619040:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityItalic();
                case 681706865:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityCode();
                case 1938967520:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityPre();
                case 1990644519:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityTextUrl();
                case 892193368:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityMentionName();
                case 546203849:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessageEntityMentionName();
                case -1687559349:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityPhone();
                case 1280209983:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityCashtag();
                case -1672577397:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityUnderline();
                case -1090087980:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityStrike();
                case 34469328:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBlockquote();
                case 1981704948:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBankCard();
                case -292807034:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChannelEmpty();
                case -1343524562:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChannel();
                case 707290417:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChannelFromMessage();
                case 2131196633:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvedPeer();
                case 182649427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageRange();
                case 1041346555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceEmpty();
                case -1531132162:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceTooLong();
                case 543450958:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifference();
                case -1798033689:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterEmpty();
                case -847783593:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilter();
                case 367766557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipant();
                case -1557620115:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantSelf();
                case 1149094475:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantCreator();
                case -859915345:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantAdmin();
                case 470789295:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBanned();
                case -1010402965:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantLeft();
                case -566281095:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsRecent();
                case -1268741783:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsAdmins();
                case -1548400251:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsKicked();
                case -1328445861:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsBots();
                case 338142689:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsBanned();
                case 106343499:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsSearch();
                case -1150621555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsContacts();
                case -531931925:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsMentions();
                case -177282392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipants();
                case -266911767:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsNotModified();
                case -791039645:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipant();
                case 2013922064:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfService();
                case -402498398:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsNotModified();
                case 772213157:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifs();
                case 864077702:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageMediaAuto();
                case 1036876423:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageText();
                case -1768777083:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageMediaGeo();
                case 1098628881:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageMediaVenue();
                case -1494368259:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageMediaContact();
                case 1262639204:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageGame();
                case -2000710887:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResult();
                case -1462213465:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultPhoto();
                case -459324:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultDocument();
                case 1336154098:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultGame();
                case 1984755728:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageMediaAuto();
                case -1937807902:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageText();
                case 85477117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageMediaGeo();
                case -1970903652:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageMediaVenue();
                case 416402882:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageMediaContact();
                case 295067450:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineResult();
                case 400266251:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMediaResult();
                case -1803769784:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResults();
                case 1571494644:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLink();
                case 1601666510:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeader();
                case 1923290508:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeSms();
                case 1948046307:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeCall();
                case 577556219:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeFlashCall();
                case 1035688326:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeApp();
                case -1073693790:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeSms();
                case 1398007207:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeCall();
                case -1425815847:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeFlashCall();
                case 911761060:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswer();
                case 649453030:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditData();
                case -1995686519:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageID();
                case 1008755359:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPM();
                case 863093588:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogs();
                case -305282981:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeer();
                case -1419371685:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBotsPM();
                case 344356834:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBotsInline();
                case 104314861:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryCorrespondents();
                case -1122524854:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryGroups();
                case 371037736:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryChannels();
                case 511092620:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPhoneCalls();
                case -1472172887:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryForwardUsers();
                case -68239120:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryForwardChats();
                case -75283823:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeers();
                case -567906571:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersNotModified();
                case 1891070632:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeers();
                case -1255369827:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersDisabled();
                case 453805082:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DraftMessageEmpty();
                case -40996577:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DraftMessage();
                case -958657434:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersNotModified();
                case -1230257343:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickers();
                case 186120336:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersNotModified();
                case 586395571:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickers();
                case 1338747336:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickers();
                case 946083368:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultSuccess();
                case 904138920:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultArchive();
                case 1678812626:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerSetCovered();
                case 872932635:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerSetMultiCovered();
                case -1361650766:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MaskCoords();
                case 1251549527:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaPhoto();
                case 70813275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaDocument();
                case -1107729093:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Game();
                case 53231223:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGameID();
                case -1020139510:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGameShortName();
                case 1493171408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.HighScore();
                case -1707344487:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScores();
                case -599948721:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextEmpty();
                case 1950782688:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextPlain();
                case 1730456516:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextBold();
                case -653089380:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextItalic();
                case -1054465340:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextUnderline();
                case -1678197867:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextStrike();
                case 1816074681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextFixed();
                case 1009288385:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextUrl();
                case -564523562:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextEmail();
                case 2120376535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextConcat();
                case -311786236:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextSubscript();
                case -939827711:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextSuperscript();
                case 55281185:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextMarked();
                case 483104362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextPhone();
                case 136105807:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextImage();
                case 894777186:
                    return new CatraProto.Client.TL.Schemas.CloudChats.TextAnchor();
                case 324435594:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockUnsupported();
                case 1890305021:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockTitle();
                case -1879401953:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockSubtitle();
                case -1162877472:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockAuthorDate();
                case -1076861716:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockHeader();
                case -248793375:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockSubheader();
                case 1182402406:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockParagraph();
                case -1066346178:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockPreformatted();
                case 1216809369:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockFooter();
                case -618614392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockDivider();
                case -837994576:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockAnchor();
                case -454524911:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockList();
                case 641563686:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockBlockquote();
                case 1329878739:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockPullquote();
                case 391759200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockPhoto();
                case 2089805750:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockVideo();
                case 972174080:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockCover();
                case -1468953147:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockEmbed();
                case -229005301:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockEmbedPost();
                case 1705048653:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockCollage();
                case 52401552:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockSlideshow();
                case -283684427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockChannel();
                case -2143067670:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockAudio();
                case 504660880:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockKicker();
                case -1085412734:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockTable();
                case -1702174239:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockOrderedList();
                case 1987480557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockDetails();
                case 370236054:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockRelatedArticles();
                case -1538310410:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageBlockMap();
                case -2048646399:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonMissed();
                case -527056480:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonDisconnect();
                case 1471006352:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonHangup();
                case -84416311:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBusy();
                case 2104790276:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DataJSON();
                case -886477832:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LabeledPrice();
                case -1022713000:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Invoice();
                case -368917890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PaymentCharge();
                case 512535275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PostAddress();
                case -1868808300:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfo();
                case -842892769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsCard();
                case 475467473:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebDocument();
                case -104284986:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebDocumentNoProxy();
                case -1678949555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWebDocument();
                case -1036396922:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocation();
                case -1625153079:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWebFileGeoPointLocation();
                case 568808380:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFile();
                case 1062645411:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentForm();
                case -784000893:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfo();
                case 1314881805:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResult();
                case -666824391:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentVerificationNeeded();
                case 1342771681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceipt();
                case -74456004:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfo();
                case -1056001329:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsSaved();
                case 873977640:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentials();
                case 178373535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsApplePay();
                case -905587442:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsAndroidPay();
                case -614138572:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPassword();
                case -1239335713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ShippingOption();
                case -6249322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItem();
                case 506920429:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCall();
                case 1399245077:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallEmpty();
                case 462375633:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallWaiting();
                case -2014659757:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallRequested();
                case -1719909046:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallAccepted();
                case -2025673089:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCall();
                case 1355435489:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscarded();
                case -1655957568:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneConnection();
                case 1667228533:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionWebrtc();
                case -58224696:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocol();
                case -326966976:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCall();
                case -290921362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileReuploadNeeded();
                case -1449145777:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFile();
                case -914167110:
                    return new CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKey();
                case 1462101002:
                    return new CatraProto.Client.TL.Schemas.CloudChats.CdnConfig();
                case -892239370:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LangPackString();
                case 1816636575:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LangPackStringPluralized();
                case 695856818:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LangPackStringDeleted();
                case -209337866:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LangPackDifference();
                case -288727837:
                    return new CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguage();
                case -421545947:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeTitle();
                case 1427671598:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeAbout();
                case 1783299128:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeUsername();
                case 1129042607:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangePhoto();
                case 460916654:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleInvites();
                case 648939889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleSignatures();
                case -370660328:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionUpdatePinned();
                case 1889215493:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionEditMessage();
                case 1121994683:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionDeleteMessage();
                case 405815507:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantJoin();
                case -124291086:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantLeave();
                case -484690728:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantInvite();
                case -422036098:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantToggleBan();
                case -714643696:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantToggleAdmin();
                case -1312568665:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeStickerSet();
                case 1599903217:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionTogglePreHistoryHidden();
                case 771095562:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionDefaultBannedRights();
                case -1895328189:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionStopPoll();
                case -1569748965:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeLinkedChat();
                case 241923758:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeLocation();
                case 1401984889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleSlowMode();
                case 995769920:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEvent();
                case -309659827:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResults();
                case -368018716:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilter();
                case 1558266229:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PopularContact();
                case -1634752813:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersNotModified();
                case -209768682:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickers();
                case 1189204285:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlUnknown();
                case -1917045962:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlUser();
                case -1608834311:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlChat();
                case -347535331:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlChatInvite();
                case -1140172836:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlStickerSet();
                case 235081943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrls();
                case 482797855:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSingleMedia();
                case -892779534:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebAuthorization();
                case -313079300:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizations();
                case -1502174430:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessageID();
                case -1160215659:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessageReplyTo();
                case -2037963464:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessagePinned();
                case -1392895362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMessageCallbackQuery();
                case -55902537:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeer();
                case 1684014375:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerFolder();
                case -445792507:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogPeer();
                case 1363483106:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogPeerFolder();
                case 223655517:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsNotModified();
                case 1359533640:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSets();
                case 1648543603:
                    return new CatraProto.Client.TL.Schemas.CloudChats.FileHash();
                case 1968737087:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputClientProxy();
                case -483352705:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateEmpty();
                case 686618977:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdate();
                case 859091184:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileUploaded();
                case 1399317950:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSecureFile();
                case 1679398724:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureFileEmpty();
                case -534283678:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureFile();
                case -1964327229:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureData();
                case 2103482845:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecurePlainPhone();
                case 569137759:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecurePlainEmail();
                case -1658158621:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypePersonalDetails();
                case 1034709504:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypePassport();
                case 115615172:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeDriverLicense();
                case -1596951477:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeIdentityCard();
                case -1717268701:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeInternalPassport();
                case -874308058:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeAddress();
                case -63531698:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeUtilityBill();
                case -1995211763:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBankStatement();
                case -1954007928:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeRentalAgreement();
                case -1713143702:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypePassportRegistration();
                case -368907213:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeTemporaryRegistration();
                case -1289704741:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypePhone();
                case -1908627474:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeEmail();
                case 411017418:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValue();
                case -618540889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSecureValue();
                case -316748368:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueHash();
                case -391902247:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorData();
                case 12467706:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorFrontSide();
                case -2037765467:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorReverseSide();
                case -449327402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorSelfie();
                case 2054162547:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorFile();
                case 1717706985:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorFiles();
                case -2036501105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueError();
                case -1592506512:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorTranslationFile();
                case 878931416:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorTranslationFiles();
                case 871426631:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncrypted();
                case -1389486888:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationForm();
                case -2128640689:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCode();
                case 1722786150:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoEmpty();
                case 1783556146:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfo();
                case 289586518:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SavedPhoneContact();
                case 1304052993:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Takeout();
                case -732254058:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoUnknown();
                case 982592842:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow();
                case 4883767:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoUnknown();
                case -1141711456:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000();
                case -2042159726:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoSHA512();
                case 354925740:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettings();
                case -1736378792:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordEmpty();
                case -763367294:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRP();
                case -2103600678:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredType();
                case 41187252:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeOneOf();
                case -1078332329:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigNotModified();
                case -1600596305:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfig();
                case 488313413:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputAppEvent();
                case -1059185703:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonObjectValue();
                case 1064139624:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonNull();
                case -952869270:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonBool();
                case 736157604:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonNumber();
                case -1222740358:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonString();
                case -146520221:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonArray();
                case -1715350371:
                    return new CatraProto.Client.TL.Schemas.CloudChats.JsonObject();
                case 878078826:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageTableCell();
                case -524237339:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageTableRow();
                case 1869903447:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageCaption();
                case -1188055347:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageListItemText();
                case 635466748:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageListItemBlocks();
                case 1577484359:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemText();
                case -1730311882:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBlocks();
                case -1282352120:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticle();
                case -1738178803:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Page();
                case -1945767479:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.SupportName();
                case -206688531:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoEmpty();
                case 32192344:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfo();
                case 1823064809:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PollAnswer();
                case -2032041631:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Poll();
                case 997055186:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVoters();
                case -1159937629:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PollResults();
                case -264117680:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatOnlines();
                case 1202287072:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsURL();
                case 1605510357:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRights();
                case -1626209256:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRights();
                case -433014407:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWallPaper();
                case 1913199744:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperSlug();
                case -2077770836:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperNoFile();
                case 471437699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersNotModified();
                case 1881892265:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapers();
                case -557924733:
                    return new CatraProto.Client.TL.Schemas.CloudChats.CodeSettings();
                case 84438264:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettings();
                case -532532493:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettings();
                case 1674235686:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettings();
                case -709641735:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EmojiKeyword();
                case 594408994:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordDeleted();
                case 1556570557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifference();
                case -1519029347:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EmojiURL();
                case -1275374751:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguage();
                case -1132476723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.FileLocationToBeDeprecated();
                case -11252123:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Folder();
                case -70073706:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeer();
                case -373643672:
                    return new CatraProto.Client.TL.Schemas.CloudChats.FolderPeer();
                case -398136321:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounter();
                case -1831650802:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultRequest();
                case -1886646706:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultAccepted();
                case -1445536993:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultDefault();
                case -1078612597:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationEmpty();
                case 547062491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelLocation();
                case -901375139:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerLocated();
                case -118740917:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerSelfLocated();
                case -797791052:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RestrictionReason();
                case 1012306921:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputTheme();
                case -175567375:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputThemeSlug();
                case 42930452:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Theme();
                case -199313886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesNotModified();
                case 2137482273:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Themes();
                case 1654593920:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginToken();
                case 110008598:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenMigrateTo();
                case 957176926:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenSuccess();
                case 1474462241:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettings();
                case -1456996667:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChats();
                case -1012849566:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BaseThemeClassic();
                case -69724536:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BaseThemeDay();
                case -1212997976:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BaseThemeNight();
                case 1834973166:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BaseThemeTinted();
                case 1527845466:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BaseThemeArctic();
                case -1118798639:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettings();
                case -1676371894:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ThemeSettings();
                case 1421174295:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeTheme();
                case -1567730343:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVote();
                case 909603888:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteInputOption();
                case 244310238:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteMultiple();
                case 136574537:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesList();
                case -177732982:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrl();
                case 1042605427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardData();
                case 1949890536:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFilter();
                case 2004110666:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggested();
                case -1237848657:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDays();
                case -884757282:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrev();
                case -875679776:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValue();
                case 1244130093:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGraphAsync();
                case -1092839390:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGraphError();
                case -1901828938:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGraph();
                case -1387279939:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCounters();
                case -1107852396:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStats();
                case -1728664459:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataEmpty();
                case -1942390465:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.PromoData();
                case -399391402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.VideoSize();
                case 418631927:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPoster();
                case 1611985938:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdmin();
                case 831924812:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviter();
                case -276825834:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStats();
                case -1096616924:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettings();
                case 1107543535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCode();
                case -1014526429:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.Country();
                case -1815339214:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListNotModified();
                case -2016381538:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesList();
                case 1163625789:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageViews();
                case -1228606141:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViews();
                case -170029155:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessage();
                case -1495959709:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeader();
                case 1093204652:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageReplies();
                case -386039788:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerBlocked();
                case -1986399595:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStats();
                case -878758099:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsg();
                case 1036301552:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsgs();
                case -1043505495:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InitConnection();
                case -627372787:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithLayer();
                case -1080796745:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithoutUpdates();
                case 911373810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithMessagesRange();
                case -1398145746:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithTakeout();
                case -1502141361:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SendCode();
                case -2131827673:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignUp();
                case -1126886015:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignIn();
                case 1461180992:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LogOut();
                case -1616179942:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResetAuthorizations();
                case -440401971:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportAuthorization();
                case -470837741:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportAuthorization();
                case -841733627:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.BindTempAuthKey();
                case 1738800940:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportBotAuthorization();
                case -779399914:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckPassword();
                case -661144474:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.RequestPasswordRecovery();
                case 1319464594:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.RecoverPassword();
                case 1056025023:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResendCode();
                case 520357240:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CancelCode();
                case -1907842680:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.DropTempAuthKeys();
                case -1313598185:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportLoginToken();
                case -1783866140:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportLoginToken();
                case -392909491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.AcceptLoginToken();
                case 1754754159:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.RegisterDevice();
                case 813089983:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UnregisterDevice();
                case -2067899501:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings();
                case 313765169:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifySettings();
                case -612493497:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetNotifySettings();
                case 2018596725:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateProfile();
                case 1713919532:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateStatus();
                case -1430579357:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPapers();
                case -1374118561:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ReportPeer();
                case 655677548:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.CheckUsername();
                case 1040964988:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateUsername();
                case -623130288:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPrivacy();
                case -906486552:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetPrivacy();
                case 1099779595:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteAccount();
                case 150761757:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAccountTTL();
                case 608323678:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetAccountTTL();
                case -2108208411:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendChangePhoneCode();
                case 1891839707:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ChangePhone();
                case 954152242:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateDeviceLocked();
                case -484392616:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizations();
                case -545786948:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetAuthorization();
                case 1418342645:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPassword();
                case -1663767815:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPasswordSettings();
                case -1516564433:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdatePasswordSettings();
                case 457157256:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendConfirmPhoneCode();
                case 1596029123:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPhone();
                case 1151208273:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTmpPassword();
                case 405695855:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWebAuthorizations();
                case 755087855:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorization();
                case 1747789204:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorizations();
                case -1299661699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAllSecureValues();
                case 1936088002:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetSecureValue();
                case -1986010339:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveSecureValue();
                case -1199522741:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteSecureValue();
                case -1200903967:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizationForm();
                case -419267436:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.AcceptAuthorization();
                case -1516022023:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyPhoneCode();
                case 1305716726:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyPhone();
                case 1880182943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyEmailCode();
                case -323339813:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyEmail();
                case -262453244:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.InitTakeoutSession();
                case 489050862:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.FinishTakeoutSession();
                case -1881204448:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPasswordEmail();
                case 2055154197:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResendPasswordEmail();
                case -1043606090:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.CancelPasswordEmail();
                case -1626880216:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContactSignUpNotification();
                case -806076575:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContactSignUpNotification();
                case 1398240377:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifyExceptions();
                case -57811990:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPaper();
                case -578472351:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadWallPaper();
                case 1817860919:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveWallPaper();
                case -18000023:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallWallPaper();
                case -1153722364:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWallPapers();
                case 1457130303:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAutoDownloadSettings();
                case 1995661875:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveAutoDownloadSettings();
                case 473805619:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadTheme();
                case -2077048289:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.CreateTheme();
                case 1555261397:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme();
                case -229175188:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveTheme();
                case 2061776695:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallTheme();
                case -1919060949:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTheme();
                case 676939512:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetThemes();
                case -1250643605:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContentSettings();
                case -1952756306:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContentSettings();
                case 1705865692:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetMultiWallPapers();
                case -349483786:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetGlobalPrivacySettings();
                case 517647042:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetGlobalPrivacySettings();
                case 227648840:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.GetUsers();
                case -902781519:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.GetFullUser();
                case -1865902923:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.SetSecureValueErrors();
                case 749357634:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetContactIDs();
                case -995929106:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetStatuses();
                case -1071414113:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetContacts();
                case 746589157:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportContacts();
                case 157945344:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.DeleteContacts();
                case 269745566:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.DeleteByPhones();
                case 1758204945:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Block();
                case -1096393392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Unblock();
                case -176409329:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetBlocked();
                case 301470424:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Search();
                case -113456221:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolveUsername();
                case -728224331:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetTopPeers();
                case 451113900:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResetTopPeerRating();
                case -2020263951:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResetSaved();
                case -2098076769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetSaved();
                case -2062238246:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ToggleTopPeers();
                case -386636848:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.AddContact();
                case -130964977:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.AcceptContact();
                case -750207932:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetLocated();
                case 698914348:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockFromReplies();
                case 1673946374:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessages();
                case -1594999949:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogs();
                case -591691168:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetHistory();
                case 204812012:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Search();
                case 238054714:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory();
                case 469850889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory();
                case -443640366:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteMessages();
                case 94983360:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedMessages();
                case 1486110434:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetTyping();
                case 1376532592:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMessage();
                case 881978281:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMedia();
                case -637606386:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages();
                case -820669733:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam();
                case 913498268:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerSettings();
                case -1115507112:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Report();
                case 1013621127:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChats();
                case 998448230:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFullChat();
                case -599447467:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatTitle();
                case -900957736:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatPhoto();
                case -106911223:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AddChatUser();
                case -530505962:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChatUser();
                case 164303470:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CreateChat();
                case 651135312:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDhConfig();
                case -162681021:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestEncryption();
                case 1035731989:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptEncryption();
                case -304536635:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscardEncryption();
                case 2031374829:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetEncryptedTyping();
                case 2135648522:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadEncryptedHistory();
                case 1157265941:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncrypted();
                case 1431914525:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedFile();
                case 852769188:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedService();
                case 1436924774:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedQueue();
                case 1259113487:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportEncryptedSpam();
                case 916930423:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMessageContents();
                case 71126828:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers();
                case 479598769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllStickers();
                case -1956073268:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPagePreview();
                case 234312524:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportChatInvite();
                case 1051570619:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckChatInvite();
                case 1817183516:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ImportChatInvite();
                case 639215886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickerSet();
                case -946871200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.InstallStickerSet();
                case -110209570:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UninstallStickerSet();
                case -421563528:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot();
                case 1468322785:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesViews();
                case -1444503762:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAdmin();
                case 363051235:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MigrateChat();
                case 1271290010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchGlobal();
                case 2016638777:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderStickerSets();
                case 864953444:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDocumentByHash();
                case -2084618926:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSavedGifs();
                case 846868683:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveGif();
                case 1364105629:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineBotResults();
                case -346119674:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineBotResults();
                case 570955184:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendInlineBotResult();
                case -39416522:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageEditData();
                case 1224152952:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditMessage();
                case -2091549254:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditInlineBotMessage();
                case -1824339449:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetBotCallbackAnswer();
                case -712043766:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotCallbackAnswer();
                case -462373635:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerDialogs();
                case -1137057461:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDraft();
                case 1782549861:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllDrafts();
                case 766298703:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFeaturedStickers();
                case 1527873830:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadFeaturedStickers();
                case 1587647177:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentStickers();
                case 958863608:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveRecentSticker();
                case -1986437075:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearRecentStickers();
                case 1475442322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetArchivedStickers();
                case 1706608543:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMaskStickers();
                case -866424884:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachedStickers();
                case -1896289088:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetGameScore();
                case 363700068:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineGameScore();
                case -400399203:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetGameHighScores();
                case 258170395:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineGameHighScores();
                case 218777796:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetCommonChats();
                case -341307408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllChats();
                case 852135825:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPage();
                case -1489903017:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleDialogPin();
                case 991616823:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderPinnedDialogs();
                case -692498958:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPinnedDialogs();
                case -436833542:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotShippingResults();
                case 163765653:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotPrecheckoutResults();
                case 1369162417:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadMedia();
                case -914493408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScreenshotNotification();
                case 567151374:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFavedStickers();
                case -1174420133:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FaveSticker();
                case 1180140658:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions();
                case 251759059:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMentions();
                case -1144759543:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentLocations();
                case -872345397:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMultiMedia();
                case 1347929239:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadEncryptedFile();
                case -1028140917:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchStickerSets();
                case 486505992:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSplitRanges();
                case -1031349873:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MarkDialogUnread();
                case 585256482:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogUnreadMarks();
                case 2119757468:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearAllDrafts();
                case -760547348:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdatePinnedMessage();
                case 283795844:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendVote();
                case 1941660731:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollResults();
                case 1848369232:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOnlines();
                case -2127811866:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStatsURL();
                case -554301545:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAbout();
                case -1517917375:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatDefaultBannedRights();
                case 899735650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywords();
                case 352892591:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsDifference();
                case 1318675378:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsLanguages();
                case -709817306:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiURL();
                case 1932455680:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchCounters();
                case -482388461:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestUrlAuth();
                case -148247912:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptUrlAuth();
                case 1336717624:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HidePeerSettingsBar();
                case -490575781:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledHistory();
                case -1111817116:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledMessages();
                case -1120369398:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScheduledMessages();
                case 1504586518:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteScheduledMessages();
                case -1200736242:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollVotes();
                case -1257951254:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleStickerSets();
                case -241247891:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogFilters();
                case -1566780372:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSuggestedDialogFilters();
                case 450142282:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFilter();
                case -983318044:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFiltersOrder();
                case 1608974939:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOldFeaturedStickers();
                case 615875002:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetReplies();
                case 1147761405:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDiscussionMessage();
                case -147740172:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadDiscussion();
                case -265962357:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UnpinAllMessages();
                case -304838614:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetState();
                case 630429265:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetDifference();
                case 51854712:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetChannelDifference();
                case 1926525996:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.UpdateProfilePhoto();
                case -1980559511:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.UploadProfilePhoto();
                case -2016444625:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.DeletePhotos();
                case -1848823128:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.GetUserPhotos();
                case -1291540959:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveFilePart();
                case -1319462148:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFile();
                case -562337987:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveBigFilePart();
                case 619086221:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetWebFile();
                case 536919235:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFile();
                case -1691921240:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.ReuploadCdnFile();
                case 1302676017:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFileHashes();
                case -956147407:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFileHashes();
                case -990308245:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetConfig();
                case 531836966:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetNearestDc();
                case 1378703997:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppUpdate();
                case 1295590211:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetInviteText();
                case -1663104819:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupport();
                case -1877938321:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppChangelog();
                case -333262899:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.SetBotUpdatesStatus();
                case 1375900482:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCdnConfig();
                case 1036054804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetRecentMeUrls();
                case 749019089:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetTermsOfServiceUpdate();
                case -294455398:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.AcceptTermsOfService();
                case 1072547679:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetDeepLinkInfo();
                case -1735311088:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppConfig();
                case 1862465352:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.SaveAppLog();
                case -966677240:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPassportConfig();
                case -748624084:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupportName();
                case 59377875:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetUserInfo();
                case 1723407216:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.EditUserInfo();
                case -1063816159:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPromoData();
                case 505748629:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.HidePromoData();
                case 125807007:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.DismissSuggestion();
                case 1935116200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCountriesList();
                case -871347913:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory();
                case -2067661490:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages();
                case -787622117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteUserHistory();
                case -32999408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam();
                case -1383294429:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages();
                case 306054633:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipants();
                case 1416484774:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipant();
                case 176122811:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetChannels();
                case 141781513:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetFullChannel();
                case 1029681423:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.CreateChannel();
                case -751007486:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditAdmin();
                case 1450044624:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditTitle();
                case -248621111:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditPhoto();
                case 283557164:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.CheckUsername();
                case 890549214:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.UpdateUsername();
                case 615851205:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.JoinChannel();
                case -130635115:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.LeaveChannel();
                case 429865580:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.InviteToChannel();
                case -1072619549:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteChannel();
                case -432034325:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ExportMessageLink();
                case 527021574:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSignatures();
                case -122669393:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminedPublicChannels();
                case 1920559378:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned();
                case 870184064:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog();
                case -359881479:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetStickers();
                case -357180360:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents();
                case -1355375294:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory();
                case -356796084:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.TogglePreHistoryHidden();
                case -2092831552:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetLeftChannels();
                case -170208392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetGroupsForDiscussion();
                case 1079520178:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetDiscussionGroup();
                case -1892102881:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditCreator();
                case 1491484525:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditLocation();
                case -304832784:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSlowMode();
                case 300429806:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetInactiveChannels();
                case -1440257555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SendCustomRequest();
                case -434028723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.AnswerWebhookJSONQuery();
                case -2141370634:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotCommands();
                case -1712285883:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentForm();
                case -1601001088:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentReceipt();
                case 1997180532:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidateRequestedInfo();
                case 730364339:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm();
                case 578650699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetSavedInfo();
                case -667062079:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ClearSavedInfo();
                case 779736953:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetBankCardData();
                case -251435136:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CreateStickerSet();
                case -143257775:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.RemoveStickerFromSet();
                case -4795190:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.ChangeStickerPosition();
                case -2041315650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.AddStickerToSet();
                case -1707717072:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SetStickerSetThumb();
                case 1430593449:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetCallConfig();
                case 1124046573:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.RequestCall();
                case 1003664544:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.AcceptCall();
                case 788404002:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ConfirmCall();
                case 399855457:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ReceivedCall();
                case -1295269440:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.DiscardCall();
                case 1508562471:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.SetCallRating();
                case 662363518:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveCallDebug();
                case -8744061:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.SendSignalingData();
                case -219008246:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLangPack();
                case -269862909:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetStrings();
                case -845657435:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetDifference();
                case 1120311183:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguages();
                case 1784243458:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguage();
                case 1749536939:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Folders.EditPeerFolders();
                case 472471681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Folders.DeleteFolder();
                case -1421720550:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetBroadcastStats();
                case 1646092192:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.LoadAsyncGraph();
                case -589330937:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMegagroupStats();
                case 1445996571:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessagePublicForwards();
                case -1226791947:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessageStats();
                case 85337187:
                    return new CatraProto.Client.TL.Schemas.MTProto.ResPQ();
                case -2083955988:
                    return new CatraProto.Client.TL.Schemas.MTProto.PQInnerData();
                case 1013613780:
                    return new CatraProto.Client.TL.Schemas.MTProto.PQInnerDataTemp();
                case 2043348061:
                    return new CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsFail();
                case -790100132:
                    return new CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsOk();
                case -1249309254:
                    return new CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerData();
                case 1715713620:
                    return new CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerData();
                case 1003222836:
                    return new CatraProto.Client.TL.Schemas.MTProto.DhGenOk();
                case 1188831161:
                    return new CatraProto.Client.TL.Schemas.MTProto.DhGenRetry();
                case -1499615742:
                    return new CatraProto.Client.TL.Schemas.MTProto.DhGenFail();
                case -212046591:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcResult();
                case 558156313:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcError();
                case 1579864942:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerUnknown();
                case -847714938:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDroppedRunning();
                case -1539647305:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDropped();
                case 155834844:
                    return new CatraProto.Client.TL.Schemas.MTProto.FutureSalt();
                case -1370486635:
                    return new CatraProto.Client.TL.Schemas.MTProto.FutureSalts();
                case 880243653:
                    return new CatraProto.Client.TL.Schemas.MTProto.Pong();
                case -501201412:
                    return new CatraProto.Client.TL.Schemas.MTProto.DestroySessionOk();
                case 1658015945:
                    return new CatraProto.Client.TL.Schemas.MTProto.DestroySessionNone();
                case -1631450872:
                    return new CatraProto.Client.TL.Schemas.MTProto.NewSessionCreated();
                case 1945237724:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgContainer();
                case -530561358:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgCopy();
                case 812830625:
                    return new CatraProto.Client.TL.Schemas.MTProto.GzipPacked();
                case 1658238041:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgsAck();
                case -1477445615:
                    return new CatraProto.Client.TL.Schemas.MTProto.BadMsgNotification();
                case -307542917:
                    return new CatraProto.Client.TL.Schemas.MTProto.BadServerSalt();
                case 2105940488:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgResendReq();
                case -630588590:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq();
                case 81704317:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfo();
                case -1933520591:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfo();
                case 661470918:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfo();
                case -2137147681:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgNewDetailedInfo();
                case 1973679973:
                    return new CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInner();
                case 1615239032:
                    return new CatraProto.Client.TL.Schemas.MTProto.ReqPq();
                case -1099002127:
                    return new CatraProto.Client.TL.Schemas.MTProto.ReqPqMulti();
                case -686627650:
                    return new CatraProto.Client.TL.Schemas.MTProto.ReqDHParams();
                case -184262881:
                    return new CatraProto.Client.TL.Schemas.MTProto.SetClientDHParams();
                case 1491380032:
                    return new CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswer();
                case -1188971260:
                    return new CatraProto.Client.TL.Schemas.MTProto.GetFutureSalts();
                case 2059302892:
                    return new CatraProto.Client.TL.Schemas.MTProto.Ping();
                case -213746804:
                    return new CatraProto.Client.TL.Schemas.MTProto.PingDelayDisconnect();
                case -414113498:
                    return new CatraProto.Client.TL.Schemas.MTProto.DestroySession();
                case -1835453025:
                    return new CatraProto.Client.TL.Schemas.MTProto.HttpWait();
            }


            return null;
        }
    }
}