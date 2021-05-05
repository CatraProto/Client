using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAllInfo : IMethod<MsgsAllInfoBase>
	{


        public static int ConstructorId { get; } = -1933520591;

		public Type Type { get; init; } = typeof(MsgsAllInfo);
		public bool IsVector { get; init; } = false;
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