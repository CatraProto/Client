using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class DeletePhotos : IMethod<long>
	{


        public static int ConstructorId { get; } = -2016444625;

		public Type Type { get; init; } = typeof(DeletePhotos);
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