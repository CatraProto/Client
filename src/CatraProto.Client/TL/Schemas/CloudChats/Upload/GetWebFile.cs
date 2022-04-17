using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetWebFile : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 619086221; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checklocation = writer.WriteObject(Location);
            if (checklocation.IsError)
            {
                return checklocation;
            }
            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylocation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase>();
            if (trylocation.IsError)
            {
                return ReadResult<IObject>.Move(trylocation);
            }
            Location = trylocation.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.getWebFile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}