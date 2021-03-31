using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class RemoveStickerFromSet : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>
	{


        public static int ConstructorId { get; } = -143257775;

		public InputDocumentBase Sticker { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sticker);

		}

		public void Deserialize(Reader reader)
		{
			Sticker = reader.Read<InputDocumentBase>();

		}
	}
}