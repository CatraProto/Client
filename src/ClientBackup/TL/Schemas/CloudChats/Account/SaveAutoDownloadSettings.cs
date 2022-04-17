using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

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
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checksettings = 			writer.WriteObject(Settings);
if(checksettings.IsError){
 return checksettings; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Low = FlagsHelper.IsFlagSet(Flags, 0);
			High = FlagsHelper.IsFlagSet(Flags, 1);
			var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
if(trysettings.IsError){
return ReadResult<IObject>.Move(trysettings);
}
Settings = trysettings.Value;
return new ReadResult<IObject>(this);

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