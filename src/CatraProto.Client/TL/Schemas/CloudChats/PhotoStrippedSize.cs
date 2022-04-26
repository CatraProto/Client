using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhotoStrippedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -525288402; }

        [Newtonsoft.Json.JsonProperty("type")]
        public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public PhotoStrippedSize(string type, byte[] bytes)
        {
            Type = type;
            Bytes = bytes;

        }
#nullable disable
        internal PhotoStrippedSize()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Type);

            writer.WriteBytes(Bytes);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
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
            return "photoStrippedSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoStrippedSize
            {
                Type = Type,
                Bytes = Bytes
            };
            return newClonedObject;

        }
#nullable disable
    }
}