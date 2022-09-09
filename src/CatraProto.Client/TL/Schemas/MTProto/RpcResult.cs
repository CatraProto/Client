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
    public partial class RpcResult : CatraProto.Client.TL.Schemas.MTProto.RpcResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -212046591; }

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public sealed override long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("result")]
        public sealed override object Result { get; set; }


#nullable enable
        public RpcResult(long reqMsgId, object result)
        {
            ReqMsgId = reqMsgId;
            Result = result;
        }
#nullable disable
        internal RpcResult()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ReqMsgId);
            var checkresult = writer.Write(Result);
            if (checkresult.IsError)
            {
                return checkresult;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreqMsgId = reader.ReadInt64();
            if (tryreqMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreqMsgId);
            }

            ReqMsgId = tryreqMsgId.Value;
            var tryresult = reader.ReadObject();
            if (tryresult.IsError)
            {
                return ReadResult<IObject>.Move(tryresult);
            }

            Result = tryresult.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "rpc_result";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RpcResult();
            newClonedObject.ReqMsgId = ReqMsgId;
            newClonedObject.Result = Result;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RpcResult castedOther)
            {
                return true;
            }

            if (ReqMsgId != castedOther.ReqMsgId)
            {
                return true;
            }

            if (Result != castedOther.Result)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}