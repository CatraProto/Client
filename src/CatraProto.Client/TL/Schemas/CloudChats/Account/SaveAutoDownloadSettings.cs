using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveAutoDownloadSettings : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Low = 1 << 0,
			High = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1995661875; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("low")]
		public bool Low { get; set; }

[JsonPropertyName("high")]
		public bool High { get; set; }

[JsonPropertyName("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{
			Flags = Low ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = High ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Low = FlagsHelper.IsFlagSet(Flags, 0);
			High = FlagsHelper.IsFlagSet(Flags, 1);
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();

		}
	}
}