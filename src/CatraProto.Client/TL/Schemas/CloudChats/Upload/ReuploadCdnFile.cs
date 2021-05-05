using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class ReuploadCdnFile : IMethod<FileHashBase>
	{


        public static int ConstructorId { get; } = -1691921240;

		public Type Type { get; init; } = typeof(ReuploadCdnFile);
		public bool IsVector { get; init; } = false;
		public byte[] FileToken { get; set; }
		public byte[] RequestToken { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(RequestToken);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			RequestToken = reader.Read<byte[]>();

		}
	}
}