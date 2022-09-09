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
using System.Collections.Generic;
using System.Text;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public override IObject? ResolveConstructorId(int constructorId)
        {
            if (InternalResolveConstructorId(constructorId, out var obj))
            {
                return obj;
            }

            switch (constructorId)
            {
                case 1407104707:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromFeaturedStickers();
                case -563478793:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromWallPaper();
                case -518348839:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromMessage();
                case 1958493133:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromPeerFull();
                case 1774404363:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromPeerPhotos();
                case -1975539021:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromOwnPhotos();
                case -2056114134:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromAppUpdate();
                case 2137406768:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromGetStickers();
                case 1974040286:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromWebPage();
                case 834316031:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromChatInvite();
                case -1374352403:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromSavedGifs();
                case -280317801:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromStickerSet();
                case 484237748:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromRecentStickers();
                case -254794908:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromGame();
                case 1109046438:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromAdminLog();
                case -2133906447:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromSavedStickers();
                case 1124050819:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromTheme();
                case 497967702:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromAvailableReactions();
                case -498360523:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromAttachMenu();
                case -255726409:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromRingtones();
                case -879560365:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromPremium();
                case -785757945:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromRecentMeUrl();
                case -1274139886:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromSponsoredMessage();
                case -1692777169:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextFromArchivedStickers();
                case 588158055:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextUnrecoverable();
                case -2007996210:
                    return new CatraProto.Client.TL.Schemas.FileContexts.ContextUnknown();
                case -994444869:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Error();
                case 2134579434:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerEmpty();
                case 2107670217:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerSelf();
                case 900291769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChat();
                case -571955892:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerUser();
                case 666680316:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChannel();
                case -1468331492:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerUserFromMessage();
                case -1121318848:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerChannelFromMessage();
                case -1182234929:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUserEmpty();
                case -138301121:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUserSelf();
                case -233744186:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputUser();
                case 497305826:
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
                case 860303448:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaDocument();
                case -1052959727:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaVenue();
                case -440664550:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaPhotoExternal();
                case -78455655:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaDocumentExternal();
                case -750828557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputMediaGame();
                case -646342540:
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
                case 925204121:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerPhotoFileLocation();
                case -1652231205:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetThumb();
                case 93890858:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallStream();
                case 1498486562:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerUser();
                case 918946202:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerChat();
                case -1566230754:
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
                case -742634630:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserEmpty();
                case 1073147056:
                    return new CatraProto.Client.TL.Schemas.CloudChats.User();
                case 1326562017:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoEmpty();
                case -2100168954:
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
                case 693512293:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatEmpty();
                case 1103884886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Chat();
                case 1704108455:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatForbidden();
                case -2107528095:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channel();
                case 399807445:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelForbidden();
                case -779165146:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatFull();
                case -362240487:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelFull();
                case -1070776313:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipant();
                case -462696732:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantCreator();
                case -1600962725:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantAdmin();
                case -2023500831:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsForbidden();
                case 1018991608:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatParticipants();
                case 935395612:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoEmpty();
                case 476978193:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatPhoto();
                case -1868117372:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEmpty();
                case 940666592:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Message();
                case 721967202:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageService();
                case 1038967584:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaEmpty();
                case 1766936791:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaPhoto();
                case 1457575028:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageMediaGeo();
                case 1882335561:
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
                case -1119368275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatCreate();
                case -1247687078:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditTitle();
                case 2144015272:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatEditPhoto();
                case -1780220945:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatDeletePhoto();
                case 365886720:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatAddUser();
                case -1539362612:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatDeleteUser();
                case 51520707:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatJoinedByLink();
                case -1781355374:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChannelCreate();
                case -519864430:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatMigrateTo();
                case -365344535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChannelMigrateFrom();
                case -1799538451:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPinMessage();
                case -1615153660:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionHistoryClear();
                case -1834538890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionGameScore();
                case -1892568281:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionPaymentSentMe();
                case -1776926890:
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
                case 2047704898:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionGroupCall();
                case 1345295095:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionInviteToGroupCall();
                case -1441072131:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionSetMessagesTTL();
                case -1281329567:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionGroupCallScheduled();
                case -1434950843:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionSetChatTheme();
                case -339958837:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionChatJoinedByRequest();
                case 1205698681:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionWebViewDataSentMe();
                case -1262252875:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageActionWebViewDataSent();
                case -1460809483:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Dialog();
                case 1908216652:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFolder();
                case 590459437:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoEmpty();
                case -82216347:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photo();
                case 236446268:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeEmpty();
                case 1976012384:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSize();
                case 35527382:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoCachedSize();
                case -525288402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoStrippedSize();
                case -96535659:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeProgressive();
                case -668906175:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhotoPathSize();
                case 286776671:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GeoPointEmpty();
                case -1297942941:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GeoPoint();
                case 1577067778:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCode();
                case 872119224:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization();
                case 1148485274:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationSignUpRequired();
                case -1271602504:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorization();
                case -1195615476:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeer();
                case 423314455:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyUsers();
                case 1251338318:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyChats();
                case -1311015810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputNotifyBroadcasts();
                case -551616469:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettings();
                case -1472527322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettings();
                case -1525149427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerSettings();
                case -1539849235:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaper();
                case -528465642:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaperNoFile();
                case 1490799288:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonSpam();
                case 505595789:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonViolence();
                case 777640226:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonPornography();
                case -1376497949:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonChildAbuse();
                case -1041980751:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonOther();
                case -1685456582:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonCopyright();
                case -606798099:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonGeoIrrelevant();
                case -170010905:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonFake();
                case 177124030:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonIllegalDrugs();
                case -1631091139:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputReportReasonPersonalDetails();
                case -1938625919:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UserFull();
                case 341499403:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contact();
                case -1052885936:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ImportedContact();
                case 383348795:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ContactStatus();
                case -1219778094:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsNotModified();
                case -353862078:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ApiContacts();
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
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ApiMessages();
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
                case -1071741569:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserTyping();
                case -2092401936:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatUserTyping();
                case 125178264:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipants();
                case -440534818:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserStatus();
                case -1007549728:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserName();
                case -232290676:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhoto();
                case 314359194:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewEncryptedMessage();
                case 386986326:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryptedChatTyping();
                case -1264392051:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryption();
                case 956179895:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEncryptedMessagesRead();
                case 1037718609:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdd();
                case -483443337:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantDelete();
                case -1906403213:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDcOptions();
                case -1094555409:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNotifySettings();
                case -337352679:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateServiceNotification();
                case -298113238:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePrivacy();
                case 88680979:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateUserPhone();
                case -1667805217:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryInbox();
                case 791617983:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadHistoryOutbox();
                case 2139689491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateWebPage();
                case 1757493555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadMessagesContents();
                case 277713951:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelTooLong();
                case 1666927625:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannel();
                case 1656358105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewChannelMessage();
                case -1842450928:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelInbox();
                case -1020437742:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDeleteChannelMessages();
                case -232346616:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageViews();
                case -674602590:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipantAdmin();
                case 1753886890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateNewStickerSet();
                case 196268545:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateStickerSetsOrder();
                case 1135492588:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateStickerSets();
                case -1821035490:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateSavedGifs();
                case 1232025500:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineQuery();
                case 317794823:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotInlineSend();
                case 457133559:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEditChannelMessage();
                case -1177566067:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCallbackQuery();
                case -469536605:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateEditMessage();
                case 1763610706:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateInlineBotCallbackQuery();
                case -1218471511:
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
                case 791390623:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelWebPage();
                case 1852826908:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogPinned();
                case -99664734:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedDialogs();
                case -2095595325:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotWebhookJSON();
                case -1684914010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotWebhookJSONQuery();
                case -1246823043:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotShippingQuery();
                case -1934976362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotPrecheckoutQuery();
                case -1425052898:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePhoneCall();
                case 1180041828:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateLangPackTooLong();
                case 1442983757:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateLangPack();
                case -451831443:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateFavedStickers();
                case 1153291573:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelReadMessagesContents();
                case 1887741886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateContactsReset();
                case -1304443240:
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
                case 274961865:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateMessagePollVote();
                case 654302845:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilter();
                case -1512627963:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilterOrder();
                case 889491791:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateDialogFilters();
                case 643940105:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePhoneCallSignalingData();
                case -761649164:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelMessageForwards();
                case -693004986:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionInbox();
                case 1767677564:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateReadChannelDiscussionOutbox();
                case 610945826:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerBlocked();
                case -1937192669:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelUserTyping();
                case -309990731:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedMessages();
                case 1538885128:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePinnedChannelMessages();
                case -124097970:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChat();
                case -219423922:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateGroupCallParticipants();
                case 347227392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateGroupCall();
                case -1147422299:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePeerHistoryTTL();
                case -796432838:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChatParticipant();
                case -1738720581:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateChannelParticipant();
                case -997782967:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotStopped();
                case 192428418:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateGroupCallConnection();
                case 1299263278:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotCommands();
                case 1885586395:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatePendingJoinRequests();
                case 299870598:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotChatInviteRequester();
                case 357013699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateMessageReactions();
                case 397910539:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateAttachMenuBots();
                case 361936797:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateWebViewResultSent();
                case 347625491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateBotMenuButton();
                case 1960361625:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateSavedRingtones();
                case 8703322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateTranscribedAudio();
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
                case 826001400:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortMessage();
                case 1299050149:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortChatMessage();
                case 2027216577:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShort();
                case 1918567619:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdatesCombined();
                case 1957577280:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ApiUpdates();
                case -1877614335:
                    return new CatraProto.Client.TL.Schemas.CloudChats.UpdateShortSentMessage();
                case -1916114267:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Photos.ApiPhotos();
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
                case -860107216:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdate();
                case -1000708810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.NoAppUpdate();
                case 415997816:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.InviteText();
                case -1417756512:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatEmpty();
                case 1722964307:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatWaiting();
                case 1223809356:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatRequested();
                case 1643173063:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChat();
                case 505183301:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatDiscarded();
                case -247351839:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChat();
                case -1038136962:
                    return new CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileEmpty();
                case -1476358952:
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
                case -1881881384:
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
                case -651419003:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SpeakingInGroupCallAction();
                case -606432698:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageHistoryImportAction();
                case -1336228175:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageChooseStickerAction();
                case 630664139:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageEmojiInteraction();
                case -1234857938:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SendMessageEmojiInteractionSeen();
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
                case -2079962673:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueAllowChatParticipants();
                case -380694650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyValueDisallowChatParticipants();
                case -123988:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowContacts();
                case 1698855810:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowAll();
                case -1198497870:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowUsers();
                case -125240806:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowContacts();
                case -1955338397:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowAll();
                case -463335103:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueDisallowUsers();
                case 1796427406:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PrivacyValueAllowChatParticipants();
                case 1103656293:
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
                case 816245886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Stickers();
                case 313694676:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerPack();
                case -395967805:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersNotModified();
                case -843329861:
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
                case 1275039392:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Authorizations();
                case 408623183:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.Password();
                case -1705233435:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettings();
                case -1036572727:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettings();
                case 326715557:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecovery();
                case -1551583367:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessage();
                case 179611673:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteExported();
                case -317687113:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInvitePublicJoinRequests();
                case 1516793212:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteAlready();
                case 806110401:
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
                case 215889721:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetAnimatedEmojiAnimations();
                case -673242758:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StickerSet();
                case -1240849242:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSet();
                case -738646805:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetNotModified();
                case -1032140601:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommand();
                case -1892676777:
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
                case -376962181:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputKeyboardButtonUserProfile();
                case 814112961:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonUserProfile();
                case 326529584:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonWebView();
                case -1598009252:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonSimpleWebView();
                case 2002815875:
                    return new CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRow();
                case -1606526075:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyKeyboardHide();
                case -2035021048:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReplyKeyboardForceReply();
                case -2049074735:
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
                case -595914432:
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
                case 852137487:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageEntitySpoiler();
                case -292807034:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChannelEmpty();
                case -212145112:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputChannel();
                case 1536380829:
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
                case -1072953408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipant();
                case 900251559:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantSelf();
                case 803602899:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantCreator();
                case 885242707:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantAdmin();
                case 1844969806:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBanned();
                case 453242886:
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
                case -1699676497:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipants();
                case -266911767:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsNotModified();
                case -541588713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipant();
                case 2013922064:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfService();
                case -402498398:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsNotModified();
                case -2069878259:
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
                case -672693723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageMediaInvoice();
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
                case 894081801:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageMediaInvoice();
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
                case -702884114:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeMissedCall();
                case 1035688326:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeApp();
                case -1073693790:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeSms();
                case 1398007207:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeCall();
                case -1425815847:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeFlashCall();
                case -2113903484:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeMissedCall();
                case 911761060:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswer();
                case 649453030:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditData();
                case -1995686519:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageID();
                case -1227287081:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageID64();
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
                case -1103615738:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickers();
                case 186120336:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersNotModified();
                case -1999405994:
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
                case 1940093419:
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
                case 1048946971:
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
                case -1340916937:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentForm();
                case -784000893:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfo();
                case 1314881805:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResult();
                case -666824391:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentVerificationNeeded();
                case 1891958275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceipt();
                case -74456004:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfo();
                case -1056001329:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsSaved();
                case 873977640:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentials();
                case 178373535:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsApplePay();
                case -1966921727:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsGooglePay();
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
                case -987599081:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallWaiting();
                case 347139340:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallRequested();
                case 912311057:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallAccepted();
                case -1770029977:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCall();
                case 1355435489:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscarded();
                case -1665063993:
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
                case 84703944:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeLinkedChat();
                case 241923758:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeLocation();
                case 1401984889:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleSlowMode();
                case 589338437:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionStartGroupCall();
                case -610299584:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionDiscardGroupCall();
                case -115071790:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantMute();
                case -431740480:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantUnmute();
                case 1456906823:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleGroupCallSetting();
                case 1557846647:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantJoinByInvite();
                case 1515256996:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionExportedInviteDelete();
                case 1091179342:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionExportedInviteRevoke();
                case -384910503:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionExportedInviteEdit();
                case 1048537159:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantVolume();
                case 1855199800:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeHistoryTTL();
                case -1347021750:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionParticipantJoinByRequest();
                case -886388890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionToggleNoForwards();
                case 663693416:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionSendMessage();
                case -1661470870:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionChangeAvailableReactions();
                case 531458253:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEvent();
                case -309659827:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResults();
                case -368018716:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilter();
                case 1558266229:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PopularContact();
                case -1634752813:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersNotModified();
                case 750063767:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickers();
                case 1189204285:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlUnknown();
                case -1188296222:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlUser();
                case -1294306862:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlChat();
                case -347535331:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlChatInvite();
                case -1140172836:
                    return new CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlStickerSet();
                case 235081943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrls();
                case 482797855:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputSingleMedia();
                case -1493633966:
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
                case -1963942446:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSets();
                case -207944868:
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
                case 2097791614:
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
                case -591909213:
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
                case -1770371538:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperNoFile();
                case 471437699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersNotModified();
                case -842824308:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapers();
                case -1973130814:
                    return new CatraProto.Client.TL.Schemas.CloudChats.CodeSettings();
                case 499236004:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettings();
                case -1896171181:
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
                case -1609668650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Theme();
                case -199313886:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesNotModified();
                case -1707242387:
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
                case -1881255857:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettings();
                case -94849324:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ThemeSettings();
                case 1421174295:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeTheme();
                case 886196148:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVote();
                case 1017491692:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteInputOption();
                case -1973033641:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteMultiple();
                case 136574537:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesList();
                case -177732982:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrl();
                case 1042605427:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardData();
                case 1949890536:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFilter();
                case 909284270:
                    return new CatraProto.Client.TL.Schemas.CloudChats.DialogFilterDefault();
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
                case -567037804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.VideoSize();
                case -1660637285:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPoster();
                case -682079097:
                    return new CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdmin();
                case 1398765469:
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
                case -1506535550:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessage();
                case -1495959709:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeader();
                case -2083123262:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageReplies();
                case -386039788:
                    return new CatraProto.Client.TL.Schemas.CloudChats.PeerBlocked();
                case -1986399595:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStats();
                case 2004925620:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCallDiscarded();
                case -711498484:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCall();
                case -659913713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputGroupCall();
                case -341428482:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipant();
                case -1636664659:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCall();
                case -193506890:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipants();
                case 813821341:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeSameBotPM();
                case -2093215828:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypePM();
                case -681130742:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeChat();
                case 1589952067:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeMegagroup();
                case 1664413338:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBroadcast();
                case 375566091:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImport();
                case 1578088377:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsed();
                case -275956116:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessages();
                case -1940201511:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporter();
                case -1111085620:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvites();
                case 410107472:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvite();
                case 572915951:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteReplaced();
                case -2118733814:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImporters();
                case -219353309:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvites();
                case -1231326505:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvites();
                case -1571952873:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeer();
                case -1343921601:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeers();
                case 541839704:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInvite();
                case -592373577:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroup();
                case 1735736008:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideo();
                case -2046910401:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortName();
                case 795652779:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeDefault();
                case 1011811544:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeUsers();
                case 1877059713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeChats();
                case -1180016534:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeChatAdmins();
                case -610432643:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopePeer();
                case 1071145937:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopePeerAdmins();
                case 169026035:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopePeerUser();
                case -478701471:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordFailedWait();
                case -370148227:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordRequestedWait();
                case -383330754:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordOk();
                case 981691896:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SponsoredMessage();
                case 1705297877:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessages();
                case -911191137:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriod();
                case 343859772:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendar();
                case 2137295719:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SearchResultPosition();
                case 1404185519:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositions();
                case -2091463255:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeers();
                case 997004590:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.UserFull();
                case 1753266509:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettings();
                case -1012759713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOut();
                case 1873957073:
                    return new CatraProto.Client.TL.Schemas.CloudChats.ReactionCount();
                case 1328256121:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessageReactions();
                case 834488621:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsList();
                case -1065882623:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AvailableReaction();
                case -1626924713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsNotModified();
                case 1989032621:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactions();
                case 1741309751:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslateNoResult();
                case -1575684144:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslateResultText();
                case 1370914559:
                    return new CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReaction();
                case -2132064081:
                    return new CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannel();
                case -790330702:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamChannels();
                case 767505458:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrl();
                case 1165423600:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColor();
                case -1297663893:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIcon();
                case -928371502:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBot();
                case -237467044:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsNotModified();
                case 1011024320:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBots();
                case -1816172929:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBot();
                case 202659196:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebViewResultUrl();
                case -2010155333:
                    return new CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultUrl();
                case 211046684:
                    return new CatraProto.Client.TL.Schemas.CloudChats.WebViewMessageSent();
                case 1966318984:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonDefault();
                case 1113113093:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonCommands();
                case -944407322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.BotMenuButton();
                case -67704655:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtonesNotModified();
                case -1041683259:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtones();
                case -1746354498:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundDefault();
                case 1863070943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundNone();
                case -2096391452:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundLocal();
                case -9666487:
                    return new CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundRingtone();
                case -1222230163:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtone();
                case 523271863:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneConverted();
                case 2104224014:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeSameBotPM();
                case -1020528102:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBotPM();
                case -247016673:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypePM();
                case 84480319:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeChat();
                case 2080104188:
                    return new CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBroadcast();
                case -977967015:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceMessage();
                case -1020867857:
                    return new CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceSlug();
                case -1362048039:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ExportedInvoice();
                case -1821037486:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudio();
                case -1974518743:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromo();
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
                case 1047706137:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.LogOut();
                case -1616179942:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResetAuthorizations();
                case -440401971:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportAuthorization();
                case -1518699091:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportAuthorization();
                case -841733627:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.BindTempAuthKey();
                case 1738800940:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportBotAuthorization();
                case -779399914:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckPassword();
                case -661144474:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.RequestPasswordRecovery();
                case 923364464:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.RecoverPassword();
                case 1056025023:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResendCode();
                case 520357240:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CancelCode();
                case -1907842680:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.DropTempAuthKeys();
                case -1210022402:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportLoginToken();
                case -1783866140:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportLoginToken();
                case -392909491:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.AcceptLoginToken();
                case 221691769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckRecoveryPassword();
                case -326762118:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.RegisterDevice();
                case 1779249670:
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
                case 127302966:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPapers();
                case -977650298:
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
                case -1456907910:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizationForm();
                case -202552205:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.AcceptAuthorization();
                case -1516022023:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyPhoneCode();
                case 1305716726:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyPhone();
                case 1880182943:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyEmailCode();
                case -323339813:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyEmail();
                case -1896617296:
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
                case 1697530880:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.CreateTheme();
                case 737414348:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme();
                case -229175188:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveTheme();
                case -953697477:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallTheme();
                case -1919060949:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTheme();
                case 1913054296:
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
                case -91437323:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ReportProfilePhoto();
                case -1828139493:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPassword();
                case 1284770294:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.DeclinePasswordReset();
                case -700916087:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetChatThemes();
                case -1081501024:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SetAuthorizationTTL();
                case 1089766498:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.ChangeAuthorizationSettings();
                case -510647672:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.GetSavedRingtones();
                case 1038768899:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveRingtone();
                case -2095414366:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadRingtone();
                case 227648840:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.GetUsers();
                case -1240508136:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.GetFullUser();
                case -1865902923:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Users.SetSecureValueErrors();
                case 2061264541:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetContactIDs();
                case -995929106:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetStatuses();
                case 1574346258:
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
                case -1758168906:
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
                case -1963375804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvePhone();
                case 1673946374:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessages();
                case -1594569905:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogs();
                case 1143203525:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetHistory();
                case -1593989278:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Search();
                case 238054714:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory();
                case -1332768214:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory();
                case -443640366:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteMessages();
                case 94983360:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedMessages();
                case 1486110434:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetTyping();
                case 228423076:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMessage();
                case -497026848:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMedia();
                case -869258997:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages();
                case -820669733:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam();
                case -270948702:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerSettings();
                case -1991005362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.Report();
                case 1240027791:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChats();
                case -1364194508:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFullChat();
                case 1937260541:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatTitle();
                case 903730804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatPhoto();
                case -230206493:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AddChatUser();
                case -1575461717:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChatUser();
                case 164303470:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CreateChat();
                case 651135312:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDhConfig();
                case -162681021:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestEncryption();
                case 1035731989:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptEncryption();
                case -208425312:
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
                case -710552671:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers();
                case -1197432408:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllStickers();
                case -1956073268:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPagePreview();
                case -1607670315:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportChatInvite();
                case 1051570619:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckChatInvite();
                case 1817183516:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ImportChatInvite();
                case -928977804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickerSet();
                case -946871200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.InstallStickerSet();
                case -110209570:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UninstallStickerSet();
                case -421563528:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot();
                case 1468322785:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesViews();
                case -1470377534:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAdmin();
                case -1568189671:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.MigrateChat();
                case 1271290010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchGlobal();
                case 2016638777:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderStickerSets();
                case -1309538785:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDocumentByHash();
                case 1559270965:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSavedGifs();
                case 846868683:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveGif();
                case 1364105629:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineBotResults();
                case -346119674:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineBotResults();
                case 2057376407:
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
                case 1685588756:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFeaturedStickers();
                case 1527873830:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadFeaturedStickers();
                case -1649852357:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentStickers();
                case 958863608:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveRecentSticker();
                case -1986437075:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearRecentStickers();
                case 1475442322:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetArchivedStickers();
                case 1678738104:
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
                case -468934396:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetCommonChats();
                case -2023787330:
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
                case 82946729:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFavedStickers();
                case -1174420133:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.FaveSticker();
                case 1180140658:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions();
                case 251759059:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMentions();
                case 1881817312:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentLocations();
                case -134016113:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMultiMedia();
                case 1347929239:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadEncryptedFile();
                case 896555914:
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
                case 428848198:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestUrlAuth();
                case -1322487515:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptUrlAuth();
                case 1336717624:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HidePeerSettingsBar();
                case -183077365:
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
                case 2127598753:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOldFeaturedStickers();
                case 584962828:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetReplies();
                case 1147761405:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDiscussionMessage();
                case -147740172:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadDiscussion();
                case -265962357:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UnpinAllMessages();
                case 1540419152:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChat();
                case -104078327:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeletePhoneCallHistory();
                case 1140726259:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckHistoryImport();
                case 873008187:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.InitHistoryImport();
                case 713433234:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadImportedMedia();
                case -1271008444:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartHistoryImport();
                case -1565154314:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvites();
                case 1937010524:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvite();
                case -1110823051:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditExportedChatInvite();
                case 1452833749:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteRevokedExportedChatInvites();
                case -731601877:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteExportedChatInvite();
                case 958457583:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAdminsWithInvites();
                case -553329330:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChatInviteImporters();
                case -1207017500:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetHistoryTTL();
                case 1573261059:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckHistoryImportPeer();
                case -432283329:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatTheme();
                case 745510839:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReadParticipants();
                case 1240514025:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsCalendar();
                case 1855292323:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsPositions();
                case 2145904661:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideChatJoinRequest();
                case -528091926:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideAllChatJoinRequests();
                case -1323389022:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleNoForwards();
                case -855777386:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDefaultSendAs();
                case 627641572:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendReaction();
                case -1950707482:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesReactions();
                case -521245833:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReactionsList();
                case 335875750:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatAvailableReactions();
                case 417243308:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAvailableReactions();
                case -647969580:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetDefaultReaction();
                case 617508334:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslateText();
                case -396644838:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadReactions();
                case -2099097129:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadReactions();
                case 276705696:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchSentMedia();
                case 385663691:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachMenuBots();
                case 1998676370:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachMenuBot();
                case 451818415:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleBotInAttachMenu();
                case -1850648527:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestWebView();
                case -362824498:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.ProlongWebView();
                case 1790652275:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestSimpleWebView();
                case 172168437:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendWebViewResultMessage();
                case -603831608:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendWebViewData();
                case 647928393:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribeAudio();
                case 2132608815:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Messages.RateTranscribedAudio();
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
                case -1101843010:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFile();
                case -562337987:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveBigFilePart();
                case 619086221:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetWebFile();
                case 962554330:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFile();
                case -1691921240:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.ReuploadCdnFile();
                case -1847836879:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFileHashes();
                case -1856595926:
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
                case -183649631:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.DismissSuggestion();
                case 1935116200:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCountriesList();
                case -1206152236:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPremiumPromo();
                case -871347913:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory();
                case -2067661490:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages();
                case -196443371:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam();
                case -1383294429:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages();
                case 2010044880:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipants();
                case -1599378234:
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
                case -1763259007:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned();
                case 870184064:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog();
                case -359881479:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetStickers();
                case -357180360:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents();
                case -1683319225:
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
                case 187239529:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ConvertToGigagroup();
                case -1095836780:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ViewSponsoredMessage();
                case -333377601:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSponsoredMessages();
                case 231174382:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSendAs();
                case 913655003:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteParticipantHistory();
                case -456419968:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinToSend();
                case 1277789622:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinRequest();
                case -1440257555:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SendCustomRequest();
                case -434028723:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.AnswerWebhookJSONQuery();
                case 85399130:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotCommands();
                case 1032708345:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.ResetBotCommands();
                case -481554986:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.GetBotCommands();
                case 1157944655:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotMenuButton();
                case -1671369944:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.GetBotMenuButton();
                case 2021942497:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotBroadcastDefaultAdminRights();
                case -1839281686:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotGroupDefaultAdminRights();
                case 924093883:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentForm();
                case 611897804:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentReceipt();
                case -1228345045:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidateRequestedInfo();
                case 755192367:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm();
                case 578650699:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetSavedInfo();
                case -667062079:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ClearSavedInfo();
                case 779736953:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetBankCardData();
                case 261206117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.ExportInvoice();
                case 224186320:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.AssignAppStoreTransaction();
                case 1336560365:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.AssignPlayMarketTransaction();
                case -1435856696:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.CanPurchasePremium();
                case 342791565:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Payments.RequestRecurringPayment();
                case -1876841625:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CreateStickerSet();
                case -143257775:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.RemoveStickerFromSet();
                case -4795190:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.ChangeStickerPosition();
                case -2041315650:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.AddStickerToSet();
                case -1707717072:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SetStickerSetThumb();
                case 676017721:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CheckShortName();
                case 1303364867:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestShortName();
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
                case 1221445336:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.CreateGroupCall();
                case -1322057861:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinGroupCall();
                case 1342404601:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.LeaveGroupCall();
                case 2067345760:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.InviteToGroupCall();
                case 2054648117:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.DiscardGroupCall();
                case 1958458429:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallSettings();
                case 68699611:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCall();
                case -984033109:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupParticipants();
                case -1248003721:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.CheckGroupCall();
                case -248985848:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallRecord();
                case -1524155713:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.EditGroupCallParticipant();
                case 480685066:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.EditGroupCallTitle();
                case -277077702:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallJoinAs();
                case -425040769:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportGroupCallInvite();
                case 563885286:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallStartSubscription();
                case 1451287362:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.StartScheduledGroupCall();
                case 1465786252:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveDefaultGroupCallJoinAs();
                case -873829436:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinGroupCallPresentation();
                case 475058500:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.LeaveGroupCallPresentation();
                case 447879488:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallStreamChannels();
                case -558650433:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallStreamRtmpUrl();
                case 1092913030:
                    return new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveCallLog();
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
                case -1443537003:
                    return new CatraProto.Client.TL.Schemas.MTProto.PQInnerDataDc();
                case 1459478408:
                    return new CatraProto.Client.TL.Schemas.MTProto.PQInnerDataTempDc();
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
                case -630588590:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq();
                case 2105940488:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgResendReq();
                case -2045723925:
                    return new CatraProto.Client.TL.Schemas.MTProto.MsgResendAnsReq();
            }

            return null;
        }


        public override IObject? GetNakedFromType(Type type)
        {
            if (InternalGetNakedFromType(type, out var obj))
            {
                return obj;
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.PQInnerDataDc))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.PQInnerDataDc();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.PQInnerDataTempDc))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.PQInnerDataTempDc();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsFail))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsFail();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsOk))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsOk();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerData))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerData();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerData))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerData();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DhGenOk))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DhGenOk();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DhGenRetry))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DhGenRetry();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DhGenFail))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DhGenFail();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcResult))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcResult();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcError))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcError();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcAnswerUnknown))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerUnknown();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDroppedRunning))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDroppedRunning();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDropped))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDropped();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.FutureSalt))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.FutureSalt();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.FutureSalts))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.FutureSalts();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DestroySessionOk))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DestroySessionOk();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DestroySessionNone))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DestroySessionNone();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.NewSessionCreated))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.NewSessionCreated();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgContainer))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgContainer();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.Message))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.Message();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgCopy))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgCopy();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsAck))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgsAck();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.BadMsgNotification))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.BadMsgNotification();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.BadServerSalt))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.BadServerSalt();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfo))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfo();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfo))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfo();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfo))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfo();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgNewDetailedInfo))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgNewDetailedInfo();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInner))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInner();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.ReqDHParams))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.ReqDHParams();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.SetClientDHParams))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.SetClientDHParams();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswer))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswer();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.GetFutureSalts))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.GetFutureSalts();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.DestroySession))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.DestroySession();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.HttpWait))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.HttpWait();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgResendReq))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgResendReq();
            }

            if (type == typeof(CatraProto.Client.TL.Schemas.MTProto.MsgResendAnsReq))
            {
                return new CatraProto.Client.TL.Schemas.MTProto.MsgResendAnsReq();
            }

            return null;
        }
    }
}