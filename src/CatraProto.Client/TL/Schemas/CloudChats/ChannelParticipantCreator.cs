using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantCreator : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Rank = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 803602899;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [Newtonsoft.Json.JsonProperty("rank")] public string Rank { get; set; }


    #nullable enable
        public ChannelParticipantCreator(long userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights)
        {
            UserId = userId;
            AdminRights = adminRights;
        }
    #nullable disable
        internal ChannelParticipantCreator()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            writer.Write(AdminRights);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Rank);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UserId = reader.Read<long>();
            AdminRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Rank = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "channelParticipantCreator";
        }
    }
}