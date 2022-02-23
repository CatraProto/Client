using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantsContacts : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
    {
        public static int StaticConstructorId
        {
            get => -1150621555;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }


    #nullable enable
        public ChannelParticipantsContacts(string q)
        {
            Q = q;
        }
    #nullable disable
        internal ChannelParticipantsContacts()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Q);
        }

        public override void Deserialize(Reader reader)
        {
            Q = reader.Read<string>();
        }

        public override string ToString()
        {
            return "channelParticipantsContacts";
        }
    }
}