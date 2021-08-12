using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFilterSuggested : DialogFilterSuggestedBase
	{


        public static int StaticConstructorId { get => 2004110666; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("filter")]
		public override DialogFilterBase Filter { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Filter);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Filter = reader.Read<DialogFilterBase>();
			Description = reader.Read<string>();
		}

		public override string ToString()
		{
			return "dialogFilterSuggested";
		}
	}
}