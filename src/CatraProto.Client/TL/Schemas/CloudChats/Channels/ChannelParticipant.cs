using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipant : ChannelParticipantBase
    {
        public static int StaticConstructorId
        {
            get => -791039645;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("participant")] public override CloudChats.ChannelParticipantBase Participant { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Participant);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Participant = reader.Read<CloudChats.ChannelParticipantBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "channels.channelParticipant";
        }
    }
}