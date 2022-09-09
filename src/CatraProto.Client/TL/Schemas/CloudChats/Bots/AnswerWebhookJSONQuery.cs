using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class AnswerWebhookJSONQuery : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -434028723; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


#nullable enable
        public AnswerWebhookJSONQuery(long queryId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
        {
            QueryId = queryId;
            Data = data;
        }
#nullable disable

        internal AnswerWebhookJSONQuery()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(QueryId);
            var checkdata = writer.WriteObject(Data);
            if (checkdata.IsError)
            {
                return checkdata;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bots.answerWebhookJSONQuery";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AnswerWebhookJSONQuery();
            newClonedObject.QueryId = QueryId;
            var cloneData = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Data.Clone();
            if (cloneData is null)
            {
                return null;
            }

            newClonedObject.Data = cloneData;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AnswerWebhookJSONQuery castedOther)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (Data.Compare(castedOther.Data))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}