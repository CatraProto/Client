using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventActionBase
	{


        public static int ConstructorId { get; } = -1312568665;
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase PrevStickerset { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase NewStickerset { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevStickerset);
			writer.Write(NewStickerset);

		}

		public override void Deserialize(Reader reader)
		{
			PrevStickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			NewStickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();

		}
	}
}