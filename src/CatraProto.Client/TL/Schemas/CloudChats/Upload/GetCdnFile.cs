using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetCdnFile : IMethod<CdnFileBase>
	{


        public static int ConstructorId { get; } = 536919235;

		public Type Type { get; init; } = typeof(GetCdnFile);
		public bool IsVector { get; init; } = false;
		public byte[] FileToken { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}