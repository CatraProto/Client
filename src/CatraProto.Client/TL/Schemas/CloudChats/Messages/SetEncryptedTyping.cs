using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetEncryptedTyping : IMethod
	{


        public static int ConstructorId { get; } = 2031374829;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SetEncryptedTyping);
		public bool IsVector { get; init; } = false;
		public InputEncryptedChatBase Peer { get; set; }
		public bool Typing { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Typing);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputEncryptedChatBase>();
			Typing = reader.Read<bool>();

		}
	}
}