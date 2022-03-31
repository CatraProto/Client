using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SendAsPeers : CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2091463255; }
        
[Newtonsoft.Json.JsonProperty("peers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Peers { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public SendAsPeers (IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> peers,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Peers = peers;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal SendAsPeers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peers);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "channels.sendAsPeers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}