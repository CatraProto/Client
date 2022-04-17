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
	public partial class HidePeerSettingsBar : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1336717624; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        
        #nullable enable
 public HidePeerSettingsBar (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
{
 Peer = peer;
 
}
#nullable disable
                
        internal HidePeerSettingsBar() 
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
		    return "messages.hidePeerSettingsBar";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}