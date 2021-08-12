using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionBotAllowed : MessageActionBase
	{


        public static int StaticConstructorId { get => -1410748418; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("domain")]
		public string Domain { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Domain);

		}

		public override void Deserialize(Reader reader)
		{
			Domain = reader.Read<string>();
		}

		public override string ToString()
		{
			return "messageActionBotAllowed";
		}
	}
}