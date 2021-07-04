using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteChatUser : IMethod
	{


        public static int ConstructorId { get; } = -530505962;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);
		public bool IsVector { get; init; } = false;
		public int ChatId { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

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
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
	}
}