using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatPhoto : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = -900957736;

		public int ChatId { get; set; }
		public InputChatPhotoBase Photo { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Photo);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			Photo = reader.Read<InputChatPhotoBase>();

		}
	}
}