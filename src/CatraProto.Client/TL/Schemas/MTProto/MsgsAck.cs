using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAck : IMethod<CatraProto.Client.TL.Schemas.MTProto.MsgsAckBase>
	{


        public static int ConstructorId { get; } = 1658238041;

		public IList<long> MsgIds { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgIds);

		}

		public void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();

		}
	}
}