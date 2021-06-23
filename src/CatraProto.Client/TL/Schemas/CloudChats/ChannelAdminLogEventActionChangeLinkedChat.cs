using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = -1569748965;
		public int PrevValue { get; set; }
		public int NewValue { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PrevValue);
			writer.Write(NewValue);
		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<int>();
			NewValue = reader.Read<int>();
		}
	}
}