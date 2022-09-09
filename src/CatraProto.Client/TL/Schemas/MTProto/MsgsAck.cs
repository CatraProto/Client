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
    public partial class MsgsAck : CatraProto.Client.TL.Schemas.MTProto.MsgsAckBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1658238041; }

        [Newtonsoft.Json.JsonProperty("msg_ids")]
        public sealed override List<long> MsgIds { get; set; }


#nullable enable
        public MsgsAck(List<long> msgIds)
        {
            MsgIds = msgIds;
        }
#nullable disable
        internal MsgsAck()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(MsgIds, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgIds = reader.ReadVector<long>(ParserTypes.Int64);
            if (trymsgIds.IsError)
            {
                return ReadResult<IObject>.Move(trymsgIds);
            }

            MsgIds = trymsgIds.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "msgs_ack";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgsAck();
            newClonedObject.MsgIds = new List<long>();
            foreach (var msgIds in MsgIds)
            {
                newClonedObject.MsgIds.Add(msgIds);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MsgsAck castedOther)
            {
                return true;
            }

            var msgIdssize = castedOther.MsgIds.Count;
            if (msgIdssize != MsgIds.Count)
            {
                return true;
            }

            for (var i = 0; i < msgIdssize; i++)
            {
                if (castedOther.MsgIds[i] != MsgIds[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}