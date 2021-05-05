using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class AddStickerToSet : IMethod<Messages.StickerSetBase>
	{


        public static int ConstructorId { get; } = -2041315650;

		public Type Type { get; init; } = typeof(AddStickerToSet);
		public bool IsVector { get; init; } = false;
		public InputStickerSetBase Stickerset { get; set; }
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