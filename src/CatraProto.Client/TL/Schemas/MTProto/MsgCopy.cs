using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgCopy : IMethod<MessageCopyBase>
	{


        public static int ConstructorId { get; } = -530561358;

		public Type Type { get; init; } = typeof(MsgCopy);
		public bool IsVector { get; init; } = false;
		public MessageBase OrigMessage { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(OrigMessage);

		}

		public void Deserialize(Reader reader)
		{
			OrigMessage = reader.Read<MessageBase>();

		}
	}
}