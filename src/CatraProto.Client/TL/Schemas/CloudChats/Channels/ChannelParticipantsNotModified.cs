using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipantsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase
    {
        public static int StaticConstructorId
        {
            get => -266911767;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public ChannelParticipantsNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "channels.channelParticipantsNotModified";
        }
    }
}