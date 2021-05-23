using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class WallPapers : WallPapersBase
	{


        public static int ConstructorId { get; } = 1881892265;
		public int Hash { get; set; }
		public IList<WallPaperBase> Wallpapers { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Wallpapers);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Wallpapers = reader.ReadVector<WallPaperBase>();

		}
	}
}