using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionOk : IMethod<DestroySessionResBase>
	{


        public static int ConstructorId { get; } = -501201412;

		public Type Type { get; init; } = typeof(DestroySessionOk);
		public bool IsVector { get; init; } = false;
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