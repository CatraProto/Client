using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsPercentValue : StatsPercentValueBase
	{


        public static int ConstructorId { get; } = -875679776;
		public override double Part { get; set; }
		public override double Total { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Part);
			writer.Write(Total);

		}

		public override void Deserialize(Reader reader)
		{
			Part = reader.Read<double>();
			Total = reader.Read<double>();

		}
	}
}