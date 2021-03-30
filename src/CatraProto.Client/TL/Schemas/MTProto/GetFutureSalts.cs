using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class GetFutureSalts : IMethod<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>
	{


        public static int ConstructorId { get; } = -1188971260;

		public int Num { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);

		}

		public void Deserialize(Reader reader)
		{
			Num = reader.Read<int>();

		}
	}
}