using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetOldFeaturedStickers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>
	{


        public static int ConstructorId { get; } = 1608974939;

		public int Offset { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}