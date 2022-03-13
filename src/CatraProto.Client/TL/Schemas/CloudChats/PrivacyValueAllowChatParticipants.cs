using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyValueAllowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
	{


        public static int StaticConstructorId { get => 1796427406; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public IList<long> Chats { get; set; }


        #nullable enable
 public PrivacyValueAllowChatParticipants (IList<long> chats)
{
 Chats = chats;
 
}
#nullable disable
        internal PrivacyValueAllowChatParticipants() 
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
		    return "privacyValueAllowChatParticipants";
		}
	}
}