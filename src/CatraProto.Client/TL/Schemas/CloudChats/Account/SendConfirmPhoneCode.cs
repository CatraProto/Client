using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendConfirmPhoneCode : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 457157256; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("hash")]
		public string Hash { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }

        
        #nullable enable
 public SendConfirmPhoneCode (string hash,CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings)
{
 Hash = hash;
Settings = settings;
 
}
#nullable disable
                
        internal SendConfirmPhoneCode() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase>();

		}

		public override string ToString()
		{
		    return "account.sendConfirmPhoneCode";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}