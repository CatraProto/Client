using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DhConfig : DhConfigBase
	{


        public static int ConstructorId { get; } = 740433629;
		public int G { get; set; }
		public byte[] P { get; set; }
		public int Version { get; set; }
		public override byte[] Random { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(G);
			writer.Write(P);
			writer.Write(Version);
			writer.Write(Random);

		}

		public override void Deserialize(Reader reader)
		{
			G = reader.Read<int>();
			P = reader.Read<byte[]>();
			Version = reader.Read<int>();
			Random = reader.Read<byte[]>();

		}
	}
}