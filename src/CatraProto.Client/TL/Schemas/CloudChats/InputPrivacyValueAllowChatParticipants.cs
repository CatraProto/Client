using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueAllowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2079962673; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public IList<long> Chats { get; set; }


        #nullable enable
 public InputPrivacyValueAllowChatParticipants (IList<long> chats)
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
		    return "inputPrivacyValueAllowChatParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}