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
	public partial class PrivacyValueDisallowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1103656293; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public List<long> Chats { get; set; }


        #nullable enable
 public PrivacyValueDisallowChatParticipants (List<long> chats)
{
 Chats = chats;
 
}
#nullable disable
        internal PrivacyValueDisallowChatParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteVector(Chats, false);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychats = reader.ReadVector<long>(ParserTypes.Int64);
if(trychats.IsError){
return ReadResult<IObject>.Move(trychats);
}
Chats = trychats.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "privacyValueDisallowChatParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}