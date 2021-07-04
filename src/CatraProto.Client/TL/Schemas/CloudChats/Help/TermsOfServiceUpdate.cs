using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Help;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdate : TermsOfServiceUpdateBase
	{


        public static int ConstructorId { get; } = 686618977;
		public override int Expires { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);
			writer.Write(TermsOfService);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
			TermsOfService = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();

		}
	}
}