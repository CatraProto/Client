using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class GzipPacked : IMethod<IObject>
	{


        public static int ConstructorId { get; } = 812830625;

		public Type Type { get; init; } = typeof(GzipPacked);
		public bool IsVector { get; init; } = false;
		public byte[] PackedData { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PackedData);

		}

		public void Deserialize(Reader reader)
		{
			PackedData = reader.Read<byte[]>();

		}
	}
}