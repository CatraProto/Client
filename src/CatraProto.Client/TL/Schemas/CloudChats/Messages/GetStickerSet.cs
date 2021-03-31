using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetStickerSet : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>
	{


        public static int ConstructorId { get; } = 639215886;

		public InputStickerSetBase Stickerset { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();

		}
	}
}