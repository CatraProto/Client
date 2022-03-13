using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputUserFromMessage : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
	{


        public static int StaticConstructorId { get => 497305826; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public InputUserFromMessage (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int msgId,long userId)
{
 Peer = peer;
MsgId = msgId;
UserId = userId;
 
}
#nullable disable
        internal InputUserFromMessage() 
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
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			MsgId = reader.Read<int>();
			UserId = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputUserFromMessage";
		}
	}
}