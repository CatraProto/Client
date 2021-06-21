using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Stickers : StickersBase
	{


        public static int ConstructorId { get; } = -463889475;
		public int Hash { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers_ { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Stickers_);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Stickers_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}