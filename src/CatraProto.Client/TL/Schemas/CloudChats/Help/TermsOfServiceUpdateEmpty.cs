using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdateEmpty : TermsOfServiceUpdateBase
	{


        public static int ConstructorId { get; } = -483352705;
		public override int Expires { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
	}
}