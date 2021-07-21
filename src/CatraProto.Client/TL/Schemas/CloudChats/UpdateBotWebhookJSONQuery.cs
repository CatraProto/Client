using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotWebhookJSONQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1684914010; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }

[JsonPropertyName("timeout")]
		public int Timeout { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(QueryId);
			writer.Write(Data);
			writer.Write(Timeout);

		}

		public override void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			Timeout = reader.Read<int>();

		}
	}
}