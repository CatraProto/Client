using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionNone : IMethod<DestroySessionResBase>
	{


        public static int ConstructorId { get; } = 1658015945;

		public Type Type { get; init; } = typeof(DestroySessionNone);
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