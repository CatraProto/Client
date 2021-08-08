using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class AnswerWebhookJSONQuery : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -434028723; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("data")]
		public DataJSONBase Data { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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