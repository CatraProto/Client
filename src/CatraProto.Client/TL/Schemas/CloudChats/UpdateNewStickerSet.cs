using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewStickerSet : UpdateBase
	{


        public static int StaticConstructorId { get => 1753886890; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("stickerset")]
		public Messages.StickerSetBase Stickerset { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);

		}

		public override void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<Messages.StickerSetBase>();

		}
	}
}