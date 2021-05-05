using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UpdateProfilePhoto : IMethod<PhotoBase>
	{


        public static int ConstructorId { get; } = 1926525996;

		public Type Type { get; init; } = typeof(UpdateProfilePhoto);
		public bool IsVector { get; init; } = false;
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