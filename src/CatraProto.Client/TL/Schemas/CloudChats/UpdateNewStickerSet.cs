using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewStickerSet : UpdateBase
	{


        public static int ConstructorId { get; } = 1753886890;
		public CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase Stickerset { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);

		}

		public override void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();

		}
	}
}