using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SaveAppLog : IMethod
	{


        public static int ConstructorId { get; } = 1862465352;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> Events { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Events);

		}

		public void Deserialize(Reader reader)
		{
			Events = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase>();

		}
	}
}