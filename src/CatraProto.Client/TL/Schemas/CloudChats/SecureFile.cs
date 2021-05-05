using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureFile : SecureFileBase
	{


        public static int ConstructorId { get; } = -534283678;
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public int Size { get; set; }
		public int DcId { get; set; }
		public int Date { get; set; }
		public byte[] FileHash { get; set; }
		public byte[] Secret { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Size);
			writer.Write(DcId);
			writer.Write(Date);
			writer.Write(FileHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			Date = reader.Read<int>();
			FileHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();

		}
	}
}