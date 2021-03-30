using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class Photo : PhotoBase
	{


        public static int ConstructorId { get; } = 539045032;
		public override PhotoBase PPhoto { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PPhoto);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PPhoto = reader.Read<PhotoBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}