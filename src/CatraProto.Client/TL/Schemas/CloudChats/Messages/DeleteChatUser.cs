using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteChatUser : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = -530505962;

		public int ChatId { get; set; }
		public InputUserBase UserId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();

		}
	}
}