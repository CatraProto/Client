using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeAfterMsgs : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1036301552; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("msg_ids")]
        public List<long> MsgIds { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InvokeAfterMsgs(List<long> msgIds, IObject query)
        {
            MsgIds = msgIds;
            Query = query;
        }
#nullable disable

        internal InvokeAfterMsgs()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(MsgIds, false);
            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

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
            var tryquery = reader.ReadObject<IObject>();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "invokeAfterMsgs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InvokeAfterMsgs();
            newClonedObject.MsgIds = new List<long>();
            foreach (var msgIds in MsgIds)
            {
                newClonedObject.MsgIds.Add(msgIds);
            }

            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InvokeAfterMsgs castedOther)
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

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}