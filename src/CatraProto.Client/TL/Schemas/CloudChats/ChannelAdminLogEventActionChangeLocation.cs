using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = 241923758;
		public ChannelLocationBase PrevValue { get; set; }
		public ChannelLocationBase NewValue { get; set; }

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
			PrevValue = reader.Read<ChannelLocationBase>();
			NewValue = reader.Read<ChannelLocationBase>();
		}
	}
}