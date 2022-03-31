using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class PeerSettings : CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1753266509; }
        
[Newtonsoft.Json.JsonProperty("settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public PeerSettings (CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase settings,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Settings = settings;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal PeerSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Settings);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "messages.peerSettings";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}