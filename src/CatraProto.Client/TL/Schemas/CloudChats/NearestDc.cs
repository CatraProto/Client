using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class NearestDc : NearestDcBase
	{


        public static int ConstructorId { get; } = -1910892683;
		public override string Country { get; set; }
		public override int ThisDc { get; set; }
		public override int NearestDc_ { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Country);
			writer.Write(ThisDc);
			writer.Write(NearestDc_);

		}

		public override void Deserialize(Reader reader)
		{
			Country = reader.Read<string>();
			ThisDc = reader.Read<int>();
			NearestDc_ = reader.Read<int>();

		}
	}
}