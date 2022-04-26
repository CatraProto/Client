using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CheckRecoveryPassword : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 221691769; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }


#nullable enable
        public CheckRecoveryPassword(string code)
        {
            Code = code;

        }
#nullable disable

        internal CheckRecoveryPassword()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Code);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycode = reader.ReadString();
            if (trycode.IsError)
            {
                return ReadResult<IObject>.Move(trycode);
            }
            Code = trycode.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.checkRecoveryPassword";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckRecoveryPassword
            {
                Code = Code
            };
            return newClonedObject;

        }
#nullable disable
    }
}