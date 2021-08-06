using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetOldFeaturedStickers : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1608974939; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("offset")]
		public int Offset { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}