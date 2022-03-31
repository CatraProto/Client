using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1995661875; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("low")]
		public bool Low { get; set; }

[Newtonsoft.Json.JsonProperty("high")]
		public bool High { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Settings { get; set; }

        
        #nullable enable
 public SaveAutoDownloadSettings (CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase settings)
{
 Settings = settings;
 
}
#nullable disable
                
        internal SaveAutoDownloadSettings() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Low ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = High ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override string ToString()
		{
		    return "account.saveAutoDownloadSettings";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}