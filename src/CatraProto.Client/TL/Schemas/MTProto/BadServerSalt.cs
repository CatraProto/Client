using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BadServerSalt : IMethod<BadMsgNotificationBase>
	{


        public static int ConstructorId { get; } = -307542917;

		public Type Type { get; init; } = typeof(BadServerSalt);
		public bool IsVector { get; init; } = false;
		public long BadMsgId { get; set; }
		public int BadMsgSeqno { get; set; }
		public int ErrorCode { get; set; }
		public long NewServerSalt { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BadMsgId);
			writer.Write(BadMsgSeqno);
			writer.Write(ErrorCode);
			writer.Write(NewServerSalt);

		}

		public void Deserialize(Reader reader)
		{
			BadMsgId = reader.Read<long>();
			BadMsgSeqno = reader.Read<int>();
			ErrorCode = reader.Read<int>();
			NewServerSalt = reader.Read<long>();

		}
	}
}