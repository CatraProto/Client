using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickeredMediaDocument : CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 70813275; }

        [Newtonsoft.Json.JsonProperty("id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }


#nullable enable
        public InputStickeredMediaDocument(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id)
        {
            Id = id;

        }
#nullable disable
        internal InputStickeredMediaDocument()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputStickeredMediaDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}