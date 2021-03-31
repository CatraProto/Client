using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DiscardEncryption : IMethod<bool>
	{


        public static int ConstructorId { get; } = -304536635;

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