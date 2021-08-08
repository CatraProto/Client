using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportLoginToken : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1313598185; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(LoginTokenBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("api_id")]
		public int ApiId { get; set; }

[JsonPropertyName("api_hash")]
		public string ApiHash { get; set; }

[JsonPropertyName("except_ids")]
		public IList<int> ExceptIds { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(ExceptIds);

		}

		public void Deserialize(Reader reader)
		{
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			ExceptIds = reader.ReadVector<int>();

		}
	}
}