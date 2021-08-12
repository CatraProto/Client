using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyInlineMarkup : ReplyMarkupBase
	{


        public static int StaticConstructorId { get => 1218642516; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("rows")]
		public IList<KeyboardButtonRowBase> Rows { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Rows);

		}

		public override void Deserialize(Reader reader)
		{
			Rows = reader.ReadVector<KeyboardButtonRowBase>();
		}

		public override string ToString()
		{
			return "replyInlineMarkup";
		}
	}
}