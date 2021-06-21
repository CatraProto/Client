using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetUsers : IMethod
	{


        public static int ConstructorId { get; } = 227648840;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UserBase);
		public bool IsVector { get; init; } = false;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Id { get; set; }

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
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
	}
}