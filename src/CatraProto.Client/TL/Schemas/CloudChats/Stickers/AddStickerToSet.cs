using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class AddStickerToSet : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2041315650; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(Messages.StickerSetBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("stickerset")]
		public InputStickerSetBase Stickerset { get; set; }

[JsonPropertyName("sticker")]
		public InputStickerSetItemBase Sticker { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Sticker);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();
			Sticker = reader.Read<InputStickerSetItemBase>();

		}
	}
}