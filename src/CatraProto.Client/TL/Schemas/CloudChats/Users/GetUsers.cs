using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetUsers : IMethod<UserBase>
	{


        public static int ConstructorId { get; } = 227648840;

		public Type Type { get; init; } = typeof(GetUsers);
		public bool IsVector { get; init; } = false;
		public IList<InputUserBase> Id { get; set; }

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
			Id = reader.ReadVector<InputUserBase>();

		}
	}
}