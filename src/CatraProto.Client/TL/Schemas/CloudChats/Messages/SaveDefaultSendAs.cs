using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SaveDefaultSendAs : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -855777386; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("send_as")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }

        
        #nullable enable
 public SaveDefaultSendAs (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase sendAs)
{
 Peer = peer;
SendAs = sendAs;
 
}
#nullable disable
                
        internal SaveDefaultSendAs() 
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
var checksendAs = 			writer.WriteObject(SendAs);
if(checksendAs.IsError){
 return checksendAs; 
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
			var trysendAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trysendAs.IsError){
return ReadResult<IObject>.Move(trysendAs);
}
SendAs = trysendAs.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.saveDefaultSendAs";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}