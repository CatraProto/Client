using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipants : ChannelParticipantsBase
    {
        public static int StaticConstructorId
        {
            get => -177282392;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("count")] public int Count { get; set; }

        [JsonProperty("participants")] public IList<CloudChats.ChannelParticipantBase> Participants { get; set; }

        [JsonProperty("users")] public IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Count);
            writer.Write(Participants);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Participants = reader.ReadVector<CloudChats.ChannelParticipantBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "channels.channelParticipants";
        }
    }
}