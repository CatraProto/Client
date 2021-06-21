using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionBotAllowed : MessageActionBase
	{
		public static int ConstructorId { get; } = -1410748418;
		public string Domain { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Domain);
		}

		public override void Deserialize(Reader reader)
		{
			Domain = reader.Read<string>();
		}
	}
}