using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWebDocument : CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase
	{


        public static int StaticConstructorId { get => -1678949555; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public override int Size { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public override string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("attributes")]
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
				
		public override string ToString()
		{
		    return "inputWebDocument";
		}
	}
}