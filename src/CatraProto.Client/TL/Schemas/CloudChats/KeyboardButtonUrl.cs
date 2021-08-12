using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrl : KeyboardButtonBase
	{


        public static int StaticConstructorId { get => 629866245; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			Url = reader.Read<string>();
		}

		public override string ToString()
		{
			return "keyboardButtonUrl";
		}
	}
}