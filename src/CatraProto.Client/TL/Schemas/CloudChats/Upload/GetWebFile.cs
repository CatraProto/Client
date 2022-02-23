using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetWebFile : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 619086221;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("location")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase Location { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


    #nullable enable
        public GetWebFile(CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase location, int offset, int limit)
        {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
    #nullable disable

        internal GetWebFile()
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
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase>();
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
        }

        public override string ToString()
        {
            return "upload.getWebFile";
        }
    }
}