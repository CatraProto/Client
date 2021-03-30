using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetUsers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UserBase>
	{


        public static int ConstructorId { get; } = 227648840;

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