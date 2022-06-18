using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ResendCode : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1056025023; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }


#nullable enable
        public ResendCode(string phoneNumber, string phoneCodeHash)
        {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;

        }
#nullable disable

        internal ResendCode()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);

            writer.WriteString(PhoneCodeHash);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneNumber = reader.ReadString();
            if (tryphoneNumber.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneNumber);
            }
            PhoneNumber = tryphoneNumber.Value;
            var tryphoneCodeHash = reader.ReadString();
            if (tryphoneCodeHash.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCodeHash);
            }
            PhoneCodeHash = tryphoneCodeHash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.resendCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ResendCode
            {
                PhoneNumber = PhoneNumber,
                PhoneCodeHash = PhoneCodeHash
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ResendCode castedOther)
            {
                return true;
            }
            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }
            if (PhoneCodeHash != castedOther.PhoneCodeHash)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}