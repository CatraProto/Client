using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerDroppedRunning : IMethod
	{


        public static int ConstructorId { get; } = -847714938;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDroppedRunning);
		public bool IsVector { get; init; } = false;

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