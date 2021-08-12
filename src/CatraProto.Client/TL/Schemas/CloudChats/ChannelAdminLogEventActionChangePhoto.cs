using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1129042607; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_photo")]
		public PhotoBase PrevPhoto { get; set; }

[JsonPropertyName("new_photo")]
		public PhotoBase NewPhoto { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevPhoto);
			writer.Write(NewPhoto);

		}

		public override void Deserialize(Reader reader)
		{
			PrevPhoto = reader.Read<PhotoBase>();
			NewPhoto = reader.Read<PhotoBase>();
		}

		public override string ToString()
		{
			return "channelAdminLogEventActionChangePhoto";
		}
	}
}