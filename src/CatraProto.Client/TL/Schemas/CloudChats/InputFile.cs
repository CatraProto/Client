using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFile : InputFileBase
	{


        public static int ConstructorId { get; } = -181407105;
		public override long Id { get; set; }
		public override int Parts { get; set; }
		public override string Name { get; set; }
		public string Md5Checksum { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Name);
			writer.Write(Md5Checksum);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Name = reader.Read<string>();
			Md5Checksum = reader.Read<string>();

		}
	}
}