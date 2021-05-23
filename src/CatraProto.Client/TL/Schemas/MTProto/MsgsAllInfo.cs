using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAllInfo : IMethod
	{


        public static int ConstructorId { get; } = -1933520591;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfo);
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