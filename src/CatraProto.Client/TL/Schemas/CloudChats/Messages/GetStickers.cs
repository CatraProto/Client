using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetStickers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>
	{


        public static int ConstructorId { get; } = 71126828;

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