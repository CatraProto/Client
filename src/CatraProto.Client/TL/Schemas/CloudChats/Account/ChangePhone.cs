using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ChangePhone : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1891839707; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code")]
        public string PhoneCode { get; set; }


#nullable enable
        public ChangePhone(string phoneNumber, string phoneCodeHash, string phoneCode)
        {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;

        }
#nullable disable

        internal ChangePhone()
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

            writer.WriteString(PhoneCode);

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
            var tryphoneCode = reader.ReadString();
            if (tryphoneCode.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCode);
            }
            PhoneCode = tryphoneCode.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.changePhone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ChangePhone
            {
                PhoneNumber = PhoneNumber,
                PhoneCodeHash = PhoneCodeHash,
                PhoneCode = PhoneCode
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ChangePhone castedOther)
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
            if (PhoneCode != castedOther.PhoneCode)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}