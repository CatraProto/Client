using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockCover : PageBlockBase
	{


        public static int StaticConstructorId { get => 972174080; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("cover")]
		public PageBlockBase Cover { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Cover);

		}

		public override void Deserialize(Reader reader)
		{
			Cover = reader.Read<PageBlockBase>();

		}
	}
}