using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerDroppedRunning : IMethod<CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase>
	{


        public static int ConstructorId { get; } = -847714938;


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