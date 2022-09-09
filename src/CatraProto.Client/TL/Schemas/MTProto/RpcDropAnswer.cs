using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcDropAnswer : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1491380032; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RpcDropAnswer();
            newClonedObject.ReqMsgId = ReqMsgId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RpcDropAnswer castedOther)
            {
                return true;
            }

            if (ReqMsgId != castedOther.ReqMsgId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}