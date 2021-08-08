using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SaveGif : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 846868683; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
		public InputDocumentBase Id { get; set; }

[JsonPropertyName("unsave")]
		public bool Unsave { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputDocumentBase>();
			Unsave = reader.Read<bool>();

		}
	}
}