using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNotifySettings : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1094555409; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }


        #nullable enable
 public UpdateNotifySettings (CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings)
{
 Peer = peer;
NotifySettings = notifySettings;
 
}
#nullable disable
        internal UpdateNotifySettings() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(NotifySettings);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase>();
			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();

		}
				
		public override string ToString()
		{
		    return "updateNotifySettings";
		}
	}
}