using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AutoDownloadSettings : AutoDownloadSettingsBase
	{


        public static int StaticConstructorId { get => 1674235686; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("low")]
		public override CloudChats.AutoDownloadSettingsBase Low { get; set; }

[JsonPropertyName("medium")]
		public override CloudChats.AutoDownloadSettingsBase Medium { get; set; }

[JsonPropertyName("high")]
		public override CloudChats.AutoDownloadSettingsBase High { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Low);
			writer.Write(Medium);
			writer.Write(High);

		}

		public override void Deserialize(Reader reader)
		{
			Low = reader.Read<CloudChats.AutoDownloadSettingsBase>();
			Medium = reader.Read<CloudChats.AutoDownloadSettingsBase>();
			High = reader.Read<CloudChats.AutoDownloadSettingsBase>();
		}

		public override string ToString()
		{
			return "account.autoDownloadSettings";
		}
	}
}