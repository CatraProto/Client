using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCall : UpdateBase
	{
		public static int ConstructorId { get; } = -1425052898;
		public PhoneCallBase PhoneCall { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PhoneCall);
		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall = reader.Read<PhoneCallBase>();
		}
	}
}