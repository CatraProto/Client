using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = 648939889;
		public bool NewValue { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(NewValue);
		}

		public override void Deserialize(Reader reader)
		{
			NewValue = reader.Read<bool>();
		}
	}
}