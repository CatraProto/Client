using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdatePasswordSettings : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1516564433; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("password")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

[Newtonsoft.Json.JsonProperty("new_settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }

        
        #nullable enable
 public UpdatePasswordSettings (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password,CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings)
{
 Password = password;
NewSettings = newSettings;
 
}
#nullable disable
                
        internal UpdatePasswordSettings() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(NewSettings);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
			NewSettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();

		}
		
		public override string ToString()
		{
		    return "account.updatePasswordSettings";
		}
	}
}