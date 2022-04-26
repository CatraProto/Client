using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetCdnFileHashes : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1302676017; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("file_token")]
        public byte[] FileToken { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }


#nullable enable
        public GetCdnFileHashes(byte[] fileToken, int offset)
        {
            FileToken = fileToken;
            Offset = offset;

        }
#nullable disable

        internal GetCdnFileHashes()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(FileToken);
            writer.WriteInt32(Offset);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileToken = reader.ReadBytes();
            if (tryfileToken.IsError)
            {
                return ReadResult<IObject>.Move(tryfileToken);
            }
            FileToken = tryfileToken.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.getCdnFileHashes";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetCdnFileHashes
            {
                FileToken = FileToken,
                Offset = Offset
            };
            return newClonedObject;

        }
#nullable disable
    }
}