using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class Photo : PhotoBase
	{


        public static int ConstructorId { get; } = 539045032;
		public override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo_ { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photo_);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Photo_ = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}