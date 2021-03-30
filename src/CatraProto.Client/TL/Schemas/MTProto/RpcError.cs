using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcError : IMethod<CatraProto.Client.TL.Schemas.MTProto.RpcErrorBase>
	{


        public static int ConstructorId { get; } = 558156313;

		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ErrorCode);
			writer.Write(ErrorMessage);

		}

		public void Deserialize(Reader reader)
		{
			ErrorCode = reader.Read<int>();
			ErrorMessage = reader.Read<string>();

		}
	}
}