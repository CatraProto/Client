using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatAdmin : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1444503762;

		public int ChatId { get; set; }
		public InputUserBase UserId { get; set; }
		public bool IsAdmin { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(IsAdmin);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();
			IsAdmin = reader.Read<bool>();

		}
	}
}