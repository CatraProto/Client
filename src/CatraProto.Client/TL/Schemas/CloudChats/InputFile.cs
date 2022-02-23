using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputFile : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
    {
        public static int StaticConstructorId
        {
            get => -181407105;
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

        [Newtonsoft.Json.JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }


    #nullable enable
        public InputFile(long id, int parts, string name, string md5Checksum)
        {
            Id = id;
            Parts = parts;
            Name = name;
            Md5Checksum = md5Checksum;
        }
    #nullable disable
        internal InputFile()
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
            writer.Write(Md5Checksum);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Parts = reader.Read<int>();
            Name = reader.Read<string>();
            Md5Checksum = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputFile";
        }
    }
}