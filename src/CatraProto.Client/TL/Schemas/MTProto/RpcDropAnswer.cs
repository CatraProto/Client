using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcDropAnswer : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1491380032; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public long ReqMsgId { get; set; }


#nullable enable
        public RpcDropAnswer(long reqMsgId)
        {
            ReqMsgId = reqMsgId;

        }
#nullable disable

        internal RpcDropAnswer()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ReqMsgId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreqMsgId = reader.ReadInt64();
            if (tryreqMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreqMsgId);
            }
            ReqMsgId = tryreqMsgId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "rpc_drop_answer";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}