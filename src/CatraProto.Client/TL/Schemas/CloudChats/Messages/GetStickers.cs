using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetStickers : IMethod
	{


        public static int ConstructorId { get; } = 71126828;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers);
		public bool IsVector { get; init; } = false;
		public string Emoticon { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Emoticon);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}