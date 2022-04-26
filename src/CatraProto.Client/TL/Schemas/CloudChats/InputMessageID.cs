using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessageID : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1502174430; }

        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }


#nullable enable
        public InputMessageID(int id)
        {
            Id = id;

        }
#nullable disable
        internal InputMessageID()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Id);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputMessageID";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessageID
            {
                Id = Id
            };
            return newClonedObject;

        }
#nullable disable
    }
}