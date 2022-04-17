using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessageReplyTo : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1160215659; }

        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }


#nullable enable
        public InputMessageReplyTo(int id)
        {
            Id = id;

        }
#nullable disable
        internal InputMessageReplyTo()
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
            return "inputMessageReplyTo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}