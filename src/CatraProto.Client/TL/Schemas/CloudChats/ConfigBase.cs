using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ConfigBase : IObject
    {
        public abstract bool PhonecallsEnabled { get; set; }
        public abstract bool DefaultP2pContacts { get; set; }
        public abstract bool PreloadFeaturedStickers { get; set; }
        public abstract bool IgnorePhoneEntities { get; set; }
        public abstract bool RevokePmInbox { get; set; }
        public abstract bool BlockedMode { get; set; }
        public abstract bool PfsEnabled { get; set; }
        public abstract int Date { get; set; }
        public abstract int Expires { get; set; }
        public abstract bool TestMode { get; set; }
        public abstract int ThisDc { get; set; }
        public abstract IList<DcOptionBase> DcOptions { get; set; }
        public abstract string DcTxtDomainName { get; set; }
        public abstract int ChatSizeMax { get; set; }
        public abstract int MegagroupSizeMax { get; set; }
        public abstract int ForwardedCountMax { get; set; }
        public abstract int OnlineUpdatePeriodMs { get; set; }
        public abstract int OfflineBlurTimeoutMs { get; set; }
        public abstract int OfflineIdleTimeoutMs { get; set; }
        public abstract int OnlineCloudTimeoutMs { get; set; }
        public abstract int NotifyCloudDelayMs { get; set; }
        public abstract int NotifyDefaultDelayMs { get; set; }
        public abstract int PushChatPeriodMs { get; set; }
        public abstract int PushChatLimit { get; set; }
        public abstract int SavedGifsLimit { get; set; }
        public abstract int EditTimeLimit { get; set; }
        public abstract int RevokeTimeLimit { get; set; }
        public abstract int RevokePmTimeLimit { get; set; }
        public abstract int RatingEDecay { get; set; }
        public abstract int StickersRecentLimit { get; set; }
        public abstract int StickersFavedLimit { get; set; }
        public abstract int ChannelsReadMediaPeriod { get; set; }
        public abstract int? TmpSessions { get; set; }
        public abstract int PinnedDialogsCountMax { get; set; }
        public abstract int PinnedInfolderCountMax { get; set; }
        public abstract int CallReceiveTimeoutMs { get; set; }
        public abstract int CallRingTimeoutMs { get; set; }
        public abstract int CallConnectTimeoutMs { get; set; }
        public abstract int CallPacketTimeoutMs { get; set; }
        public abstract string MeUrlPrefix { get; set; }
        public abstract string AutoupdateUrlPrefix { get; set; }
        public abstract string GifSearchUsername { get; set; }
        public abstract string VenueSearchUsername { get; set; }
        public abstract string ImgSearchUsername { get; set; }
        public abstract string StaticMapsProvider { get; set; }
        public abstract int CaptionLengthMax { get; set; }
        public abstract int MessageLengthMax { get; set; }
        public abstract int WebfileDcId { get; set; }
        public abstract string SuggestedLangCode { get; set; }
        public abstract int? LangPackVersion { get; set; }
        public abstract int? BaseLangPackVersion { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}