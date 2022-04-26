using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class SaveFilePart : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1291540959; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("file_id")]
        public long FileId { get; set; }

        [Newtonsoft.Json.JsonProperty("file_part")]
        public int FilePart { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public SaveFilePart(long fileId, int filePart, byte[] bytes)
        {
            FileId = fileId;
            FilePart = filePart;
            Bytes = bytes;

        }
#nullable disable

        internal SaveFilePart()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(FileId);
            writer.WriteInt32(FilePart);

            writer.WriteBytes(Bytes);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileId = reader.ReadInt64();
            if (tryfileId.IsError)
            {
                return ReadResult<IObject>.Move(tryfileId);
            }
            FileId = tryfileId.Value;
            var tryfilePart = reader.ReadInt32();
            if (tryfilePart.IsError)
            {
                return ReadResult<IObject>.Move(tryfilePart);
            }
            FilePart = tryfilePart.Value;
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.saveFilePart";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveFilePart
            {
                FileId = FileId,
                FilePart = FilePart,
                Bytes = Bytes
            };
            return newClonedObject;

        }
#nullable disable
    }
}