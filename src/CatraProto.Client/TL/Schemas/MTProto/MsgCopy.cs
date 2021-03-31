using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.MTProto;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgCopy : IMethod<CatraProto.Client.TL.Schemas.MTProto.MessageCopyBase>
	{


        public static int ConstructorId { get; } = -530561358;

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