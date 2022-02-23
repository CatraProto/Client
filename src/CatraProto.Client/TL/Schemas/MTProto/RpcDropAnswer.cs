using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcDropAnswer : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1491380032;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

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

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ReqMsgId);
        }

        public void Deserialize(Reader reader)
        {
            ReqMsgId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "rpc_drop_answer";
        }
    }
}