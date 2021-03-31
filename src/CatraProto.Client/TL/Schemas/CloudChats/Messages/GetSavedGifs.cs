using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSavedGifs : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>
	{


        public static int ConstructorId { get; } = -2084618926;

		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();

		}
	}
}