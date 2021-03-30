using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalts : IMethod<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>
	{


        public static int ConstructorId { get; } = -1370486635;

		public long ReqMsgId { get; set; }
		public int Now { get; set; }
		public IList<FutureSaltBase> Salts { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Now);
			writer.Write(Salts);

		}

		public void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Now = reader.Read<int>();
			Salts = reader.ReadVector<FutureSaltBase>();

		}
	}
}