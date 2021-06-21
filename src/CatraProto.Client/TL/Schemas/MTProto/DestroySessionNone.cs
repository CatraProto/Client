using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionNone : DestroySessionResBase
	{
		public static int ConstructorId { get; } = 1658015945;
		public override long SessionId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SessionId);
		}

		public override void Deserialize(Reader reader)
		{
			SessionId = reader.Read<long>();
		}
	}
}