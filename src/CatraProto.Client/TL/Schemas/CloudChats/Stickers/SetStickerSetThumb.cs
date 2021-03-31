using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class SetStickerSetThumb : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>
	{


        public static int ConstructorId { get; } = -1707717072;

		public InputStickerSetBase Stickerset { get; set; }
		public InputDocumentBase Thumb { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Thumb);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();
			Thumb = reader.Read<InputDocumentBase>();

		}
	}
}