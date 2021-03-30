using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetState : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>
	{


        public static int ConstructorId { get; } = -304838614;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}