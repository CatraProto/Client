using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetAuthorizationForm : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1456907910; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("scope")]
        public string Scope { get; set; }

        [Newtonsoft.Json.JsonProperty("public_key")]
        public string PublicKey { get; set; }


#nullable enable
        public GetAuthorizationForm(long botId, string scope, string publicKey)
        {
            BotId = botId;
            Scope = scope;
            PublicKey = publicKey;

        }
#nullable disable

        internal GetAuthorizationForm()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BotId);

            writer.WriteString(Scope);

            writer.WriteString(PublicKey);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }
            BotId = trybotId.Value;
            var tryscope = reader.ReadString();
            if (tryscope.IsError)
            {
                return ReadResult<IObject>.Move(tryscope);
            }
            Scope = tryscope.Value;
            var trypublicKey = reader.ReadString();
            if (trypublicKey.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKey);
            }
            PublicKey = trypublicKey.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getAuthorizationForm";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}