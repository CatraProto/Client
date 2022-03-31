using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateNotifySettings : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2067899501; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase Settings { get; set; }

        
        #nullable enable
 public UpdateNotifySettings (CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase settings)
{
 Peer = peer;
Settings = settings;
 
}
#nullable disable
                
        internal UpdateNotifySettings() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase>();

		}

		public override string ToString()
		{
		    return "account.updateNotifySettings";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}