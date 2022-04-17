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
	public partial class InputPrivacyValueAllowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2079962673; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public List<long> Chats { get; set; }


        #nullable enable
 public InputPrivacyValueAllowChatParticipants (List<long> chats)
{
 Chats = chats;
 
}
#nullable disable
        internal InputPrivacyValueAllowChatParticipants() 
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
		    return "inputPrivacyValueAllowChatParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}