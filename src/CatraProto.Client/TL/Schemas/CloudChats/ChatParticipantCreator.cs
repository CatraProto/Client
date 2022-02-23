using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantCreator : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase
    {
        public static int StaticConstructorId
        {
            get => -462696732;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }


    #nullable enable
        public ChatParticipantCreator(long userId)
        {
            UserId = userId;
        }
    #nullable disable
        internal ChatParticipantCreator()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "chatParticipantCreator";
        }
    }
}