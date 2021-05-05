using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetEncryptedTyping : IMethod<bool>
	{


        public static int ConstructorId { get; } = 2031374829;

		public Type Type { get; init; } = typeof(SetEncryptedTyping);
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