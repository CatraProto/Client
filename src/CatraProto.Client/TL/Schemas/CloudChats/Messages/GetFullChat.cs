using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetFullChat : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>
	{


        public static int ConstructorId { get; } = 998448230;

		public int ChatId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();

		}
	}
}