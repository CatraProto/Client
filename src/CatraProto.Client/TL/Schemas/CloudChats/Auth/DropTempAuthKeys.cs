using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class DropTempAuthKeys : IMethod
	{


        public static int ConstructorId { get; } = -1907842680;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.DropTempAuthKeys);
		public bool IsVector { get; init; } = false;
		public IList<long> ExceptAuthKeys { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ExceptAuthKeys);

		}

		public void Deserialize(Reader reader)
		{
			ExceptAuthKeys = reader.ReadVector<long>();

		}
	}
}