using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockOrderedList : PageBlockBase
	{


        public static int StaticConstructorId { get => -1702174239; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("items")]
		public IList<PageListOrderedItemBase> Items { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<PageListOrderedItemBase>();
		}

		public override string ToString()
		{
			return "pageBlockOrderedList";
		}
	}
}