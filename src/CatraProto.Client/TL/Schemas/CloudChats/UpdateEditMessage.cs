using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateEditMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -469536605;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


    #nullable enable
        public UpdateEditMessage(CatraProto.Client.TL.Schemas.CloudChats.MessageBase message, int pts, int ptsCount)
        {
            Message = message;
            Pts = pts;
            PtsCount = ptsCount;
        }
    #nullable disable
        internal UpdateEditMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Message);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateEditMessage";
        }
    }
}