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
    public partial class MsgsStateReq : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -630588590; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("msg_ids")]
        public List<long> MsgIds { get; set; }


#nullable enable
        public MsgsStateReq(List<long> msgIds)
        {
            MsgIds = msgIds;
        }
#nullable disable

        internal MsgsStateReq()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(MsgIds, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
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
            return "msgs_state_req";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new MsgsStateReq();
            newClonedObject.MsgIds = new List<long>();
            foreach (var msgIds in MsgIds)
            {
                newClonedObject.MsgIds.Add(msgIds);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not MsgsStateReq castedOther)
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