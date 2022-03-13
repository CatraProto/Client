using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetGlobalPrivacySettings : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 517647042; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase Settings { get; set; }

        
        #nullable enable
 public SetGlobalPrivacySettings (CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase settings)
{
 Settings = settings;
 
}
#nullable disable
                
        internal SetGlobalPrivacySettings() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();

		}
		
		public override string ToString()
		{
		    return "account.setGlobalPrivacySettings";
		}
	}
}