using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AddChatUser : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = -106911223;

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