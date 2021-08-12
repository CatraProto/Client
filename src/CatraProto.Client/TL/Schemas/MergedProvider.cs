using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Bots;
using CatraProto.Client.TL.Schemas.CloudChats.Channels;
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;
using CatraProto.Client.TL.Schemas.CloudChats.Folders;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.CloudChats.Payments;
using CatraProto.Client.TL.Schemas.CloudChats.Phone;
using CatraProto.Client.TL.Schemas.CloudChats.Photos;
using CatraProto.Client.TL.Schemas.CloudChats.Stats;
using CatraProto.Client.TL.Schemas.CloudChats.Stickers;
using CatraProto.Client.TL.Schemas.CloudChats.Storage;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.Client.TL.Schemas.CloudChats.Upload;
using CatraProto.Client.TL.Schemas.CloudChats.Users;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;
using AutoDownloadSettings = CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettings;
using ChannelParticipant = CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipant;
using ChatFull = CatraProto.Client.TL.Schemas.CloudChats.ChatFull;
using CheckUsername = CatraProto.Client.TL.Schemas.CloudChats.Account.CheckUsername;
using DeleteHistory = CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory;
using DeleteMessages = CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteMessages;
using GetDifference = CatraProto.Client.TL.Schemas.CloudChats.Updates.GetDifference;
using GetMessages = CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessages;
using Message = CatraProto.Client.TL.Schemas.CloudChats.Message;
using MessageViews = CatraProto.Client.TL.Schemas.CloudChats.MessageViews;
using PhoneCall = CatraProto.Client.TL.Schemas.CloudChats.PhoneCall;
using Photo = CatraProto.Client.TL.Schemas.CloudChats.Photo;
using ReadHistory = CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory;
using ReadMessageContents = CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMessageContents;
using ReportSpam = CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam;
using Search = CatraProto.Client.TL.Schemas.CloudChats.Contacts.Search;
using StickerSet = CatraProto.Client.TL.Schemas.CloudChats.StickerSet;
using UpdateDialogFilter = CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilter;
using UpdateNotifySettings = CatraProto.Client.TL.Schemas.CloudChats.UpdateNotifySettings;
using UpdateTheme = CatraProto.Client.TL.Schemas.CloudChats.UpdateTheme;
using UpdateUsername = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateUsername;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
	    public override IObject ResolveConstructorId(int constructorId)
        {
	        if (InternalResolveConstructorId(constructorId, out var obj))
            {
	            return obj;
            }

	        switch (constructorId)
	        {
		        case -1132882121:
			        return new BoolFalse();
		        case -1720552011:
			        return new BoolTrue();
		        case 1450380236:
			        return new Null();
		        case 2134579434:
			        return new InputPeerEmpty();
		        case 2107670217:
			        return new InputPeerSelf();
		        case 396093539:
			        return new InputPeerChat();
		        case 2072935910:
			        return new InputPeerUser();
		        case 548253432:
			        return new InputPeerChannel();
		        case 398123750:
			        return new InputPeerUserFromMessage();
		        case -1667893317:
			        return new InputPeerChannelFromMessage();
		        case -1182234929:
			        return new InputUserEmpty();
		        case -138301121:
			        return new InputUserSelf();
		        case -668391402:
			        return new InputUser();
		        case 756118935:
			        return new InputUserFromMessage();
		        case -208488460:
			        return new InputPhoneContact();
		        case -181407105:
			        return new InputFile();
		        case -95482955:
			        return new InputFileBig();
		        case -1771768449:
			        return new InputMediaEmpty();
		        case 505969924:
			        return new InputMediaUploadedPhoto();
		        case -1279654347:
			        return new InputMediaPhoto();
		        case -104578748:
			        return new InputMediaGeoPoint();
		        case -122978821:
			        return new InputMediaContact();
		        case 1530447553:
			        return new InputMediaUploadedDocument();
		        case 598418386:
			        return new InputMediaDocument();
		        case -1052959727:
			        return new InputMediaVenue();
		        case -440664550:
			        return new InputMediaPhotoExternal();
		        case -78455655:
			        return new InputMediaDocumentExternal();
		        case -750828557:
			        return new InputMediaGame();
		        case -186607933:
			        return new InputMediaInvoice();
		        case -1759532989:
			        return new InputMediaGeoLive();
		        case 261416433:
			        return new InputMediaPoll();
		        case -428884101:
			        return new InputMediaDice();
		        case 480546647:
			        return new InputChatPhotoEmpty();
		        case -968723890:
			        return new InputChatUploadedPhoto();
		        case -1991004873:
			        return new InputChatPhoto();
		        case -457104426:
			        return new InputGeoPointEmpty();
		        case 1210199983:
			        return new InputGeoPoint();
		        case 483901197:
			        return new InputPhotoEmpty();
		        case 1001634122:
			        return new InputPhoto();
		        case -539317279:
			        return new InputFileLocation();
		        case -182231723:
			        return new InputEncryptedFileLocation();
		        case -1160743548:
			        return new InputDocumentFileLocation();
		        case -876089816:
			        return new InputSecureFileLocation();
		        case 700340377:
			        return new InputTakeoutFileLocation();
		        case 1075322878:
			        return new InputPhotoFileLocation();
		        case -667654413:
			        return new InputPhotoLegacyFileLocation();
		        case 668375447:
			        return new InputPeerPhotoFileLocation();
		        case 230353641:
			        return new InputStickerSetThumb();
		        case -1649296275:
			        return new PeerUser();
		        case -1160714821:
			        return new PeerChat();
		        case -1109531342:
			        return new PeerChannel();
		        case -1432995067:
			        return new FileUnknown();
		        case 1086091090:
			        return new FilePartial();
		        case 8322574:
			        return new FileJpeg();
		        case -891180321:
			        return new FileGif();
		        case 172975040:
			        return new FilePng();
		        case -1373745011:
			        return new FilePdf();
		        case 1384777335:
			        return new FileMp3();
		        case 1258941372:
			        return new FileMov();
		        case -1278304028:
			        return new FileMp4();
		        case 276907596:
			        return new FileWebp();
		        case 537022650:
			        return new UserEmpty();
		        case -1820043071:
			        return new User();
		        case 1326562017:
			        return new UserProfilePhotoEmpty();
		        case 1775479590:
			        return new UserProfilePhoto();
		        case 164646985:
			        return new UserStatusEmpty();
		        case -306628279:
			        return new UserStatusOnline();
		        case 9203775:
			        return new UserStatusOffline();
		        case -496024847:
			        return new UserStatusRecently();
		        case 129960444:
			        return new UserStatusLastWeek();
		        case 2011940674:
			        return new UserStatusLastMonth();
		        case -1683826688:
			        return new ChatEmpty();
		        case 1004149726:
			        return new Chat();
		        case 120753115:
			        return new ChatForbidden();
		        case -753232354:
			        return new Channel();
		        case 681420594:
			        return new ChannelForbidden();
		        case 461151667:
			        return new ChatFull();
		        case -253335766:
			        return new ChannelFull();
		        case -925415106:
			        return new ChatParticipant();
		        case -636267638:
			        return new ChatParticipantCreator();
		        case -489233354:
			        return new ChatParticipantAdmin();
		        case -57668565:
			        return new ChatParticipantsForbidden();
		        case 1061556205:
			        return new ChatParticipants();
		        case 935395612:
			        return new ChatPhotoEmpty();
		        case -770990276:
			        return new ChatPhoto();
		        case -2082087340:
			        return new MessageEmpty();
		        case 1487813065:
			        return new Message();
		        case 678405636:
			        return new MessageService();
		        case 1038967584:
			        return new MessageMediaEmpty();
		        case 1766936791:
			        return new MessageMediaPhoto();
		        case 1457575028:
			        return new MessageMediaGeo();
		        case -873313984:
			        return new MessageMediaContact();
		        case -1618676578:
			        return new MessageMediaUnsupported();
		        case -1666158377:
			        return new MessageMediaDocument();
		        case -1557277184:
			        return new MessageMediaWebPage();
		        case 784356159:
			        return new MessageMediaVenue();
		        case -38694904:
			        return new MessageMediaGame();
		        case -2074799289:
			        return new MessageMediaInvoice();
		        case -1186937242:
			        return new MessageMediaGeoLive();
		        case 1272375192:
			        return new MessageMediaPoll();
		        case 1065280907:
			        return new MessageMediaDice();
		        case -1230047312:
			        return new MessageActionEmpty();
		        case -1503425638:
			        return new MessageActionChatCreate();
		        case -1247687078:
			        return new MessageActionChatEditTitle();
		        case 2144015272:
			        return new MessageActionChatEditPhoto();
		        case -1780220945:
			        return new MessageActionChatDeletePhoto();
		        case 1217033015:
			        return new MessageActionChatAddUser();
		        case -1297179892:
			        return new MessageActionChatDeleteUser();
		        case -123931160:
			        return new MessageActionChatJoinedByLink();
		        case -1781355374:
			        return new MessageActionChannelCreate();
		        case 1371385889:
			        return new MessageActionChatMigrateTo();
		        case -1336546578:
			        return new MessageActionChannelMigrateFrom();
		        case -1799538451:
			        return new MessageActionPinMessage();
		        case -1615153660:
			        return new MessageActionHistoryClear();
		        case -1834538890:
			        return new MessageActionGameScore();
		        case -1892568281:
			        return new MessageActionPaymentSentMe();
		        case 1080663248:
			        return new MessageActionPaymentSent();
		        case -2132731265:
			        return new MessageActionPhoneCall();
		        case 1200788123:
			        return new MessageActionScreenshotTaken();
		        case -85549226:
			        return new MessageActionCustomAction();
		        case -1410748418:
			        return new MessageActionBotAllowed();
		        case 455635795:
			        return new MessageActionSecureValuesSentMe();
		        case -648257196:
			        return new MessageActionSecureValuesSent();
		        case -202219658:
			        return new MessageActionContactSignUp();
		        case -1730095465:
			        return new MessageActionGeoProximityReached();
		        case 739712882:
			        return new Dialog();
		        case 1908216652:
			        return new DialogFolder();
		        case 590459437:
			        return new PhotoEmpty();
		        case -82216347:
			        return new Photo();
		        case 236446268:
			        return new PhotoSizeEmpty();
		        case 2009052699:
			        return new PhotoSize();
		        case -374917894:
			        return new PhotoCachedSize();
		        case -525288402:
			        return new PhotoStrippedSize();
		        case 1520986705:
			        return new PhotoSizeProgressive();
		        case -668906175:
			        return new PhotoPathSize();
		        case 286776671:
			        return new GeoPointEmpty();
		        case -1297942941:
			        return new GeoPoint();
		        case 1577067778:
			        return new SentCode();
		        case -855308010:
			        return new Authorization();
		        case 1148485274:
			        return new AuthorizationSignUpRequired();
		        case -543777747:
			        return new ExportedAuthorization();
		        case -1195615476:
			        return new InputNotifyPeer();
		        case 423314455:
			        return new InputNotifyUsers();
		        case 1251338318:
			        return new InputNotifyChats();
		        case -1311015810:
			        return new InputNotifyBroadcasts();
		        case -1673717362:
			        return new InputPeerNotifySettings();
		        case -1353671392:
			        return new PeerNotifySettings();
		        case 1933519201:
			        return new PeerSettings();
		        case -1539849235:
			        return new WallPaper();
		        case -1963717851:
			        return new WallPaperNoFile();
		        case 1490799288:
			        return new InputReportReasonSpam();
		        case 505595789:
			        return new InputReportReasonViolence();
		        case 777640226:
			        return new InputReportReasonPornography();
		        case -1376497949:
			        return new InputReportReasonChildAbuse();
		        case -512463606:
			        return new InputReportReasonOther();
		        case -1685456582:
			        return new InputReportReasonCopyright();
		        case -606798099:
			        return new InputReportReasonGeoIrrelevant();
		        case -302941166:
			        return new UserFull();
		        case -116274796:
			        return new Contact();
		        case -805141448:
			        return new ImportedContact();
		        case -748155807:
			        return new ContactStatus();
		        case -1219778094:
			        return new ContactsNotModified();
		        case -353862078:
			        return new CContacts();
		        case 2010127419:
			        return new ImportedContacts();
		        case 182326673:
			        return new Blocked();
		        case -513392236:
			        return new BlockedSlice();
		        case 364538944:
			        return new Dialogs();
		        case 1910543603:
			        return new DialogsSlice();
		        case -253500010:
			        return new DialogsNotModified();
		        case -1938715001:
			        return new MMessages();
		        case 978610270:
			        return new MessagesSlice();
		        case 1682413576:
			        return new ChannelMessages();
		        case 1951620897:
			        return new MessagesNotModified();
		        case 1694474197:
			        return new Chats();
		        case -1663561404:
			        return new ChatsSlice();
		        case -438840932:
			        return new CloudChats.Messages.ChatFull();
		        case -1269012015:
			        return new AffectedHistory();
		        case 1474492012:
			        return new InputMessagesFilterEmpty();
		        case -1777752804:
			        return new InputMessagesFilterPhotos();
		        case -1614803355:
			        return new InputMessagesFilterVideo();
		        case 1458172132:
			        return new InputMessagesFilterPhotoVideo();
		        case -1629621880:
			        return new InputMessagesFilterDocument();
		        case 2129714567:
			        return new InputMessagesFilterUrl();
		        case -3644025:
			        return new InputMessagesFilterGif();
		        case 1358283666:
			        return new InputMessagesFilterVoice();
		        case 928101534:
			        return new InputMessagesFilterMusic();
		        case 975236280:
			        return new InputMessagesFilterChatPhotos();
		        case -2134272152:
			        return new InputMessagesFilterPhoneCalls();
		        case 2054952868:
			        return new InputMessagesFilterRoundVoice();
		        case -1253451181:
			        return new InputMessagesFilterRoundVideo();
		        case -1040652646:
			        return new InputMessagesFilterMyMentions();
		        case -419271411:
			        return new InputMessagesFilterGeo();
		        case -530392189:
			        return new InputMessagesFilterContacts();
		        case 464520273:
			        return new InputMessagesFilterPinned();
		        case 522914557:
			        return new UpdateNewMessage();
		        case 1318109142:
			        return new UpdateMessageID();
		        case -1576161051:
			        return new UpdateDeleteMessages();
		        case 1548249383:
			        return new UpdateUserTyping();
		        case -1704596961:
			        return new UpdateChatUserTyping();
		        case 125178264:
			        return new UpdateChatParticipants();
		        case 469489699:
			        return new UpdateUserStatus();
		        case -1489818765:
			        return new UpdateUserName();
		        case -1791935732:
			        return new UpdateUserPhoto();
		        case 314359194:
			        return new UpdateNewEncryptedMessage();
		        case 386986326:
			        return new UpdateEncryptedChatTyping();
		        case -1264392051:
			        return new UpdateEncryption();
		        case 956179895:
			        return new UpdateEncryptedMessagesRead();
		        case -364179876:
			        return new UpdateChatParticipantAdd();
		        case 1851755554:
			        return new UpdateChatParticipantDelete();
		        case -1906403213:
			        return new UpdateDcOptions();
		        case -1094555409:
			        return new UpdateNotifySettings();
		        case -337352679:
			        return new UpdateServiceNotification();
		        case -298113238:
			        return new UpdatePrivacy();
		        case 314130811:
			        return new UpdateUserPhone();
		        case -1667805217:
			        return new UpdateReadHistoryInbox();
		        case 791617983:
			        return new UpdateReadHistoryOutbox();
		        case 2139689491:
			        return new UpdateWebPage();
		        case 1757493555:
			        return new UpdateReadMessagesContents();
		        case -352032773:
			        return new UpdateChannelTooLong();
		        case -1227598250:
			        return new UpdateChannel();
		        case 1656358105:
			        return new UpdateNewChannelMessage();
		        case 856380452:
			        return new UpdateReadChannelInbox();
		        case -1015733815:
			        return new UpdateDeleteChannelMessages();
		        case -1734268085:
			        return new UpdateChannelMessageViews();
		        case -1232070311:
			        return new UpdateChatParticipantAdmin();
		        case 1753886890:
			        return new UpdateNewStickerSet();
		        case 196268545:
			        return new UpdateStickerSetsOrder();
		        case 1135492588:
			        return new UpdateStickerSets();
		        case -1821035490:
			        return new UpdateSavedGifs();
		        case 1417832080:
			        return new UpdateBotInlineQuery();
		        case 239663460:
			        return new UpdateBotInlineSend();
		        case 457133559:
			        return new UpdateEditChannelMessage();
		        case -415938591:
			        return new UpdateBotCallbackQuery();
		        case -469536605:
			        return new UpdateEditMessage();
		        case -103646630:
			        return new UpdateInlineBotCallbackQuery();
		        case 634833351:
			        return new UpdateReadChannelOutbox();
		        case -299124375:
			        return new UpdateDraftMessage();
		        case 1461528386:
			        return new UpdateReadFeaturedStickers();
		        case -1706939360:
			        return new UpdateRecentStickers();
		        case -1574314746:
			        return new UpdateConfig();
		        case 861169551:
			        return new UpdatePtsChanged();
		        case 1081547008:
			        return new UpdateChannelWebPage();
		        case 1852826908:
			        return new UpdateDialogPinned();
		        case -99664734:
			        return new UpdatePinnedDialogs();
		        case -2095595325:
			        return new UpdateBotWebhookJSON();
		        case -1684914010:
			        return new UpdateBotWebhookJSONQuery();
		        case -523384512:
			        return new UpdateBotShippingQuery();
		        case 1563376297:
			        return new UpdateBotPrecheckoutQuery();
		        case -1425052898:
			        return new UpdatePhoneCall();
		        case 1180041828:
			        return new UpdateLangPackTooLong();
		        case 1442983757:
			        return new UpdateLangPack();
		        case -451831443:
			        return new UpdateFavedStickers();
		        case -1987495099:
			        return new UpdateChannelReadMessagesContents();
		        case 1887741886:
			        return new UpdateContactsReset();
		        case 1893427255:
			        return new UpdateChannelAvailableMessages();
		        case -513517117:
			        return new UpdateDialogUnreadMark();
		        case -1398708869:
			        return new UpdateMessagePoll();
		        case 1421875280:
			        return new UpdateChatDefaultBannedRights();
		        case 422972864:
			        return new UpdateFolderPeers();
		        case 1786671974:
			        return new UpdatePeerSettings();
		        case -1263546448:
			        return new UpdatePeerLocated();
		        case 967122427:
			        return new UpdateNewScheduledMessage();
		        case -1870238482:
			        return new UpdateDeleteScheduledMessages();
		        case -2112423005:
			        return new UpdateTheme();
		        case -2027964103:
			        return new UpdateGeoLiveViewed();
		        case 1448076945:
			        return new UpdateLoginToken();
		        case 1123585836:
			        return new UpdateMessagePollVote();
		        case 654302845:
			        return new UpdateDialogFilter();
		        case -1512627963:
			        return new UpdateDialogFilterOrder();
		        case 889491791:
			        return new UpdateDialogFilters();
		        case 643940105:
			        return new UpdatePhoneCallSignalingData();
		        case 1708307556:
			        return new UpdateChannelParticipant();
		        case 1854571743:
			        return new UpdateChannelMessageForwards();
		        case 482860628:
			        return new UpdateReadChannelDiscussionInbox();
		        case 1178116716:
			        return new UpdateReadChannelDiscussionOutbox();
		        case 610945826:
			        return new UpdatePeerBlocked();
		        case -13975905:
			        return new UpdateChannelUserTyping();
		        case -309990731:
			        return new UpdatePinnedMessages();
		        case -2054649973:
			        return new UpdatePinnedChannelMessages();
		        case -1519637954:
			        return new State();
		        case 1567990072:
			        return new DifferenceEmpty();
		        case 16030880:
			        return new Difference();
		        case -1459938943:
			        return new DifferenceSlice();
		        case 1258196845:
			        return new DifferenceTooLong();
		        case -484987010:
			        return new UpdatesTooLong();
		        case 580309704:
			        return new UpdateShortMessage();
		        case 1076714939:
			        return new UpdateShortChatMessage();
		        case 2027216577:
			        return new UpdateShort();
		        case 1918567619:
			        return new UpdatesCombined();
		        case 1957577280:
			        return new UUpdates();
		        case 301019932:
			        return new UpdateShortSentMessage();
		        case -1916114267:
			        return new PPhotos();
		        case 352657236:
			        return new PhotosSlice();
		        case 539045032:
			        return new CloudChats.Photos.Photo();
		        case 157948117:
			        return new File();
		        case -242427324:
			        return new FileCdnRedirect();
		        case 414687501:
			        return new DcOption();
		        case 856375399:
			        return new Config();
		        case -1910892683:
			        return new NearestDc();
		        case 497489295:
			        return new AppUpdate();
		        case -1000708810:
			        return new NoAppUpdate();
		        case 415997816:
			        return new InviteText();
		        case -1417756512:
			        return new EncryptedChatEmpty();
		        case 1006044124:
			        return new EncryptedChatWaiting();
		        case 1651608194:
			        return new EncryptedChatRequested();
		        case -94974410:
			        return new EncryptedChat();
		        case 332848423:
			        return new EncryptedChatDiscarded();
		        case -247351839:
			        return new InputEncryptedChat();
		        case -1038136962:
			        return new EncryptedFileEmpty();
		        case 1248893260:
			        return new EncryptedFile();
		        case 406307684:
			        return new InputEncryptedFileEmpty();
		        case 1690108678:
			        return new InputEncryptedFileUploaded();
		        case 1511503333:
			        return new InputEncryptedFile();
		        case 767652808:
			        return new InputEncryptedFileBigUploaded();
		        case -317144808:
			        return new EncryptedMessage();
		        case 594758406:
			        return new EncryptedMessageService();
		        case -1058912715:
			        return new DhConfigNotModified();
		        case 740433629:
			        return new DhConfig();
		        case 1443858741:
			        return new SentEncryptedMessage();
		        case -1802240206:
			        return new SentEncryptedFile();
		        case 1928391342:
			        return new InputDocumentEmpty();
		        case 448771445:
			        return new InputDocument();
		        case 922273905:
			        return new DocumentEmpty();
		        case 512177195:
			        return new Document();
		        case 398898678:
			        return new Support();
		        case -1613493288:
			        return new NotifyPeer();
		        case -1261946036:
			        return new NotifyUsers();
		        case -1073230141:
			        return new NotifyChats();
		        case -703403793:
			        return new NotifyBroadcasts();
		        case 381645902:
			        return new SendMessageTypingAction();
		        case -44119819:
			        return new SendMessageCancelAction();
		        case -1584933265:
			        return new SendMessageRecordVideoAction();
		        case -378127636:
			        return new SendMessageUploadVideoAction();
		        case -718310409:
			        return new SendMessageRecordAudioAction();
		        case -212740181:
			        return new SendMessageUploadAudioAction();
		        case -774682074:
			        return new SendMessageUploadPhotoAction();
		        case -1441998364:
			        return new SendMessageUploadDocumentAction();
		        case 393186209:
			        return new SendMessageGeoLocationAction();
		        case 1653390447:
			        return new SendMessageChooseContactAction();
		        case -580219064:
			        return new SendMessageGamePlayAction();
		        case -1997373508:
			        return new SendMessageRecordRoundAction();
		        case 608050278:
			        return new SendMessageUploadRoundAction();
		        case -1290580579:
			        return new Found();
		        case 1335282456:
			        return new InputPrivacyKeyStatusTimestamp();
		        case -1107622874:
			        return new InputPrivacyKeyChatInvite();
		        case -88417185:
			        return new InputPrivacyKeyPhoneCall();
		        case -610373422:
			        return new InputPrivacyKeyPhoneP2P();
		        case -1529000952:
			        return new InputPrivacyKeyForwards();
		        case 1461304012:
			        return new InputPrivacyKeyProfilePhoto();
		        case 55761658:
			        return new InputPrivacyKeyPhoneNumber();
		        case -786326563:
			        return new InputPrivacyKeyAddedByPhone();
		        case -1137792208:
			        return new PrivacyKeyStatusTimestamp();
		        case 1343122938:
			        return new PrivacyKeyChatInvite();
		        case 1030105979:
			        return new PrivacyKeyPhoneCall();
		        case 961092808:
			        return new PrivacyKeyPhoneP2P();
		        case 1777096355:
			        return new PrivacyKeyForwards();
		        case -1777000467:
			        return new PrivacyKeyProfilePhoto();
		        case -778378131:
			        return new PrivacyKeyPhoneNumber();
		        case 1124062251:
			        return new PrivacyKeyAddedByPhone();
		        case 218751099:
			        return new InputPrivacyValueAllowContacts();
		        case 407582158:
			        return new InputPrivacyValueAllowAll();
		        case 320652927:
			        return new InputPrivacyValueAllowUsers();
		        case 195371015:
			        return new InputPrivacyValueDisallowContacts();
		        case -697604407:
			        return new InputPrivacyValueDisallowAll();
		        case -1877932953:
			        return new InputPrivacyValueDisallowUsers();
		        case 1283572154:
			        return new InputPrivacyValueAllowChatParticipants();
		        case -668769361:
			        return new InputPrivacyValueDisallowChatParticipants();
		        case -123988:
			        return new PrivacyValueAllowContacts();
		        case 1698855810:
			        return new PrivacyValueAllowAll();
		        case 1297858060:
			        return new PrivacyValueAllowUsers();
		        case -125240806:
			        return new PrivacyValueDisallowContacts();
		        case -1955338397:
			        return new PrivacyValueDisallowAll();
		        case 209668535:
			        return new PrivacyValueDisallowUsers();
		        case 415136107:
			        return new PrivacyValueAllowChatParticipants();
		        case -1397881200:
			        return new PrivacyValueDisallowChatParticipants();
		        case 1352683077:
			        return new PrivacyRules();
		        case -1194283041:
			        return new AccountDaysTTL();
		        case 1815593308:
			        return new DocumentAttributeImageSize();
		        case 297109817:
			        return new DocumentAttributeAnimated();
		        case 1662637586:
			        return new DocumentAttributeSticker();
		        case 250621158:
			        return new DocumentAttributeVideo();
		        case -1739392570:
			        return new DocumentAttributeAudio();
		        case 358154344:
			        return new DocumentAttributeFilename();
		        case -1744710921:
			        return new DocumentAttributeHasStickers();
		        case -244016606:
			        return new StickersNotModified();
		        case -463889475:
			        return new Stickers();
		        case 313694676:
			        return new StickerPack();
		        case -395967805:
			        return new AllStickersNotModified();
		        case -302170017:
			        return new AllStickers();
		        case -2066640507:
			        return new AffectedMessages();
		        case -350980120:
			        return new WebPageEmpty();
		        case -981018084:
			        return new WebPagePending();
		        case -392411726:
			        return new WebPage();
		        case 1930545681:
			        return new WebPageNotModified();
		        case -1392388579:
			        return new CloudChats.Authorization();
		        case 307276766:
			        return new Authorizations();
		        case -1390001672:
			        return new Password();
		        case -1705233435:
			        return new PasswordSettings();
		        case -1036572727:
			        return new PasswordInputSettings();
		        case 326715557:
			        return new PasswordRecovery();
		        case -1551583367:
			        return new ReceivedNotifyMessage();
		        case 1776236393:
			        return new ChatInviteEmpty();
		        case -64092740:
			        return new ChatInviteExported();
		        case 1516793212:
			        return new ChatInviteAlready();
		        case -540871282:
			        return new ChatInvite();
		        case 1634294960:
			        return new ChatInvitePeek();
		        case -4838507:
			        return new InputStickerSetEmpty();
		        case -1645763991:
			        return new InputStickerSetID();
		        case -2044933984:
			        return new InputStickerSetShortName();
		        case 42402760:
			        return new InputStickerSetAnimatedEmoji();
		        case -427863538:
			        return new InputStickerSetDice();
		        case -290164953:
			        return new StickerSet();
		        case -1240849242:
			        return new CloudChats.Messages.StickerSet();
		        case -1032140601:
			        return new BotCommand();
		        case -1729618630:
			        return new BotInfo();
		        case -1560655744:
			        return new KeyboardButton();
		        case 629866245:
			        return new KeyboardButtonUrl();
		        case 901503851:
			        return new KeyboardButtonCallback();
		        case -1318425559:
			        return new KeyboardButtonRequestPhone();
		        case -59151553:
			        return new KeyboardButtonRequestGeoLocation();
		        case 90744648:
			        return new KeyboardButtonSwitchInline();
		        case 1358175439:
			        return new KeyboardButtonGame();
		        case -1344716869:
			        return new KeyboardButtonBuy();
		        case 280464681:
			        return new KeyboardButtonUrlAuth();
		        case -802258988:
			        return new InputKeyboardButtonUrlAuth();
		        case -1144565411:
			        return new KeyboardButtonRequestPoll();
		        case 2002815875:
			        return new KeyboardButtonRow();
		        case -1606526075:
			        return new ReplyKeyboardHide();
		        case -200242528:
			        return new ReplyKeyboardForceReply();
		        case 889353612:
			        return new ReplyKeyboardMarkup();
		        case 1218642516:
			        return new ReplyInlineMarkup();
		        case -1148011883:
			        return new MessageEntityUnknown();
		        case -100378723:
			        return new MessageEntityMention();
		        case 1868782349:
			        return new MessageEntityHashtag();
		        case 1827637959:
			        return new MessageEntityBotCommand();
		        case 1859134776:
			        return new MessageEntityUrl();
		        case 1692693954:
			        return new MessageEntityEmail();
		        case -1117713463:
			        return new MessageEntityBold();
		        case -2106619040:
			        return new MessageEntityItalic();
		        case 681706865:
			        return new MessageEntityCode();
		        case 1938967520:
			        return new MessageEntityPre();
		        case 1990644519:
			        return new MessageEntityTextUrl();
		        case 892193368:
			        return new MessageEntityMentionName();
		        case 546203849:
			        return new InputMessageEntityMentionName();
		        case -1687559349:
			        return new MessageEntityPhone();
		        case 1280209983:
			        return new MessageEntityCashtag();
		        case -1672577397:
			        return new MessageEntityUnderline();
		        case -1090087980:
			        return new MessageEntityStrike();
		        case 34469328:
			        return new MessageEntityBlockquote();
		        case 1981704948:
			        return new MessageEntityBankCard();
		        case -292807034:
			        return new InputChannelEmpty();
		        case -1343524562:
			        return new InputChannel();
		        case 707290417:
			        return new InputChannelFromMessage();
		        case 2131196633:
			        return new ResolvedPeer();
		        case 182649427:
			        return new MessageRange();
		        case 1041346555:
			        return new ChannelDifferenceEmpty();
		        case -1531132162:
			        return new ChannelDifferenceTooLong();
		        case 543450958:
			        return new ChannelDifference();
		        case -1798033689:
			        return new ChannelMessagesFilterEmpty();
		        case -847783593:
			        return new ChannelMessagesFilter();
		        case 367766557:
			        return new ChannelParticipant();
		        case -1557620115:
			        return new ChannelParticipantSelf();
		        case 1149094475:
			        return new ChannelParticipantCreator();
		        case -859915345:
			        return new ChannelParticipantAdmin();
		        case 470789295:
			        return new ChannelParticipantBanned();
		        case -1010402965:
			        return new ChannelParticipantLeft();
		        case -566281095:
			        return new ChannelParticipantsRecent();
		        case -1268741783:
			        return new ChannelParticipantsAdmins();
		        case -1548400251:
			        return new ChannelParticipantsKicked();
		        case -1328445861:
			        return new ChannelParticipantsBots();
		        case 338142689:
			        return new ChannelParticipantsBanned();
		        case 106343499:
			        return new ChannelParticipantsSearch();
		        case -1150621555:
			        return new ChannelParticipantsContacts();
		        case -531931925:
			        return new ChannelParticipantsMentions();
		        case -177282392:
			        return new ChannelParticipants();
		        case -266911767:
			        return new ChannelParticipantsNotModified();
		        case -791039645:
			        return new CloudChats.Channels.ChannelParticipant();
		        case 2013922064:
			        return new TermsOfService();
		        case -402498398:
			        return new SavedGifsNotModified();
		        case 772213157:
			        return new SavedGifs();
		        case 864077702:
			        return new InputBotInlineMessageMediaAuto();
		        case 1036876423:
			        return new InputBotInlineMessageText();
		        case -1768777083:
			        return new InputBotInlineMessageMediaGeo();
		        case 1098628881:
			        return new InputBotInlineMessageMediaVenue();
		        case -1494368259:
			        return new InputBotInlineMessageMediaContact();
		        case 1262639204:
			        return new InputBotInlineMessageGame();
		        case -2000710887:
			        return new InputBotInlineResult();
		        case -1462213465:
			        return new InputBotInlineResultPhoto();
		        case -459324:
			        return new InputBotInlineResultDocument();
		        case 1336154098:
			        return new InputBotInlineResultGame();
		        case 1984755728:
			        return new BotInlineMessageMediaAuto();
		        case -1937807902:
			        return new BotInlineMessageText();
		        case 85477117:
			        return new BotInlineMessageMediaGeo();
		        case -1970903652:
			        return new BotInlineMessageMediaVenue();
		        case 416402882:
			        return new BotInlineMessageMediaContact();
		        case 295067450:
			        return new BotInlineResult();
		        case 400266251:
			        return new BotInlineMediaResult();
		        case -1803769784:
			        return new BotResults();
		        case 1571494644:
			        return new ExportedMessageLink();
		        case 1601666510:
			        return new MessageFwdHeader();
		        case 1923290508:
			        return new CodeTypeSms();
		        case 1948046307:
			        return new CodeTypeCall();
		        case 577556219:
			        return new CodeTypeFlashCall();
		        case 1035688326:
			        return new SentCodeTypeApp();
		        case -1073693790:
			        return new SentCodeTypeSms();
		        case 1398007207:
			        return new SentCodeTypeCall();
		        case -1425815847:
			        return new SentCodeTypeFlashCall();
		        case 911761060:
			        return new BotCallbackAnswer();
		        case 649453030:
			        return new MessageEditData();
		        case -1995686519:
			        return new InputBotInlineMessageID();
		        case 1008755359:
			        return new InlineBotSwitchPM();
		        case 863093588:
			        return new PeerDialogs();
		        case -305282981:
			        return new TopPeer();
		        case -1419371685:
			        return new TopPeerCategoryBotsPM();
		        case 344356834:
			        return new TopPeerCategoryBotsInline();
		        case 104314861:
			        return new TopPeerCategoryCorrespondents();
		        case -1122524854:
			        return new TopPeerCategoryGroups();
		        case 371037736:
			        return new TopPeerCategoryChannels();
		        case 511092620:
			        return new TopPeerCategoryPhoneCalls();
		        case -1472172887:
			        return new TopPeerCategoryForwardUsers();
		        case -68239120:
			        return new TopPeerCategoryForwardChats();
		        case -75283823:
			        return new TopPeerCategoryPeers();
		        case -567906571:
			        return new TopPeersNotModified();
		        case 1891070632:
			        return new TopPeers();
		        case -1255369827:
			        return new TopPeersDisabled();
		        case 453805082:
			        return new DraftMessageEmpty();
		        case -40996577:
			        return new DraftMessage();
		        case -958657434:
			        return new FeaturedStickersNotModified();
		        case -1230257343:
			        return new FeaturedStickers();
		        case 186120336:
			        return new RecentStickersNotModified();
		        case 586395571:
			        return new RecentStickers();
		        case 1338747336:
			        return new ArchivedStickers();
		        case 946083368:
			        return new StickerSetInstallResultSuccess();
		        case 904138920:
			        return new StickerSetInstallResultArchive();
		        case 1678812626:
			        return new StickerSetCovered();
		        case 872932635:
			        return new StickerSetMultiCovered();
		        case -1361650766:
			        return new MaskCoords();
		        case 1251549527:
			        return new InputStickeredMediaPhoto();
		        case 70813275:
			        return new InputStickeredMediaDocument();
		        case -1107729093:
			        return new Game();
		        case 53231223:
			        return new InputGameID();
		        case -1020139510:
			        return new InputGameShortName();
		        case 1493171408:
			        return new HighScore();
		        case -1707344487:
			        return new HighScores();
		        case -599948721:
			        return new TextEmpty();
		        case 1950782688:
			        return new TextPlain();
		        case 1730456516:
			        return new TextBold();
		        case -653089380:
			        return new TextItalic();
		        case -1054465340:
			        return new TextUnderline();
		        case -1678197867:
			        return new TextStrike();
		        case 1816074681:
			        return new TextFixed();
		        case 1009288385:
			        return new TextUrl();
		        case -564523562:
			        return new TextEmail();
		        case 2120376535:
			        return new TextConcat();
		        case -311786236:
			        return new TextSubscript();
		        case -939827711:
			        return new TextSuperscript();
		        case 55281185:
			        return new TextMarked();
		        case 483104362:
			        return new TextPhone();
		        case 136105807:
			        return new TextImage();
		        case 894777186:
			        return new TextAnchor();
		        case 324435594:
			        return new PageBlockUnsupported();
		        case 1890305021:
			        return new PageBlockTitle();
		        case -1879401953:
			        return new PageBlockSubtitle();
		        case -1162877472:
			        return new PageBlockAuthorDate();
		        case -1076861716:
			        return new PageBlockHeader();
		        case -248793375:
			        return new PageBlockSubheader();
		        case 1182402406:
			        return new PageBlockParagraph();
		        case -1066346178:
			        return new PageBlockPreformatted();
		        case 1216809369:
			        return new PageBlockFooter();
		        case -618614392:
			        return new PageBlockDivider();
		        case -837994576:
			        return new PageBlockAnchor();
		        case -454524911:
			        return new PageBlockList();
		        case 641563686:
			        return new PageBlockBlockquote();
		        case 1329878739:
			        return new PageBlockPullquote();
		        case 391759200:
			        return new PageBlockPhoto();
		        case 2089805750:
			        return new PageBlockVideo();
		        case 972174080:
			        return new PageBlockCover();
		        case -1468953147:
			        return new PageBlockEmbed();
		        case -229005301:
			        return new PageBlockEmbedPost();
		        case 1705048653:
			        return new PageBlockCollage();
		        case 52401552:
			        return new PageBlockSlideshow();
		        case -283684427:
			        return new PageBlockChannel();
		        case -2143067670:
			        return new PageBlockAudio();
		        case 504660880:
			        return new PageBlockKicker();
		        case -1085412734:
			        return new PageBlockTable();
		        case -1702174239:
			        return new PageBlockOrderedList();
		        case 1987480557:
			        return new PageBlockDetails();
		        case 370236054:
			        return new PageBlockRelatedArticles();
		        case -1538310410:
			        return new PageBlockMap();
		        case -2048646399:
			        return new PhoneCallDiscardReasonMissed();
		        case -527056480:
			        return new PhoneCallDiscardReasonDisconnect();
		        case 1471006352:
			        return new PhoneCallDiscardReasonHangup();
		        case -84416311:
			        return new PhoneCallDiscardReasonBusy();
		        case 2104790276:
			        return new DataJSON();
		        case -886477832:
			        return new LabeledPrice();
		        case -1022713000:
			        return new Invoice();
		        case -368917890:
			        return new PaymentCharge();
		        case 512535275:
			        return new PostAddress();
		        case -1868808300:
			        return new PaymentRequestedInfo();
		        case -842892769:
			        return new PaymentSavedCredentialsCard();
		        case 475467473:
			        return new WebDocument();
		        case -104284986:
			        return new WebDocumentNoProxy();
		        case -1678949555:
			        return new InputWebDocument();
		        case -1036396922:
			        return new InputWebFileLocation();
		        case -1625153079:
			        return new InputWebFileGeoPointLocation();
		        case 568808380:
			        return new WebFile();
		        case 1062645411:
			        return new PaymentForm();
		        case -784000893:
			        return new ValidatedRequestedInfo();
		        case 1314881805:
			        return new PaymentResult();
		        case -666824391:
			        return new PaymentVerificationNeeded();
		        case 1342771681:
			        return new PaymentReceipt();
		        case -74456004:
			        return new SavedInfo();
		        case -1056001329:
			        return new InputPaymentCredentialsSaved();
		        case 873977640:
			        return new InputPaymentCredentials();
		        case 178373535:
			        return new InputPaymentCredentialsApplePay();
		        case -905587442:
			        return new InputPaymentCredentialsAndroidPay();
		        case -614138572:
			        return new TmpPassword();
		        case -1239335713:
			        return new ShippingOption();
		        case -6249322:
			        return new InputStickerSetItem();
		        case 506920429:
			        return new InputPhoneCall();
		        case 1399245077:
			        return new PhoneCallEmpty();
		        case 462375633:
			        return new PhoneCallWaiting();
		        case -2014659757:
			        return new PhoneCallRequested();
		        case -1719909046:
			        return new PhoneCallAccepted();
		        case -2025673089:
			        return new PhoneCall();
		        case 1355435489:
			        return new PhoneCallDiscarded();
		        case -1655957568:
			        return new PhoneConnection();
		        case 1667228533:
			        return new PhoneConnectionWebrtc();
		        case -58224696:
			        return new PhoneCallProtocol();
		        case -326966976:
			        return new CloudChats.Phone.PhoneCall();
		        case -290921362:
			        return new CdnFileReuploadNeeded();
		        case -1449145777:
			        return new CdnFile();
		        case -914167110:
			        return new CdnPublicKey();
		        case 1462101002:
			        return new CdnConfig();
		        case -892239370:
			        return new LangPackString();
		        case 1816636575:
			        return new LangPackStringPluralized();
		        case 695856818:
			        return new LangPackStringDeleted();
		        case -209337866:
			        return new LangPackDifference();
		        case -288727837:
			        return new LangPackLanguage();
		        case -421545947:
			        return new ChannelAdminLogEventActionChangeTitle();
		        case 1427671598:
			        return new ChannelAdminLogEventActionChangeAbout();
		        case 1783299128:
			        return new ChannelAdminLogEventActionChangeUsername();
		        case 1129042607:
			        return new ChannelAdminLogEventActionChangePhoto();
		        case 460916654:
			        return new ChannelAdminLogEventActionToggleInvites();
		        case 648939889:
			        return new ChannelAdminLogEventActionToggleSignatures();
		        case -370660328:
			        return new ChannelAdminLogEventActionUpdatePinned();
		        case 1889215493:
			        return new ChannelAdminLogEventActionEditMessage();
		        case 1121994683:
			        return new ChannelAdminLogEventActionDeleteMessage();
		        case 405815507:
			        return new ChannelAdminLogEventActionParticipantJoin();
		        case -124291086:
			        return new ChannelAdminLogEventActionParticipantLeave();
		        case -484690728:
			        return new ChannelAdminLogEventActionParticipantInvite();
		        case -422036098:
			        return new ChannelAdminLogEventActionParticipantToggleBan();
		        case -714643696:
			        return new ChannelAdminLogEventActionParticipantToggleAdmin();
		        case -1312568665:
			        return new ChannelAdminLogEventActionChangeStickerSet();
		        case 1599903217:
			        return new ChannelAdminLogEventActionTogglePreHistoryHidden();
		        case 771095562:
			        return new ChannelAdminLogEventActionDefaultBannedRights();
		        case -1895328189:
			        return new ChannelAdminLogEventActionStopPoll();
		        case -1569748965:
			        return new ChannelAdminLogEventActionChangeLinkedChat();
		        case 241923758:
			        return new ChannelAdminLogEventActionChangeLocation();
		        case 1401984889:
			        return new ChannelAdminLogEventActionToggleSlowMode();
		        case 995769920:
			        return new ChannelAdminLogEvent();
		        case -309659827:
			        return new AdminLogResults();
		        case -368018716:
			        return new ChannelAdminLogEventsFilter();
		        case 1558266229:
			        return new PopularContact();
		        case -1634752813:
			        return new FavedStickersNotModified();
		        case -209768682:
			        return new FavedStickers();
		        case 1189204285:
			        return new RecentMeUrlUnknown();
		        case -1917045962:
			        return new RecentMeUrlUser();
		        case -1608834311:
			        return new RecentMeUrlChat();
		        case -347535331:
			        return new RecentMeUrlChatInvite();
		        case -1140172836:
			        return new RecentMeUrlStickerSet();
		        case 235081943:
			        return new RecentMeUrls();
		        case 482797855:
			        return new InputSingleMedia();
		        case -892779534:
			        return new WebAuthorization();
		        case -313079300:
			        return new WebAuthorizations();
		        case -1502174430:
			        return new InputMessageID();
		        case -1160215659:
			        return new InputMessageReplyTo();
		        case -2037963464:
			        return new InputMessagePinned();
		        case -1392895362:
			        return new InputMessageCallbackQuery();
		        case -55902537:
			        return new InputDialogPeer();
		        case 1684014375:
			        return new InputDialogPeerFolder();
		        case -445792507:
			        return new DialogPeer();
		        case 1363483106:
			        return new DialogPeerFolder();
		        case 223655517:
			        return new FoundStickerSetsNotModified();
		        case 1359533640:
			        return new FoundStickerSets();
		        case 1648543603:
			        return new FileHash();
		        case 1968737087:
			        return new InputClientProxy();
		        case -483352705:
			        return new TermsOfServiceUpdateEmpty();
		        case 686618977:
			        return new TermsOfServiceUpdate();
		        case 859091184:
			        return new InputSecureFileUploaded();
		        case 1399317950:
			        return new InputSecureFile();
		        case 1679398724:
			        return new SecureFileEmpty();
		        case -534283678:
			        return new SecureFile();
		        case -1964327229:
			        return new SecureData();
		        case 2103482845:
			        return new SecurePlainPhone();
		        case 569137759:
			        return new SecurePlainEmail();
		        case -1658158621:
			        return new SecureValueTypePersonalDetails();
		        case 1034709504:
			        return new SecureValueTypePassport();
		        case 115615172:
			        return new SecureValueTypeDriverLicense();
		        case -1596951477:
			        return new SecureValueTypeIdentityCard();
		        case -1717268701:
			        return new SecureValueTypeInternalPassport();
		        case -874308058:
			        return new SecureValueTypeAddress();
		        case -63531698:
			        return new SecureValueTypeUtilityBill();
		        case -1995211763:
			        return new SecureValueTypeBankStatement();
		        case -1954007928:
			        return new SecureValueTypeRentalAgreement();
		        case -1713143702:
			        return new SecureValueTypePassportRegistration();
		        case -368907213:
			        return new SecureValueTypeTemporaryRegistration();
		        case -1289704741:
			        return new SecureValueTypePhone();
		        case -1908627474:
			        return new SecureValueTypeEmail();
		        case 411017418:
			        return new SecureValue();
		        case -618540889:
			        return new InputSecureValue();
		        case -316748368:
			        return new SecureValueHash();
		        case -391902247:
			        return new SecureValueErrorData();
		        case 12467706:
			        return new SecureValueErrorFrontSide();
		        case -2037765467:
			        return new SecureValueErrorReverseSide();
		        case -449327402:
			        return new SecureValueErrorSelfie();
		        case 2054162547:
			        return new SecureValueErrorFile();
		        case 1717706985:
			        return new SecureValueErrorFiles();
		        case -2036501105:
			        return new SecureValueError();
		        case -1592506512:
			        return new SecureValueErrorTranslationFile();
		        case 878931416:
			        return new SecureValueErrorTranslationFiles();
		        case 871426631:
			        return new SecureCredentialsEncrypted();
		        case -1389486888:
			        return new AuthorizationForm();
		        case -2128640689:
			        return new SentEmailCode();
		        case 1722786150:
			        return new DeepLinkInfoEmpty();
		        case 1783556146:
			        return new DeepLinkInfo();
		        case 289586518:
			        return new SavedPhoneContact();
		        case 1304052993:
			        return new Takeout();
		        case -732254058:
			        return new PasswordKdfAlgoUnknown();
		        case 982592842:
			        return new PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow();
		        case 4883767:
			        return new SecurePasswordKdfAlgoUnknown();
		        case -1141711456:
			        return new SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000();
		        case -2042159726:
			        return new SecurePasswordKdfAlgoSHA512();
		        case 354925740:
			        return new SecureSecretSettings();
		        case -1736378792:
			        return new InputCheckPasswordEmpty();
		        case -763367294:
			        return new InputCheckPasswordSRP();
		        case -2103600678:
			        return new SecureRequiredType();
		        case 41187252:
			        return new SecureRequiredTypeOneOf();
		        case -1078332329:
			        return new PassportConfigNotModified();
		        case -1600596305:
			        return new PassportConfig();
		        case 488313413:
			        return new InputAppEvent();
		        case -1059185703:
			        return new JsonObjectValue();
		        case 1064139624:
			        return new JsonNull();
		        case -952869270:
			        return new JsonBool();
		        case 736157604:
			        return new JsonNumber();
		        case -1222740358:
			        return new JsonString();
		        case -146520221:
			        return new JsonArray();
		        case -1715350371:
			        return new JsonObject();
		        case 878078826:
			        return new PageTableCell();
		        case -524237339:
			        return new PageTableRow();
		        case 1869903447:
			        return new PageCaption();
		        case -1188055347:
			        return new PageListItemText();
		        case 635466748:
			        return new PageListItemBlocks();
		        case 1577484359:
			        return new PageListOrderedItemText();
		        case -1730311882:
			        return new PageListOrderedItemBlocks();
		        case -1282352120:
			        return new PageRelatedArticle();
		        case -1738178803:
			        return new Page();
		        case -1945767479:
			        return new SupportName();
		        case -206688531:
			        return new UserInfoEmpty();
		        case 32192344:
			        return new UserInfo();
		        case 1823064809:
			        return new PollAnswer();
		        case -2032041631:
			        return new Poll();
		        case 997055186:
			        return new PollAnswerVoters();
		        case -1159937629:
			        return new PollResults();
		        case -264117680:
			        return new ChatOnlines();
		        case 1202287072:
			        return new StatsURL();
		        case 1605510357:
			        return new ChatAdminRights();
		        case -1626209256:
			        return new ChatBannedRights();
		        case -433014407:
			        return new InputWallPaper();
		        case 1913199744:
			        return new InputWallPaperSlug();
		        case -2077770836:
			        return new InputWallPaperNoFile();
		        case 471437699:
			        return new WallPapersNotModified();
		        case 1881892265:
			        return new WallPapers();
		        case -557924733:
			        return new CodeSettings();
		        case 84438264:
			        return new WallPaperSettings();
		        case -532532493:
			        return new AutoDownloadSettings();
		        case 1674235686:
			        return new CloudChats.Account.AutoDownloadSettings();
		        case -709641735:
			        return new EmojiKeyword();
		        case 594408994:
			        return new EmojiKeywordDeleted();
		        case 1556570557:
			        return new EmojiKeywordsDifference();
		        case -1519029347:
			        return new EmojiURL();
		        case -1275374751:
			        return new EmojiLanguage();
		        case -1132476723:
			        return new FileLocationToBeDeprecated();
		        case -11252123:
			        return new Folder();
		        case -70073706:
			        return new InputFolderPeer();
		        case -373643672:
			        return new FolderPeer();
		        case -398136321:
			        return new SearchCounter();
		        case -1831650802:
			        return new UrlAuthResultRequest();
		        case -1886646706:
			        return new UrlAuthResultAccepted();
		        case -1445536993:
			        return new UrlAuthResultDefault();
		        case -1078612597:
			        return new ChannelLocationEmpty();
		        case 547062491:
			        return new ChannelLocation();
		        case -901375139:
			        return new PeerLocated();
		        case -118740917:
			        return new PeerSelfLocated();
		        case -797791052:
			        return new RestrictionReason();
		        case 1012306921:
			        return new InputTheme();
		        case -175567375:
			        return new InputThemeSlug();
		        case 42930452:
			        return new Theme();
		        case -199313886:
			        return new ThemesNotModified();
		        case 2137482273:
			        return new Themes();
		        case 1654593920:
			        return new LoginToken();
		        case 110008598:
			        return new LoginTokenMigrateTo();
		        case 957176926:
			        return new LoginTokenSuccess();
		        case 1474462241:
			        return new ContentSettings();
		        case -1456996667:
			        return new InactiveChats();
		        case -1012849566:
			        return new BaseThemeClassic();
		        case -69724536:
			        return new BaseThemeDay();
		        case -1212997976:
			        return new BaseThemeNight();
		        case 1834973166:
			        return new BaseThemeTinted();
		        case 1527845466:
			        return new BaseThemeArctic();
		        case -1118798639:
			        return new InputThemeSettings();
		        case -1676371894:
			        return new ThemeSettings();
		        case 1421174295:
			        return new WebPageAttributeTheme();
		        case -1567730343:
			        return new MessageUserVote();
		        case 909603888:
			        return new MessageUserVoteInputOption();
		        case 244310238:
			        return new MessageUserVoteMultiple();
		        case 136574537:
			        return new VotesList();
		        case -177732982:
			        return new BankCardOpenUrl();
		        case 1042605427:
			        return new BankCardData();
		        case 1949890536:
			        return new DialogFilter();
		        case 2004110666:
			        return new DialogFilterSuggested();
		        case -1237848657:
			        return new StatsDateRangeDays();
		        case -884757282:
			        return new StatsAbsValueAndPrev();
		        case -875679776:
			        return new StatsPercentValue();
		        case 1244130093:
			        return new StatsGraphAsync();
		        case -1092839390:
			        return new StatsGraphError();
		        case -1901828938:
			        return new StatsGraph();
		        case -1387279939:
			        return new MessageInteractionCounters();
		        case -1107852396:
			        return new BroadcastStats();
		        case -1728664459:
			        return new PromoDataEmpty();
		        case -1942390465:
			        return new PromoData();
		        case -399391402:
			        return new VideoSize();
		        case 418631927:
			        return new StatsGroupTopPoster();
		        case 1611985938:
			        return new StatsGroupTopAdmin();
		        case 831924812:
			        return new StatsGroupTopInviter();
		        case -276825834:
			        return new MegagroupStats();
		        case -1096616924:
			        return new GlobalPrivacySettings();
		        case 1107543535:
			        return new CountryCode();
		        case -1014526429:
			        return new Country();
		        case -1815339214:
			        return new CountriesListNotModified();
		        case -2016381538:
			        return new CountriesList();
		        case 1163625789:
			        return new MessageViews();
		        case -1228606141:
			        return new CloudChats.Messages.MessageViews();
		        case -170029155:
			        return new DiscussionMessage();
		        case -1495959709:
			        return new MessageReplyHeader();
		        case 1093204652:
			        return new MessageReplies();
		        case -386039788:
			        return new PeerBlocked();
		        case -1986399595:
			        return new MessageStats();
		        case -878758099:
			        return new InvokeAfterMsg();
		        case 1036301552:
			        return new InvokeAfterMsgs();
		        case -1043505495:
			        return new InitConnection();
		        case -627372787:
			        return new InvokeWithLayer();
		        case -1080796745:
			        return new InvokeWithoutUpdates();
		        case 911373810:
			        return new InvokeWithMessagesRange();
		        case -1398145746:
			        return new InvokeWithTakeout();
		        case -1502141361:
			        return new SendCode();
		        case -2131827673:
			        return new SignUp();
		        case -1126886015:
			        return new SignIn();
		        case 1461180992:
			        return new LogOut();
		        case -1616179942:
			        return new ResetAuthorizations();
		        case -440401971:
			        return new ExportAuthorization();
		        case -470837741:
			        return new ImportAuthorization();
		        case -841733627:
			        return new BindTempAuthKey();
		        case 1738800940:
			        return new ImportBotAuthorization();
		        case -779399914:
			        return new CheckPassword();
		        case -661144474:
			        return new RequestPasswordRecovery();
		        case 1319464594:
			        return new RecoverPassword();
		        case 1056025023:
			        return new ResendCode();
		        case 520357240:
			        return new CancelCode();
		        case -1907842680:
			        return new DropTempAuthKeys();
		        case -1313598185:
			        return new ExportLoginToken();
		        case -1783866140:
			        return new ImportLoginToken();
		        case -392909491:
			        return new AcceptLoginToken();
		        case 1754754159:
			        return new RegisterDevice();
		        case 813089983:
			        return new UnregisterDevice();
		        case -2067899501:
			        return new CloudChats.Account.UpdateNotifySettings();
		        case 313765169:
			        return new GetNotifySettings();
		        case -612493497:
			        return new ResetNotifySettings();
		        case 2018596725:
			        return new UpdateProfile();
		        case 1713919532:
			        return new UpdateStatus();
		        case -1430579357:
			        return new GetWallPapers();
		        case -1374118561:
			        return new ReportPeer();
		        case 655677548:
			        return new CheckUsername();
		        case 1040964988:
			        return new UpdateUsername();
		        case -623130288:
			        return new GetPrivacy();
		        case -906486552:
			        return new SetPrivacy();
		        case 1099779595:
			        return new DeleteAccount();
		        case 150761757:
			        return new GetAccountTTL();
		        case 608323678:
			        return new SetAccountTTL();
		        case -2108208411:
			        return new SendChangePhoneCode();
		        case 1891839707:
			        return new ChangePhone();
		        case 954152242:
			        return new UpdateDeviceLocked();
		        case -484392616:
			        return new GetAuthorizations();
		        case -545786948:
			        return new ResetAuthorization();
		        case 1418342645:
			        return new GetPassword();
		        case -1663767815:
			        return new GetPasswordSettings();
		        case -1516564433:
			        return new UpdatePasswordSettings();
		        case 457157256:
			        return new SendConfirmPhoneCode();
		        case 1596029123:
			        return new ConfirmPhone();
		        case 1151208273:
			        return new GetTmpPassword();
		        case 405695855:
			        return new GetWebAuthorizations();
		        case 755087855:
			        return new ResetWebAuthorization();
		        case 1747789204:
			        return new ResetWebAuthorizations();
		        case -1299661699:
			        return new GetAllSecureValues();
		        case 1936088002:
			        return new GetSecureValue();
		        case -1986010339:
			        return new SaveSecureValue();
		        case -1199522741:
			        return new DeleteSecureValue();
		        case -1200903967:
			        return new GetAuthorizationForm();
		        case -419267436:
			        return new AcceptAuthorization();
		        case -1516022023:
			        return new SendVerifyPhoneCode();
		        case 1305716726:
			        return new VerifyPhone();
		        case 1880182943:
			        return new SendVerifyEmailCode();
		        case -323339813:
			        return new VerifyEmail();
		        case -262453244:
			        return new InitTakeoutSession();
		        case 489050862:
			        return new FinishTakeoutSession();
		        case -1881204448:
			        return new ConfirmPasswordEmail();
		        case 2055154197:
			        return new ResendPasswordEmail();
		        case -1043606090:
			        return new CancelPasswordEmail();
		        case -1626880216:
			        return new GetContactSignUpNotification();
		        case -806076575:
			        return new SetContactSignUpNotification();
		        case 1398240377:
			        return new GetNotifyExceptions();
		        case -57811990:
			        return new GetWallPaper();
		        case -578472351:
			        return new UploadWallPaper();
		        case 1817860919:
			        return new SaveWallPaper();
		        case -18000023:
			        return new InstallWallPaper();
		        case -1153722364:
			        return new ResetWallPapers();
		        case 1457130303:
			        return new GetAutoDownloadSettings();
		        case 1995661875:
			        return new SaveAutoDownloadSettings();
		        case 473805619:
			        return new UploadTheme();
		        case -2077048289:
			        return new CreateTheme();
		        case 1555261397:
			        return new CloudChats.Account.UpdateTheme();
		        case -229175188:
			        return new SaveTheme();
		        case 2061776695:
			        return new InstallTheme();
		        case -1919060949:
			        return new GetTheme();
		        case 676939512:
			        return new GetThemes();
		        case -1250643605:
			        return new SetContentSettings();
		        case -1952756306:
			        return new GetContentSettings();
		        case 1705865692:
			        return new GetMultiWallPapers();
		        case -349483786:
			        return new GetGlobalPrivacySettings();
		        case 517647042:
			        return new SetGlobalPrivacySettings();
		        case 227648840:
			        return new GetUsers();
		        case -902781519:
			        return new GetFullUser();
		        case -1865902923:
			        return new SetSecureValueErrors();
		        case 749357634:
			        return new GetContactIDs();
		        case -995929106:
			        return new GetStatuses();
		        case -1071414113:
			        return new GetContacts();
		        case 746589157:
			        return new ImportContacts();
		        case 157945344:
			        return new DeleteContacts();
		        case 269745566:
			        return new DeleteByPhones();
		        case 1758204945:
			        return new Block();
		        case -1096393392:
			        return new Unblock();
		        case -176409329:
			        return new GetBlocked();
		        case 301470424:
			        return new Search();
		        case -113456221:
			        return new ResolveUsername();
		        case -728224331:
			        return new GetTopPeers();
		        case 451113900:
			        return new ResetTopPeerRating();
		        case -2020263951:
			        return new ResetSaved();
		        case -2098076769:
			        return new GetSaved();
		        case -2062238246:
			        return new ToggleTopPeers();
		        case -386636848:
			        return new AddContact();
		        case -130964977:
			        return new AcceptContact();
		        case -750207932:
			        return new GetLocated();
		        case 698914348:
			        return new BlockFromReplies();
		        case 1673946374:
			        return new GetMessages();
		        case -1594999949:
			        return new GetDialogs();
		        case -591691168:
			        return new GetHistory();
		        case 204812012:
			        return new CloudChats.Messages.Search();
		        case 238054714:
			        return new ReadHistory();
		        case 469850889:
			        return new DeleteHistory();
		        case -443640366:
			        return new DeleteMessages();
		        case 94983360:
			        return new ReceivedMessages();
		        case 1486110434:
			        return new SetTyping();
		        case 1376532592:
			        return new SendMessage();
		        case 881978281:
			        return new SendMedia();
		        case -637606386:
			        return new ForwardMessages();
		        case -820669733:
			        return new ReportSpam();
		        case 913498268:
			        return new GetPeerSettings();
		        case -1115507112:
			        return new Report();
		        case 1013621127:
			        return new GetChats();
		        case 998448230:
			        return new GetFullChat();
		        case -599447467:
			        return new EditChatTitle();
		        case -900957736:
			        return new EditChatPhoto();
		        case -106911223:
			        return new AddChatUser();
		        case -530505962:
			        return new DeleteChatUser();
		        case 164303470:
			        return new CreateChat();
		        case 651135312:
			        return new GetDhConfig();
		        case -162681021:
			        return new RequestEncryption();
		        case 1035731989:
			        return new AcceptEncryption();
		        case -304536635:
			        return new DiscardEncryption();
		        case 2031374829:
			        return new SetEncryptedTyping();
		        case 2135648522:
			        return new ReadEncryptedHistory();
		        case 1157265941:
			        return new SendEncrypted();
		        case 1431914525:
			        return new SendEncryptedFile();
		        case 852769188:
			        return new SendEncryptedService();
		        case 1436924774:
			        return new ReceivedQueue();
		        case 1259113487:
			        return new ReportEncryptedSpam();
		        case 916930423:
			        return new ReadMessageContents();
		        case 71126828:
			        return new GetStickers();
		        case 479598769:
			        return new GetAllStickers();
		        case -1956073268:
			        return new GetWebPagePreview();
		        case 234312524:
			        return new ExportChatInvite();
		        case 1051570619:
			        return new CheckChatInvite();
		        case 1817183516:
			        return new ImportChatInvite();
		        case 639215886:
			        return new GetStickerSet();
		        case -946871200:
			        return new InstallStickerSet();
		        case -110209570:
			        return new UninstallStickerSet();
		        case -421563528:
			        return new StartBot();
		        case 1468322785:
			        return new GetMessagesViews();
		        case -1444503762:
			        return new EditChatAdmin();
		        case 363051235:
			        return new MigrateChat();
		        case 1271290010:
			        return new SearchGlobal();
		        case 2016638777:
			        return new ReorderStickerSets();
		        case 864953444:
			        return new GetDocumentByHash();
		        case -2084618926:
			        return new GetSavedGifs();
		        case 846868683:
			        return new SaveGif();
		        case 1364105629:
			        return new GetInlineBotResults();
		        case -346119674:
			        return new SetInlineBotResults();
		        case 570955184:
			        return new SendInlineBotResult();
		        case -39416522:
			        return new GetMessageEditData();
		        case 1224152952:
			        return new EditMessage();
		        case -2091549254:
			        return new EditInlineBotMessage();
		        case -1824339449:
			        return new GetBotCallbackAnswer();
		        case -712043766:
			        return new SetBotCallbackAnswer();
		        case -462373635:
			        return new GetPeerDialogs();
		        case -1137057461:
			        return new SaveDraft();
		        case 1782549861:
			        return new GetAllDrafts();
		        case 766298703:
			        return new GetFeaturedStickers();
		        case 1527873830:
			        return new ReadFeaturedStickers();
		        case 1587647177:
			        return new GetRecentStickers();
		        case 958863608:
			        return new SaveRecentSticker();
		        case -1986437075:
			        return new ClearRecentStickers();
		        case 1475442322:
			        return new GetArchivedStickers();
		        case 1706608543:
			        return new GetMaskStickers();
		        case -866424884:
			        return new GetAttachedStickers();
		        case -1896289088:
			        return new SetGameScore();
		        case 363700068:
			        return new SetInlineGameScore();
		        case -400399203:
			        return new GetGameHighScores();
		        case 258170395:
			        return new GetInlineGameHighScores();
		        case 218777796:
			        return new GetCommonChats();
		        case -341307408:
			        return new GetAllChats();
		        case 852135825:
			        return new GetWebPage();
		        case -1489903017:
			        return new ToggleDialogPin();
		        case 991616823:
			        return new ReorderPinnedDialogs();
		        case -692498958:
			        return new GetPinnedDialogs();
		        case -436833542:
			        return new SetBotShippingResults();
		        case 163765653:
			        return new SetBotPrecheckoutResults();
		        case 1369162417:
			        return new UploadMedia();
		        case -914493408:
			        return new SendScreenshotNotification();
		        case 567151374:
			        return new GetFavedStickers();
		        case -1174420133:
			        return new FaveSticker();
		        case 1180140658:
			        return new GetUnreadMentions();
		        case 251759059:
			        return new ReadMentions();
		        case -1144759543:
			        return new GetRecentLocations();
		        case -872345397:
			        return new SendMultiMedia();
		        case 1347929239:
			        return new UploadEncryptedFile();
		        case -1028140917:
			        return new SearchStickerSets();
		        case 486505992:
			        return new GetSplitRanges();
		        case -1031349873:
			        return new MarkDialogUnread();
		        case 585256482:
			        return new GetDialogUnreadMarks();
		        case 2119757468:
			        return new ClearAllDrafts();
		        case -760547348:
			        return new UpdatePinnedMessage();
		        case 283795844:
			        return new SendVote();
		        case 1941660731:
			        return new GetPollResults();
		        case 1848369232:
			        return new GetOnlines();
		        case -2127811866:
			        return new GetStatsURL();
		        case -554301545:
			        return new EditChatAbout();
		        case -1517917375:
			        return new EditChatDefaultBannedRights();
		        case 899735650:
			        return new GetEmojiKeywords();
		        case 352892591:
			        return new GetEmojiKeywordsDifference();
		        case 1318675378:
			        return new GetEmojiKeywordsLanguages();
		        case -709817306:
			        return new GetEmojiURL();
		        case 1932455680:
			        return new GetSearchCounters();
		        case -482388461:
			        return new RequestUrlAuth();
		        case -148247912:
			        return new AcceptUrlAuth();
		        case 1336717624:
			        return new HidePeerSettingsBar();
		        case -490575781:
			        return new GetScheduledHistory();
		        case -1111817116:
			        return new GetScheduledMessages();
		        case -1120369398:
			        return new SendScheduledMessages();
		        case 1504586518:
			        return new DeleteScheduledMessages();
		        case -1200736242:
			        return new GetPollVotes();
		        case -1257951254:
			        return new ToggleStickerSets();
		        case -241247891:
			        return new GetDialogFilters();
		        case -1566780372:
			        return new GetSuggestedDialogFilters();
		        case 450142282:
			        return new CloudChats.Messages.UpdateDialogFilter();
		        case -983318044:
			        return new UpdateDialogFiltersOrder();
		        case 1608974939:
			        return new GetOldFeaturedStickers();
		        case 615875002:
			        return new GetReplies();
		        case 1147761405:
			        return new GetDiscussionMessage();
		        case -147740172:
			        return new ReadDiscussion();
		        case -265962357:
			        return new UnpinAllMessages();
		        case -304838614:
			        return new GetState();
		        case 630429265:
			        return new GetDifference();
		        case 51854712:
			        return new GetChannelDifference();
		        case 1926525996:
			        return new UpdateProfilePhoto();
		        case -1980559511:
			        return new UploadProfilePhoto();
		        case -2016444625:
			        return new DeletePhotos();
		        case -1848823128:
			        return new GetUserPhotos();
		        case -1291540959:
			        return new SaveFilePart();
		        case -1319462148:
			        return new GetFile();
		        case -562337987:
			        return new SaveBigFilePart();
		        case 619086221:
			        return new GetWebFile();
		        case 536919235:
			        return new GetCdnFile();
		        case -1691921240:
			        return new ReuploadCdnFile();
		        case 1302676017:
			        return new GetCdnFileHashes();
		        case -956147407:
			        return new GetFileHashes();
		        case -990308245:
			        return new GetConfig();
		        case 531836966:
			        return new GetNearestDc();
		        case 1378703997:
			        return new GetAppUpdate();
		        case 1295590211:
			        return new GetInviteText();
		        case -1663104819:
			        return new GetSupport();
		        case -1877938321:
			        return new GetAppChangelog();
		        case -333262899:
			        return new SetBotUpdatesStatus();
		        case 1375900482:
			        return new GetCdnConfig();
		        case 1036054804:
			        return new GetRecentMeUrls();
		        case 749019089:
			        return new GetTermsOfServiceUpdate();
		        case -294455398:
			        return new AcceptTermsOfService();
		        case 1072547679:
			        return new GetDeepLinkInfo();
		        case -1735311088:
			        return new GetAppConfig();
		        case 1862465352:
			        return new SaveAppLog();
		        case -966677240:
			        return new GetPassportConfig();
		        case -748624084:
			        return new GetSupportName();
		        case 59377875:
			        return new GetUserInfo();
		        case 1723407216:
			        return new EditUserInfo();
		        case -1063816159:
			        return new GetPromoData();
		        case 505748629:
			        return new HidePromoData();
		        case 125807007:
			        return new DismissSuggestion();
		        case 1935116200:
			        return new GetCountriesList();
		        case -871347913:
			        return new CloudChats.Channels.ReadHistory();
		        case -2067661490:
			        return new CloudChats.Channels.DeleteMessages();
		        case -787622117:
			        return new DeleteUserHistory();
		        case -32999408:
			        return new CloudChats.Channels.ReportSpam();
		        case -1383294429:
			        return new CloudChats.Channels.GetMessages();
		        case 306054633:
			        return new GetParticipants();
		        case 1416484774:
			        return new GetParticipant();
		        case 176122811:
			        return new GetChannels();
		        case 141781513:
			        return new GetFullChannel();
		        case 1029681423:
			        return new CreateChannel();
		        case -751007486:
			        return new EditAdmin();
		        case 1450044624:
			        return new EditTitle();
		        case -248621111:
			        return new EditPhoto();
		        case 283557164:
			        return new CloudChats.Channels.CheckUsername();
		        case 890549214:
			        return new CloudChats.Channels.UpdateUsername();
		        case 615851205:
			        return new JoinChannel();
		        case -130635115:
			        return new LeaveChannel();
		        case 429865580:
			        return new InviteToChannel();
		        case -1072619549:
			        return new DeleteChannel();
		        case -432034325:
			        return new ExportMessageLink();
		        case 527021574:
			        return new ToggleSignatures();
		        case -122669393:
			        return new GetAdminedPublicChannels();
		        case 1920559378:
			        return new EditBanned();
		        case 870184064:
			        return new GetAdminLog();
		        case -359881479:
			        return new SetStickers();
		        case -357180360:
			        return new CloudChats.Channels.ReadMessageContents();
		        case -1355375294:
			        return new CloudChats.Channels.DeleteHistory();
		        case -356796084:
			        return new TogglePreHistoryHidden();
		        case -2092831552:
			        return new GetLeftChannels();
		        case -170208392:
			        return new GetGroupsForDiscussion();
		        case 1079520178:
			        return new SetDiscussionGroup();
		        case -1892102881:
			        return new EditCreator();
		        case 1491484525:
			        return new EditLocation();
		        case -304832784:
			        return new ToggleSlowMode();
		        case 300429806:
			        return new GetInactiveChannels();
		        case -1440257555:
			        return new SendCustomRequest();
		        case -434028723:
			        return new AnswerWebhookJSONQuery();
		        case -2141370634:
			        return new SetBotCommands();
		        case -1712285883:
			        return new GetPaymentForm();
		        case -1601001088:
			        return new GetPaymentReceipt();
		        case 1997180532:
			        return new ValidateRequestedInfo();
		        case 730364339:
			        return new SendPaymentForm();
		        case 578650699:
			        return new GetSavedInfo();
		        case -667062079:
			        return new ClearSavedInfo();
		        case 779736953:
			        return new GetBankCardData();
		        case -251435136:
			        return new CreateStickerSet();
		        case -143257775:
			        return new RemoveStickerFromSet();
		        case -4795190:
			        return new ChangeStickerPosition();
		        case -2041315650:
			        return new AddStickerToSet();
		        case -1707717072:
			        return new SetStickerSetThumb();
		        case 1430593449:
			        return new GetCallConfig();
		        case 1124046573:
			        return new RequestCall();
		        case 1003664544:
			        return new AcceptCall();
		        case 788404002:
			        return new ConfirmCall();
		        case 399855457:
			        return new ReceivedCall();
		        case -1295269440:
			        return new DiscardCall();
		        case 1508562471:
			        return new SetCallRating();
		        case 662363518:
			        return new SaveCallDebug();
		        case -8744061:
			        return new SendSignalingData();
		        case -219008246:
			        return new GetLangPack();
		        case -269862909:
			        return new GetStrings();
		        case -845657435:
			        return new CloudChats.Langpack.GetDifference();
		        case 1120311183:
			        return new GetLanguages();
		        case 1784243458:
			        return new GetLanguage();
		        case 1749536939:
			        return new EditPeerFolders();
		        case 472471681:
			        return new DeleteFolder();
		        case -1421720550:
			        return new GetBroadcastStats();
		        case 1646092192:
			        return new LoadAsyncGraph();
		        case -589330937:
			        return new GetMegagroupStats();
		        case 1445996571:
			        return new GetMessagePublicForwards();
		        case -1226791947:
			        return new GetMessageStats();
		        case 85337187:
			        return new ResPQ();
		        case -2083955988:
			        return new PQInnerData();
		        case 1013613780:
			        return new PQInnerDataTemp();
		        case 2043348061:
			        return new ServerDHParamsFail();
		        case -790100132:
			        return new ServerDHParamsOk();
		        case -1249309254:
			        return new ServerDHInnerData();
		        case 1715713620:
			        return new ClientDHInnerData();
		        case 1003222836:
			        return new DhGenOk();
		        case 1188831161:
			        return new DhGenRetry();
		        case -1499615742:
			        return new DhGenFail();
		        case -212046591:
			        return new RpcResult();
		        case 558156313:
			        return new RpcError();
		        case 1579864942:
			        return new RpcAnswerUnknown();
		        case -847714938:
			        return new RpcAnswerDroppedRunning();
		        case -1539647305:
			        return new RpcAnswerDropped();
		        case 155834844:
			        return new FutureSalt();
		        case -1370486635:
			        return new FutureSalts();
		        case 880243653:
			        return new Pong();
		        case -501201412:
			        return new DestroySessionOk();
		        case 1658015945:
			        return new DestroySessionNone();
		        case -1631450872:
			        return new NewSessionCreated();
		        case 1945237724:
			        return new MsgContainer();
		        case -530561358:
			        return new MsgCopy();
		        case 812830625:
			        return new GzipPacked();
		        case 1658238041:
			        return new MsgsAck();
		        case -1477445615:
			        return new BadMsgNotification();
		        case -307542917:
			        return new BadServerSalt();
		        case 2105940488:
			        return new MsgResendReq();
		        case -630588590:
			        return new MsgsStateReq();
		        case 81704317:
			        return new MsgsStateInfo();
		        case -1933520591:
			        return new MsgsAllInfo();
		        case 661470918:
			        return new MsgDetailedInfo();
		        case -2137147681:
			        return new MsgNewDetailedInfo();
		        case 1973679973:
			        return new BindAuthKeyInner();
		        case 1615239032:
			        return new ReqPq();
		        case -1099002127:
			        return new ReqPqMulti();
		        case -686627650:
			        return new ReqDHParams();
		        case -184262881:
			        return new SetClientDHParams();
		        case 1491380032:
			        return new RpcDropAnswer();
		        case -1188971260:
			        return new GetFutureSalts();
		        case 2059302892:
			        return new Ping();
		        case -213746804:
			        return new PingDelayDisconnect();
		        case -414113498:
			        return new DestroySession();
		        case -1835453025:
			        return new HttpWait();
	        }

            
            return null;
        }    
    }
}
