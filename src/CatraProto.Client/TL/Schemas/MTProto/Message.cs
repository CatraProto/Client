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
    public partial class Message : CatraProto.Client.TL.Schemas.MTProto.MessageBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 0; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seqno")]
        public sealed override int Seqno { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("body")] public sealed override IObject Body { get; set; }


#nullable enable
        public Message(long msgId, int seqno, int bytes, IObject body)
        {
            MsgId = msgId;
            Seqno = seqno;
            Bytes = bytes;
            Body = body;
        }
#nullable disable
        internal Message()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt64(MsgId);
            writer.WriteInt32(Seqno);
            writer.WriteInt32(Bytes);
            var checkbody = writer.WriteObject(Body);
            if (checkbody.IsError)
            {
                return checkbody;
            }

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
            var tryseqno = reader.ReadInt32();
            if (tryseqno.IsError)
            {
                return ReadResult<IObject>.Move(tryseqno);
            }

            Seqno = tryseqno.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }

            Bytes = trybytes.Value;
            var trybody = reader.ReadObject<IObject>();
            if (trybody.IsError)
            {
                return ReadResult<IObject>.Move(trybody);
            }

            Body = trybody.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "message";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Message();
            newClonedObject.MsgId = MsgId;
            newClonedObject.Seqno = Seqno;
            newClonedObject.Bytes = Bytes;
            newClonedObject.Body = Body;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Message castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (Seqno != castedOther.Seqno)
            {
                return true;
            }

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            if (Body != castedOther.Body)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}