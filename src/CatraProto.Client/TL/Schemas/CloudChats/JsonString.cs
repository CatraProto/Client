using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class JsonString : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1222740358; }

        [Newtonsoft.Json.JsonProperty("value")]
        public string Value { get; set; }


#nullable enable
        public JsonString(string value)
        {
            Value = value;

        }
#nullable disable
        internal JsonString()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Value);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadString();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "jsonString";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}