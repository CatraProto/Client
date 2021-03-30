using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UpdateProfilePhoto : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>
	{


        public static int ConstructorId { get; } = 1926525996;

		public InputPhotoBase Id { get; set; }

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
			Id = reader.Read<InputPhotoBase>();

		}
	}
}