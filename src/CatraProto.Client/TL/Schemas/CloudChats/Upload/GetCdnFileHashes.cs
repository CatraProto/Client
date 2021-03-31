using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetCdnFileHashes : IMethod<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>
	{


        public static int ConstructorId { get; } = 1302676017;

		public byte[] FileToken { get; set; }
		public int Offset { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			Offset = reader.Read<int>();

		}
	}
}