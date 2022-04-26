using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class GetBankCardData : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 779736953; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("number")]
        public string Number { get; set; }


#nullable enable
        public GetBankCardData(string number)
        {
            Number = number;

        }
#nullable disable

        internal GetBankCardData()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Number);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynumber = reader.ReadString();
            if (trynumber.IsError)
            {
                return ReadResult<IObject>.Move(trynumber);
            }
            Number = trynumber.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.getBankCardData";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetBankCardData
            {
                Number = Number
            };
            return newClonedObject;

        }
#nullable disable
    }
}