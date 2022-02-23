using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanEdit = 1 << 0,
            Self = 1 << 1,
            InviterId = 1 << 1,
            Rank = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => 885242707;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        [Newtonsoft.Json.JsonProperty("self")] public bool Self { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long? InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("promoted_by")]
        public long PromotedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [Newtonsoft.Json.JsonProperty("rank")] public string Rank { get; set; }


    #nullable enable
        public ChannelParticipantAdmin(long userId, long promotedBy, int date, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights)
        {
            UserId = userId;
            PromotedBy = promotedBy;
            Date = date;
            AdminRights = adminRights;
        }
    #nullable disable
        internal ChannelParticipantAdmin()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CanEdit ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Self ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = InviterId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(InviterId.Value);
            }

            writer.Write(PromotedBy);
            writer.Write(Date);
            writer.Write(AdminRights);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Rank);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanEdit = FlagsHelper.IsFlagSet(Flags, 0);
            Self = FlagsHelper.IsFlagSet(Flags, 1);
            UserId = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                InviterId = reader.Read<long>();
            }

            PromotedBy = reader.Read<long>();
            Date = reader.Read<int>();
            AdminRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Rank = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "channelParticipantAdmin";
        }
    }
}