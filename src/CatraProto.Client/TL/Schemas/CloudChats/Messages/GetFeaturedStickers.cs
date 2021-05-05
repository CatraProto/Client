using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetFeaturedStickers : IMethod<FeaturedStickersBase>
	{


        public static int ConstructorId { get; } = 766298703;

		public Type Type { get; init; } = typeof(GetFeaturedStickers);
		public bool IsVector { get; init; } = false;
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