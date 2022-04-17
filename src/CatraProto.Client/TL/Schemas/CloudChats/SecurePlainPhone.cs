using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePlainPhone : CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2103482845; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public string Phone { get; set; }


#nullable enable
        public SecurePlainPhone(string phone)
        {
            Phone = phone;

        }
#nullable disable
        internal SecurePlainPhone()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Phone);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphone = reader.ReadString();
            if (tryphone.IsError)
            {
                return ReadResult<IObject>.Move(tryphone);
            }
            Phone = tryphone.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "securePlainPhone";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}