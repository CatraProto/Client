using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class PPhotos : PhotosBase
	{
		public static int ConstructorId { get; } = -1916114267;
		public override IList<CloudChats.PhotoBase> Photos { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photos);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Photos = reader.ReadVector<CloudChats.PhotoBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}