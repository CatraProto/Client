using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputAppEvent : InputAppEventBase
	{
		public static int ConstructorId { get; } = 488313413;
		public override double Time { get; set; }
		public override string Type { get; set; }
		public override long Peer { get; set; }
		public override JSONValueBase Data { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Time);
			writer.Write(Type);
			writer.Write(Peer);
			writer.Write(Data);
		}

		public override void Deserialize(Reader reader)
		{
			Time = reader.Read<double>();
			Type = reader.Read<string>();
			Peer = reader.Read<long>();
			Data = reader.Read<JSONValueBase>();
		}
	}
}