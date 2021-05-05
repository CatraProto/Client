using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadFeaturedStickers : IMethod<bool>
	{


        public static int ConstructorId { get; } = 1527873830;

		public Type Type { get; init; } = typeof(ReadFeaturedStickers);
		public bool IsVector { get; init; } = false;
		public IList<long> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<long>();

		}
	}
}