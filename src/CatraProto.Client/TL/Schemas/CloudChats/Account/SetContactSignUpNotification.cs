using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetContactSignUpNotification : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -806076575; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }


#nullable enable
        public SetContactSignUpNotification(bool silent)
        {
            Silent = silent;

        }
#nullable disable

        internal SetContactSignUpNotification()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksilent = writer.WriteBool(Silent);
            if (checksilent.IsError)
            {
                return checksilent;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysilent = reader.ReadBool();
            if (trysilent.IsError)
            {
                return ReadResult<IObject>.Move(trysilent);
            }
            Silent = trysilent.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.setContactSignUpNotification";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}