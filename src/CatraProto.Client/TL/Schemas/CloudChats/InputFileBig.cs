using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputFileBig : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
    {
        public static int StaticConstructorId
        {
            get => -95482955;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public sealed override int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


    #nullable enable
        public InputFileBig(long id, int parts, string name)
        {
            Id = id;
            Parts = parts;
            Name = name;
        }
    #nullable disable
        internal InputFileBig()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Parts);
            writer.Write(Name);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Parts = reader.Read<int>();
            Name = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputFileBig";
        }
    }
}