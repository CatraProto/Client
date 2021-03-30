using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAllInfo : IMethod<CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfoBase>
	{


        public static int ConstructorId { get; } = -1933520591;

		public IList<long> MsgIds { get; set; }
		public byte[] Info { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgIds);
			writer.Write(Info);

		}

		public void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();
			Info = reader.Read<byte[]>();

		}
	}
}