using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class DeletePhotos : IMethod
	{


        public static int ConstructorId { get; } = -2016444625;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Photos.DeletePhotos);
		public bool IsVector { get; init; } = false;
		public IList<InputPhotoBase> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<InputPhotoBase>();

		}
	}
}