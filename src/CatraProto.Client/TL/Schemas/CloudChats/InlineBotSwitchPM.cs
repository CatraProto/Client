using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InlineBotSwitchPM : InlineBotSwitchPMBase
	{


        public static int StaticConstructorId { get => 1008755359; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("start_param")]
		public override string StartParam { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(StartParam);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			StartParam = reader.Read<string>();
		}

		public override string ToString()
		{
			return "inlineBotSwitchPM";
		}
	}
}