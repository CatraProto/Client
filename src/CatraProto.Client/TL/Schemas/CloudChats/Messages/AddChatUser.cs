using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AddChatUser : IMethod<UpdatesBase>
	{


        public static int ConstructorId { get; } = -106911223;

		public Type Type { get; init; } = typeof(AddChatUser);
		public bool IsVector { get; init; } = false;
		public int ChatId { get; set; }
		public InputUserBase UserId { get; set; }
		public int FwdLimit { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(FwdLimit);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();
			FwdLimit = reader.Read<int>();

		}
	}
}