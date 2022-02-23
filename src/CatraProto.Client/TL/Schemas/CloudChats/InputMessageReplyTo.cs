using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessageReplyTo : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {
        public static int StaticConstructorId
        {
            get => -1160215659;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }


    #nullable enable
        public InputMessageReplyTo(int id)
        {
            Id = id;
        }
    #nullable disable
        internal InputMessageReplyTo()
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
            return "inputMessageReplyTo";
        }
    }
}