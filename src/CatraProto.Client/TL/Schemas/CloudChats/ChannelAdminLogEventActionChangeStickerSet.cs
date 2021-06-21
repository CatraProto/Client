using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = -1312568665;
		public InputStickerSetBase PrevStickerset { get; set; }
		public InputStickerSetBase NewStickerset { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevStickerset);
			writer.Write(NewStickerset);
		}

		public override void Deserialize(Reader reader)
		{
			PrevStickerset = reader.Read<InputStickerSetBase>();
			NewStickerset = reader.Read<InputStickerSetBase>();
		}
	}
}