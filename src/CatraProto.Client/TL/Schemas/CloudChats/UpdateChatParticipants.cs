using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 125178264;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("participants")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }


    #nullable enable
        public UpdateChatParticipants(CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase participants)
        {
            Participants = participants;
        }
    #nullable disable
        internal UpdateChatParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Participants);
        }

        public override void Deserialize(Reader reader)
        {
            Participants = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
        }

        public override string ToString()
        {
            return "updateChatParticipants";
        }
    }
}