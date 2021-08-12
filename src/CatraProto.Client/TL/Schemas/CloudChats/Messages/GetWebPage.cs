using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPage : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 852135825; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(WebPageBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Hash = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.getWebPage";
		}
	}
}