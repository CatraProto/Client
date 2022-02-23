using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetFileHashes : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -956147407;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.FileHashBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [Newtonsoft.Json.JsonProperty("location")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase Location { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }


    #nullable enable
        public GetFileHashes(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset)
        {
            Location = location;
            Offset = offset;
        }
    #nullable disable

        internal GetFileHashes()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Location);
            writer.Write(Offset);
        }

        public void Deserialize(Reader reader)
        {
            Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase>();
            Offset = reader.Read<int>();
        }

        public override string ToString()
        {
            return "upload.getFileHashes";
        }
    }
}