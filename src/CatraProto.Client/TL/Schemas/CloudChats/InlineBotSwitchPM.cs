using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InlineBotSwitchPM : InlineBotSwitchPMBase
	{
		public static int ConstructorId { get; } = 1008755359;
		public override string Text { get; set; }
		public override string StartParam { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Text);
			writer.Write(StartParam);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			StartParam = reader.Read<string>();
		}
	}
}