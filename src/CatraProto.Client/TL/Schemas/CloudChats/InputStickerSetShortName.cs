using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetShortName : InputStickerSetBase
	{


        public static int StaticConstructorId { get => -2044933984; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("short_name")]
		public string ShortName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			ShortName = reader.Read<string>();

		}
	}
}