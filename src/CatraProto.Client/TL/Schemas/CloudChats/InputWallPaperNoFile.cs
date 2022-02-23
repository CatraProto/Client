using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputWallPaperNoFile : CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase
    {
        public static int StaticConstructorId
        {
            get => -1770371538;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }


    #nullable enable
        public InputWallPaperNoFile(long id)
        {
            Id = id;
        }
    #nullable disable
        internal InputWallPaperNoFile()
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
            Id = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputWallPaperNoFile";
        }
    }
}