using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockChannel : PageBlockBase
	{


        public static int StaticConstructorId { get => -283684427; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel")]
		public ChatBase Channel { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);

		}

		public override void Deserialize(Reader reader)
		{
			Channel = reader.Read<ChatBase>();

		}
	}
}