using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class AnswerWebhookJSONQuery : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -434028723;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("query_id")] public long QueryId { get; set; }

        [JsonProperty("data")] public DataJSONBase Data { get; set; }

        public override string ToString()
        {
            return "bots.answerWebhookJSONQuery";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(QueryId);
            writer.Write(Data);
        }

        public void Deserialize(Reader reader)
        {
            QueryId = reader.Read<long>();
            Data = reader.Read<DataJSONBase>();
        }
    }
}