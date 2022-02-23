using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageService : CatraProto.Client.TL.Schemas.CloudChats.MessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Out = 1 << 1,
            Mentioned = 1 << 4,
            MediaUnread = 1 << 5,
            Silent = 1 << 13,
            Post = 1 << 14,
            Legacy = 1 << 19,
            FromId = 1 << 8,
            ReplyTo = 1 << 3,
            TtlPeriod = 1 << 25
        }

        public static int StaticConstructorId
        {
            get => 721967202;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("out")] public bool Out { get; set; }

        [Newtonsoft.Json.JsonProperty("mentioned")]
        public bool Mentioned { get; set; }

        [Newtonsoft.Json.JsonProperty("media_unread")]
        public bool MediaUnread { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("post")] public bool Post { get; set; }

        [Newtonsoft.Json.JsonProperty("legacy")]
        public bool Legacy { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase Action { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }


    #nullable enable
        public MessageService(int id, CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, int date, CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase action)
        {
            Id = id;
            PeerId = peerId;
            Date = date;
            Action = action;
        }
    #nullable disable
        internal MessageService()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = Post ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = Legacy ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
            Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.Write(FromId);
            }

            writer.Write(PeerId);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(ReplyTo);
            }

            writer.Write(Date);
            writer.Write(Action);
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.Write(TtlPeriod.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Out = FlagsHelper.IsFlagSet(Flags, 1);
            Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
            MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
            Silent = FlagsHelper.IsFlagSet(Flags, 13);
            Post = FlagsHelper.IsFlagSet(Flags, 14);
            Legacy = FlagsHelper.IsFlagSet(Flags, 19);
            Id = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            }

            PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                ReplyTo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
            }

            Date = reader.Read<int>();
            Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase>();
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                TtlPeriod = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "messageService";
        }
    }
}