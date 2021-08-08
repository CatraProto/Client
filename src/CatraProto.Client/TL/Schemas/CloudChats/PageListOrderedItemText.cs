using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListOrderedItemText : PageListOrderedItemBase
	{


        public static int StaticConstructorId { get => 1577484359; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("num")]
		public override string Num { get; set; }

[JsonPropertyName("text")]
		public RichTextBase Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Num = reader.Read<string>();
			Text = reader.Read<RichTextBase>();

		}
	}
}