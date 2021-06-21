using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class BankCardData : BankCardDataBase
	{


        public static int ConstructorId { get; } = 1042605427;
		public override string Title { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(OpenUrls);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
			OpenUrls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>();

		}
	}
}