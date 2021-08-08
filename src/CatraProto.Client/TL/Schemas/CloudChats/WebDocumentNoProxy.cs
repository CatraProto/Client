using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebDocumentNoProxy : WebDocumentBase
	{


        public static int StaticConstructorId { get => -104284986; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("size")]
		public override int Size { get; set; }

[JsonPropertyName("mime_type")]
		public override string MimeType { get; set; }

[JsonPropertyName("attributes")]
		public override IList<DocumentAttributeBase> Attributes { get; set; }

        
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
			Attributes = reader.ReadVector<DocumentAttributeBase>();

		}
	}
}