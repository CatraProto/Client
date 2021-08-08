using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -1312568665; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_stickerset")]
		public InputStickerSetBase PrevStickerset { get; set; }

[JsonPropertyName("new_stickerset")]
		public InputStickerSetBase NewStickerset { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevStickerset);
			writer.Write(NewStickerset);

		}

		public override void Deserialize(Reader reader)
		{
			PrevStickerset = reader.Read<InputStickerSetBase>();
			NewStickerset = reader.Read<InputStickerSetBase>();

		}
	}
}