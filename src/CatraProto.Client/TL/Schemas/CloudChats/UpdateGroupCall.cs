using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateGroupCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 347227392;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }


    #nullable enable
        public UpdateGroupCall(long chatId, CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase call)
        {
            ChatId = chatId;
            Call = call;
        }
    #nullable disable
        internal UpdateGroupCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(Call);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase>();
        }

        public override string ToString()
        {
            return "updateGroupCall";
        }
    }
}