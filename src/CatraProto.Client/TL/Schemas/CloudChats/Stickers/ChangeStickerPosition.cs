using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class ChangeStickerPosition : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -4795190; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }

[JsonPropertyName("position")]
		public int Position { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sticker);
			writer.Write(Position);

		}

		public void Deserialize(Reader reader)
		{
			Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			Position = reader.Read<int>();

		}
	}
}