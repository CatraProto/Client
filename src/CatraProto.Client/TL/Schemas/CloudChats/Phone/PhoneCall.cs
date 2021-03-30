using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : PhoneCallBase
	{


        public static int ConstructorId { get; } = -326966976;
		public override PhoneCallBase PPhoneCall { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PPhoneCall);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PPhoneCall = reader.Read<PhoneCallBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}