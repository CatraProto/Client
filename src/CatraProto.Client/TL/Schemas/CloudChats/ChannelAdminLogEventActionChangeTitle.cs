using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = -421545947;
		public string PrevValue { get; set; }
		public string NewValue { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevValue);
			writer.Write(NewValue);
		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<string>();
			NewValue = reader.Read<string>();
		}
	}
}