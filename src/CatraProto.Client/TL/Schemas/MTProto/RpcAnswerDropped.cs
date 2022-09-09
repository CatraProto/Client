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
    public partial class RpcAnswerDropped : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1539647305; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seq_no")]
        public int SeqNo { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public int Bytes { get; set; }


#nullable enable
        public RpcAnswerDropped(long msgId, int seqNo, int bytes)
        {
            MsgId = msgId;
            SeqNo = seqNo;
            Bytes = bytes;
        }
#nullable disable
        internal RpcAnswerDropped()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(MsgId);
            writer.WriteInt32(SeqNo);
            writer.WriteInt32(Bytes);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgId = reader.ReadInt64();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            var tryseqNo = reader.ReadInt32();
            if (tryseqNo.IsError)
            {
                return ReadResult<IObject>.Move(tryseqNo);
            }

            SeqNo = tryseqNo.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }

            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "rpc_answer_dropped";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RpcAnswerDropped();
            newClonedObject.MsgId = MsgId;
            newClonedObject.SeqNo = SeqNo;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RpcAnswerDropped castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (SeqNo != castedOther.SeqNo)
            {
                return true;
            }

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}