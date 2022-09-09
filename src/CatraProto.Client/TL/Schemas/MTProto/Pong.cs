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
    public partial class Pong : CatraProto.Client.TL.Schemas.MTProto.PongBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 880243653; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public sealed override long PingId { get; set; }


#nullable enable
        public Pong(long msgId, long pingId)
        {
            MsgId = msgId;
            PingId = pingId;
        }
#nullable disable
        internal Pong()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(MsgId);
            writer.WriteInt64(PingId);

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
            var trypingId = reader.ReadInt64();
            if (trypingId.IsError)
            {
                return ReadResult<IObject>.Move(trypingId);
            }

            PingId = trypingId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Pong();
            newClonedObject.MsgId = MsgId;
            newClonedObject.PingId = PingId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Pong castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (PingId != castedOther.PingId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}