using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateReq : IMethod
	{


        public static int ConstructorId { get; } = -630588590;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq);
		public bool IsVector { get; init; } = false;
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