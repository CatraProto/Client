using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWebDocument : InputWebDocumentBase
	{


        public static int ConstructorId { get; } = -1678949555;
		public override string Url { get; set; }
		public override int Size { get; set; }
		public override string MimeType { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Size);
			writer.Write(MimeType);
			writer.Write(Attributes);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Size = reader.Read<int>();
			MimeType = reader.Read<string>();
			Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();

		}
	}
}