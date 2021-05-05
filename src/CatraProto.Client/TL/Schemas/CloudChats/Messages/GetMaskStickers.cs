using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetMaskStickers : IMethod<AllStickersBase>
	{


        public static int ConstructorId { get; } = 1706608543;

		public Type Type { get; init; } = typeof(GetMaskStickers);
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