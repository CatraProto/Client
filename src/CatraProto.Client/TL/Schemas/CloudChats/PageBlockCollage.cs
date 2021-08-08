using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockCollage : PageBlockBase
	{


        public static int StaticConstructorId { get => 1705048653; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("items")]
		public IList<PageBlockBase> Items { get; set; }

[JsonPropertyName("caption")]
		public PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<PageBlockBase>();
			Caption = reader.Read<PageCaptionBase>();

		}
	}
}