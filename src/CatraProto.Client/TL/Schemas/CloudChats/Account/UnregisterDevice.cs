using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UnregisterDevice : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1779249670; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("token_type")]
        public int TokenType { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("other_uids")]
        public List<long> OtherUids { get; set; }


#nullable enable
        public UnregisterDevice(int tokenType, string token, List<long> otherUids)
        {
            TokenType = tokenType;
            Token = token;
            OtherUids = otherUids;

        }
#nullable disable

        internal UnregisterDevice()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(TokenType);

            writer.WriteString(Token);

            writer.WriteVector(OtherUids, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytokenType = reader.ReadInt32();
            if (trytokenType.IsError)
            {
                return ReadResult<IObject>.Move(trytokenType);
            }
            TokenType = trytokenType.Value;
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }
            Token = trytoken.Value;
            var tryotherUids = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryotherUids.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUids);
            }
            OtherUids = tryotherUids.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.unregisterDevice";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UnregisterDevice
            {
                TokenType = TokenType,
                Token = Token
            };
            foreach (var otherUids in OtherUids)
            {
                newClonedObject.OtherUids.Add(otherUids);
            }
            return newClonedObject;

        }
#nullable disable
    }
}