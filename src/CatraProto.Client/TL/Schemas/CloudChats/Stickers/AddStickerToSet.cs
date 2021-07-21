using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class AddStickerToSet : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2041315650; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

[JsonPropertyName("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase Sticker { get; set; }


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
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>();

		}
	}
}