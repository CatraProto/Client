using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessageReactions : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 357013699; }
        
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}
writer.WriteInt32(MsgId);
var checkreactions = 			writer.WriteObject(Reactions);
if(checkreactions.IsError){
 return checkreactions; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var trymsgId = reader.ReadInt32();
if(trymsgId.IsError){
return ReadResult<IObject>.Move(trymsgId);
}
MsgId = trymsgId.Value;
			var tryreactions = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase>();
if(tryreactions.IsError){
return ReadResult<IObject>.Move(tryreactions);
}
Reactions = tryreactions.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateMessageReactions";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}