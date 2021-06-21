using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCallSignalingData : UpdateBase
	{
		public static int ConstructorId { get; } = 643940105;
		public long PhoneCallId { get; set; }
		public byte[] Data { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCallId);
			writer.Write(Data);
		}

		public override void Deserialize(Reader reader)
		{
			PhoneCallId = reader.Read<long>();
			Data = reader.Read<byte[]>();
		}
	}
}