using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessageReactions : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 357013699; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("reactions")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase Reactions { get; set; }


        #nullable enable
 public UpdateMessageReactions (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int msgId,CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase reactions)
{
 Peer = peer;
MsgId = msgId;
Reactions = reactions;
 
}
#nullable disable
        internal UpdateMessageReactions() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(Reactions);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			MsgId = reader.Read<int>();
			Reactions = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase>();

		}
				
		public override string ToString()
		{
		    return "updateMessageReactions";
		}
	}
}