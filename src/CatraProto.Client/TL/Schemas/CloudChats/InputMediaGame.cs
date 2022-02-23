using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaGame : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        public static int StaticConstructorId
        {
            get => -750828557;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputGameBase Id { get; set; }


    #nullable enable
        public InputMediaGame(CatraProto.Client.TL.Schemas.CloudChats.InputGameBase id)
        {
            Id = id;
        }
    #nullable disable
        internal InputMediaGame()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGameBase>();
        }

        public override string ToString()
        {
            return "inputMediaGame";
        }
    }
}