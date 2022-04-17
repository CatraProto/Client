using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetSendAs : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 231174382; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        
        #nullable enable
 public GetSendAs (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
{
 Peer = peer;
 
}
#nullable disable
                
        internal GetSendAs() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "channels.getSendAs";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}