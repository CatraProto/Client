using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateReq : IMethod<CatraProto.Client.TL.Schemas.MTProto.MsgsStateReqBase>
	{


        public static int ConstructorId { get; } = -630588590;

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