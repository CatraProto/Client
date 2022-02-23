using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessageID : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {
        public static int StaticConstructorId
        {
            get => -1502174430;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }


    #nullable enable
        public InputMessageID(int id)
        {
            Id = id;
        }
    #nullable disable
        internal InputMessageID()
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
            Id = reader.Read<int>();
        }

        public override string ToString()
        {
            return "inputMessageID";
        }
    }
}