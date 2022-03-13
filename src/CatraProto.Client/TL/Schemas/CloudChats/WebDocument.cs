using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebDocument : CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase
	{


        public static int StaticConstructorId { get => 475467473; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public sealed override int Size { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public sealed override string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("attributes")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


        #nullable enable
 public WebDocument (string url,long accessHash,int size,string mimeType,IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
{
 Url = url;
AccessHash = accessHash;
Size = size;
MimeType = mimeType;
Attributes = attributes;
 
}
#nullable disable
        internal WebDocument() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(AccessHash);
			writer.Write(Size);
			writer.Write(MimeType);
			writer.Write(Attributes);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			MimeType = reader.Read<string>();
			Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();

		}
				
		public override string ToString()
		{
		    return "webDocument";
		}
	}
}