using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class AnswerWebhookJSONQuery : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -434028723; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


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
            var newClonedObject = new AnswerWebhookJSONQuery
            {
                QueryId = QueryId
            };
            var cloneData = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Data.Clone();
            if (cloneData is null)
            {
                return null;
            }
            newClonedObject.Data = cloneData;
            return newClonedObject;

        }
#nullable disable
    }
}