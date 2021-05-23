using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetAllChats : IMethod
	{


        public static int ConstructorId { get; } = -341307408;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllChats);
		public bool IsVector { get; init; } = false;
		public IList<int> ExceptIds { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ExceptIds);

		}

		public void Deserialize(Reader reader)
		{
			ExceptIds = reader.ReadVector<int>();

		}
	}
}