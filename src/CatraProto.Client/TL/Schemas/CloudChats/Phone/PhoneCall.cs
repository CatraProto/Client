using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : PhoneCallBase
	{
		public static int ConstructorId { get; } = -326966976;
		public override CloudChats.PhoneCallBase PhoneCall_ { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCall_);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall_ = reader.Read<CloudChats.PhoneCallBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}