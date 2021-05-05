using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Config : ConfigBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PhonecallsEnabled = 1 << 1,
            DefaultP2pContacts = 1 << 3,
            PreloadFeaturedStickers = 1 << 4,
            IgnorePhoneEntities = 1 << 5,
            RevokePmInbox = 1 << 6,
            BlockedMode = 1 << 8,
            PfsEnabled = 1 << 13,
            TmpSessions = 1 << 0,
            AutoupdateUrlPrefix = 1 << 7,
            GifSearchUsername = 1 << 9,
            VenueSearchUsername = 1 << 10,
            ImgSearchUsername = 1 << 11,
            StaticMapsProvider = 1 << 12,
            SuggestedLangCode = 1 << 2,
            LangPackVersion = 1 << 2,
            BaseLangPackVersion = 1 << 2
        }

        public static int ConstructorId { get; } = 856375399;
        public int Flags { get; set; }
        public override bool PhonecallsEnabled { get; set; }
        public override bool DefaultP2pContacts { get; set; }
        public override bool PreloadFeaturedStickers { get; set; }
        public override bool IgnorePhoneEntities { get; set; }
        public override bool RevokePmInbox { get; set; }
        public override bool BlockedMode { get; set; }
        public override bool PfsEnabled { get; set; }
        public override int Date { get; set; }
        public override int Expires { get; set; }
        public override bool TestMode { get; set; }
        public override int ThisDc { get; set; }
        public override IList<DcOptionBase> DcOptions { get; set; }
        public override string DcTxtDomainName { get; set; }
        public override int ChatSizeMax { get; set; }
        public override int MegagroupSizeMax { get; set; }
        public override int ForwardedCountMax { get; set; }
        public override int OnlineUpdatePeriodMs { get; set; }
        public override int OfflineBlurTimeoutMs { get; set; }
        public override int OfflineIdleTimeoutMs { get; set; }
        public override int OnlineCloudTimeoutMs { get; set; }
        public override int NotifyCloudDelayMs { get; set; }
        public override int NotifyDefaultDelayMs { get; set; }
        public override int PushChatPeriodMs { get; set; }
        public override int PushChatLimit { get; set; }
        public override int SavedGifsLimit { get; set; }
        public override int EditTimeLimit { get; set; }
        public override int RevokeTimeLimit { get; set; }
        public override int RevokePmTimeLimit { get; set; }
        public override int RatingEDecay { get; set; }
        public override int StickersRecentLimit { get; set; }
        public override int StickersFavedLimit { get; set; }
        public override int ChannelsReadMediaPeriod { get; set; }
        public override int? TmpSessions { get; set; }
        public override int PinnedDialogsCountMax { get; set; }
        public override int PinnedInfolderCountMax { get; set; }
        public override int CallReceiveTimeoutMs { get; set; }
        public override int CallRingTimeoutMs { get; set; }
        public override int CallConnectTimeoutMs { get; set; }
        public override int CallPacketTimeoutMs { get; set; }
        public override string MeUrlPrefix { get; set; }
        public override string AutoupdateUrlPrefix { get; set; }
        public override string GifSearchUsername { get; set; }
        public override string VenueSearchUsername { get; set; }
        public override string ImgSearchUsername { get; set; }
        public override string StaticMapsProvider { get; set; }
        public override int CaptionLengthMax { get; set; }
        public override int MessageLengthMax { get; set; }
        public override int WebfileDcId { get; set; }
        public override string SuggestedLangCode { get; set; }
        public override int? LangPackVersion { get; set; }
        public override int? BaseLangPackVersion { get; set; }

        public override void UpdateFlags()
        {
            Flags = PhonecallsEnabled ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = DefaultP2pContacts ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = PreloadFeaturedStickers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = IgnorePhoneEntities ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = RevokePmInbox ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = BlockedMode ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = PfsEnabled ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = TmpSessions == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = AutoupdateUrlPrefix == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = GifSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = VenueSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = ImgSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = StaticMapsProvider == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
            Flags = SuggestedLangCode == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = LangPackVersion == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = BaseLangPackVersion == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Date);
            writer.Write(Expires);
            writer.Write(TestMode);
            writer.Write(ThisDc);
            writer.Write(DcOptions);
            writer.Write(DcTxtDomainName);
            writer.Write(ChatSizeMax);
            writer.Write(MegagroupSizeMax);
            writer.Write(ForwardedCountMax);
            writer.Write(OnlineUpdatePeriodMs);
            writer.Write(OfflineBlurTimeoutMs);
            writer.Write(OfflineIdleTimeoutMs);
            writer.Write(OnlineCloudTimeoutMs);
            writer.Write(NotifyCloudDelayMs);
            writer.Write(NotifyDefaultDelayMs);
            writer.Write(PushChatPeriodMs);
            writer.Write(PushChatLimit);
            writer.Write(SavedGifsLimit);
            writer.Write(EditTimeLimit);
            writer.Write(RevokeTimeLimit);
            writer.Write(RevokePmTimeLimit);
            writer.Write(RatingEDecay);
            writer.Write(StickersRecentLimit);
            writer.Write(StickersFavedLimit);
            writer.Write(ChannelsReadMediaPeriod);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(TmpSessions.Value);
            }

            writer.Write(PinnedDialogsCountMax);
            writer.Write(PinnedInfolderCountMax);
            writer.Write(CallReceiveTimeoutMs);
            writer.Write(CallRingTimeoutMs);
            writer.Write(CallConnectTimeoutMs);
            writer.Write(CallPacketTimeoutMs);
            writer.Write(MeUrlPrefix);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.Write(AutoupdateUrlPrefix);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.Write(GifSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.Write(VenueSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.Write(ImgSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                writer.Write(StaticMapsProvider);
            }

            writer.Write(CaptionLengthMax);
            writer.Write(MessageLengthMax);
            writer.Write(WebfileDcId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(SuggestedLangCode);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(LangPackVersion.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(BaseLangPackVersion.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            PhonecallsEnabled = FlagsHelper.IsFlagSet(Flags, 1);
            DefaultP2pContacts = FlagsHelper.IsFlagSet(Flags, 3);
            PreloadFeaturedStickers = FlagsHelper.IsFlagSet(Flags, 4);
            IgnorePhoneEntities = FlagsHelper.IsFlagSet(Flags, 5);
            RevokePmInbox = FlagsHelper.IsFlagSet(Flags, 6);
            BlockedMode = FlagsHelper.IsFlagSet(Flags, 8);
            PfsEnabled = FlagsHelper.IsFlagSet(Flags, 13);
            Date = reader.Read<int>();
            Expires = reader.Read<int>();
            TestMode = reader.Read<bool>();
            ThisDc = reader.Read<int>();
            DcOptions = reader.ReadVector<DcOptionBase>();
            DcTxtDomainName = reader.Read<string>();
            ChatSizeMax = reader.Read<int>();
            MegagroupSizeMax = reader.Read<int>();
            ForwardedCountMax = reader.Read<int>();
            OnlineUpdatePeriodMs = reader.Read<int>();
            OfflineBlurTimeoutMs = reader.Read<int>();
            OfflineIdleTimeoutMs = reader.Read<int>();
            OnlineCloudTimeoutMs = reader.Read<int>();
            NotifyCloudDelayMs = reader.Read<int>();
            NotifyDefaultDelayMs = reader.Read<int>();
            PushChatPeriodMs = reader.Read<int>();
            PushChatLimit = reader.Read<int>();
            SavedGifsLimit = reader.Read<int>();
            EditTimeLimit = reader.Read<int>();
            RevokeTimeLimit = reader.Read<int>();
            RevokePmTimeLimit = reader.Read<int>();
            RatingEDecay = reader.Read<int>();
            StickersRecentLimit = reader.Read<int>();
            StickersFavedLimit = reader.Read<int>();
            ChannelsReadMediaPeriod = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                TmpSessions = reader.Read<int>();
            }

            PinnedDialogsCountMax = reader.Read<int>();
            PinnedInfolderCountMax = reader.Read<int>();
            CallReceiveTimeoutMs = reader.Read<int>();
            CallRingTimeoutMs = reader.Read<int>();
            CallConnectTimeoutMs = reader.Read<int>();
            CallPacketTimeoutMs = reader.Read<int>();
            MeUrlPrefix = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                AutoupdateUrlPrefix = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                GifSearchUsername = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                VenueSearchUsername = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                ImgSearchUsername = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                StaticMapsProvider = reader.Read<string>();
            }

            CaptionLengthMax = reader.Read<int>();
            MessageLengthMax = reader.Read<int>();
            WebfileDcId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                SuggestedLangCode = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                LangPackVersion = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                BaseLangPackVersion = reader.Read<int>();
            }
        }
    }
}