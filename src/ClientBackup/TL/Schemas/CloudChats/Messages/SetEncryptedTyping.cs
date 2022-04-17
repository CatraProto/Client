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
	public partial class SetEncryptedTyping : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2031374829; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("typing")]
		public bool Typing { get; set; }

        
        #nullable enable
 public SetEncryptedTyping (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer,bool typing)
{
 Peer = peer;
Typing = typing;
 
}
#nullable disable
                
        internal SetEncryptedTyping() 
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
var checktyping = 			writer.WriteBool(Typing);
if(checktyping.IsError){
 return checktyping; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var trytyping = reader.ReadBool();
if(trytyping.IsError){
return ReadResult<IObject>.Move(trytyping);
}
Typing = trytyping.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.setEncryptedTyping";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}