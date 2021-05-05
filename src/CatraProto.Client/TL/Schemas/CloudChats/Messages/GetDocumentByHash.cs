using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDocumentByHash : IMethod<DocumentBase>
	{


        public static int ConstructorId { get; } = 864953444;

		public Type Type { get; init; } = typeof(GetDocumentByHash);
		public bool IsVector { get; init; } = false;
		public byte[] Sha256 { get; set; }
		public int Size { get; set; }
		public string MimeType { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sha256);
			writer.Write(Size);
			writer.Write(MimeType);

		}

		public void Deserialize(Reader reader)
		{
			Sha256 = reader.Read<byte[]>();
			Size = reader.Read<int>();
			MimeType = reader.Read<string>();

		}
	}
}