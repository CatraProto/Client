using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySession : IMethod<CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase>
	{


        public static int ConstructorId { get; } = -414113498;

		public long SessionId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SessionId);

		}

		public void Deserialize(Reader reader)
		{
			SessionId = reader.Read<long>();

		}
	}
}