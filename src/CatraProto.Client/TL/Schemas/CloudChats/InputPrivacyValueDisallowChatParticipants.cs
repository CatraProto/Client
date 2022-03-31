using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueDisallowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -380694650; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public IList<long> Chats { get; set; }


        #nullable enable
 public InputPrivacyValueDisallowChatParticipants (IList<long> chats)
{
 Chats = chats;
 
}
#nullable disable
        internal InputPrivacyValueDisallowChatParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Chats);

		}

		public override void Deserialize(Reader reader)
		{
			Chats = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "inputPrivacyValueDisallowChatParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}