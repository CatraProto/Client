using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AutoDownloadSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase
	{


        public static int StaticConstructorId { get => 1674235686; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("low")]
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Low { get; set; }

[JsonPropertyName("medium")]
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Medium { get; set; }

[JsonPropertyName("high")]
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase High { get; set; }

        
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
			Low = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
			Medium = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
			High = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();

		}
	}
}