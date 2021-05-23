using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnPublicKey : CdnPublicKeyBase
	{


        public static int ConstructorId { get; } = -914167110;
		public override int DcId { get; set; }
		public override string PublicKey { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(PublicKey);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			PublicKey = reader.Read<string>();

		}
	}
}