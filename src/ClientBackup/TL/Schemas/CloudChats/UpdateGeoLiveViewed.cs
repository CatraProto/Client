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
	public partial class UpdateGeoLiveViewed : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2027964103; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }


        #nullable enable
 public UpdateGeoLiveViewed (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int msgId)
{
 Peer = peer;
MsgId = msgId;
 
}
#nullable disable
        internal UpdateGeoLiveViewed() 
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
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateGeoLiveViewed";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}