using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : PhoneCallBase
	{


        public static int ConstructorId { get; } = -326966976;
		public override CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall_ { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCall_);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall_ = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}