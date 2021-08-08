using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageUploadDocumentAction : SendMessageActionBase
	{


        public static int StaticConstructorId { get => -1441998364; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("progress")]
		public int Progress { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Progress);

		}

		public override void Deserialize(Reader reader)
		{
			Progress = reader.Read<int>();

		}
	}
}