using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class GetUserPhotos : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1848823128; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(PhotosBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("user_id")]
		public InputUserBase UserId { get; set; }

[JsonPropertyName("offset")]
		public int Offset { get; set; }

[JsonPropertyName("max_id")]
		public long MaxId { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Offset);
			writer.Write(MaxId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();
			Offset = reader.Read<int>();
			MaxId = reader.Read<long>();
			Limit = reader.Read<int>();

		}
	}
}