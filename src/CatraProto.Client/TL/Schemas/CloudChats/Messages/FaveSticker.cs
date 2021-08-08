using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FaveSticker : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1174420133; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
		public InputDocumentBase Id { get; set; }

[JsonPropertyName("unfave")]
		public bool Unfave { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Unfave);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputDocumentBase>();
			Unfave = reader.Read<bool>();

		}
	}
}