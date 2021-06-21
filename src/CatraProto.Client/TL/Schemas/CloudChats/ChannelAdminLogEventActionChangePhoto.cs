using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = 1129042607;
		public PhotoBase PrevPhoto { get; set; }
		public PhotoBase NewPhoto { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevPhoto);
			writer.Write(NewPhoto);
		}

		public override void Deserialize(Reader reader)
		{
			PrevPhoto = reader.Read<PhotoBase>();
			NewPhoto = reader.Read<PhotoBase>();
		}
	}
}