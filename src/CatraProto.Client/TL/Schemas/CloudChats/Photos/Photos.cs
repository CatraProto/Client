using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class OPhotos : PhotosBase
	{


        public static int ConstructorId { get; } = -1916114267;
		public override IList<PhotoBase> Photos { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photos);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Photos = reader.ReadVector<PhotoBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}