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


        public static int StaticConstructorId { get => -2079962673; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public IList<long> Chats { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}