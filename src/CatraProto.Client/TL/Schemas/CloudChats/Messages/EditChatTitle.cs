using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatTitle : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = -599447467;

		public int ChatId { get; set; }
		public string Title { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Title);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			Title = reader.Read<string>();

		}
	}
}