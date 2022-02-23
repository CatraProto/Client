using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipants : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase
    {
        public static int StaticConstructorId
        {
            get => -1699676497;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public ChannelParticipants(int count, IList<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase> participants, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Participants = participants;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal ChannelParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(Participants);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "channels.channelParticipants";
        }
    }
}