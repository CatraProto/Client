using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateEncryption : UpdateBase
	{


        public static int ConstructorId { get; } = -1264392051;
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase Chat { get; set; }
		public int Date { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
			Date = reader.Read<int>();

		}
	}
}