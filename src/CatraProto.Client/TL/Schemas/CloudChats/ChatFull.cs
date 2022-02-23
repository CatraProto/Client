using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatFull : CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSetUsername = 1 << 7,
            HasScheduled = 1 << 8,
            ChatPhoto = 1 << 2,
            ExportedInvite = 1 << 13,
            BotInfo = 1 << 3,
            PinnedMsgId = 1 << 6,
            FolderId = 1 << 11,
            Call = 1 << 12,
            TtlPeriod = 1 << 14,
            GroupcallDefaultJoinAs = 1 << 15,
            ThemeEmoticon = 1 << 16,
            RequestsPending = 1 << 17,
            RecentRequesters = 1 << 17
        }

        public static int StaticConstructorId
        {
            get => 1185349556;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_set_username")]
        public bool CanSetUsername { get; set; }

        [Newtonsoft.Json.JsonProperty("has_scheduled")]
        public bool HasScheduled { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [Newtonsoft.Json.JsonProperty("exported_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_info")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_msg_id")]
        public int? PinnedMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public sealed override int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("groupcall_default_join_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase GroupcallDefaultJoinAs { get; set; }

        [Newtonsoft.Json.JsonProperty("theme_emoticon")]
        public string ThemeEmoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("requests_pending")]
        public int? RequestsPending { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_requesters")]
        public IList<long> RecentRequesters { get; set; }


    #nullable enable
        public ChatFull(long id, string about, CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase participants, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings)
        {
            Id = id;
            About = about;
            Participants = participants;
            NotifySettings = notifySettings;
        }
    #nullable disable
        internal ChatFull()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = ChatPhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ExportedInvite == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
            Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = Call == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
            Flags = GroupcallDefaultJoinAs == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
            Flags = ThemeEmoticon == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
            Flags = RequestsPending == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
            Flags = RecentRequesters == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(About);
            writer.Write(Participants);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ChatPhoto);
            }

            writer.Write(NotifySettings);
            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                writer.Write(ExportedInvite);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(BotInfo);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.Write(PinnedMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.Write(FolderId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                writer.Write(Call);
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                writer.Write(TtlPeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                writer.Write(GroupcallDefaultJoinAs);
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.Write(ThemeEmoticon);
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.Write(RequestsPending.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.Write(RecentRequesters);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanSetUsername = FlagsHelper.IsFlagSet(Flags, 7);
            HasScheduled = FlagsHelper.IsFlagSet(Flags, 8);
            Id = reader.Read<long>();
            About = reader.Read<string>();
            Participants = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ChatPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            }

            NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                ExportedInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                BotInfo = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                PinnedMsgId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                FolderId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                TtlPeriod = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                GroupcallDefaultJoinAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                ThemeEmoticon = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                RequestsPending = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                RecentRequesters = reader.ReadVector<long>();
            }
        }

        public override string ToString()
        {
            return "chatFull";
        }
    }
}