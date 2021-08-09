using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetStickers : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 71126828; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(StickersBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("emoticon")]
		public string Emoticon { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Emoticon);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}