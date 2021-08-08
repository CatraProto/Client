using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFileReuploadNeeded : CdnFileBase
	{


        public static int StaticConstructorId { get => -290921362; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("request_token")]
		public byte[] RequestToken { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(RequestToken);

		}

		public override void Deserialize(Reader reader)
		{
			RequestToken = reader.Read<byte[]>();

		}
	}
}