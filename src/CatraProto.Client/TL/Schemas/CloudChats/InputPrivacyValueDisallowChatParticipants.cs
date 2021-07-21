using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueDisallowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
	{


        public static int StaticConstructorId { get => -668769361; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chats")]
		public IList<int> Chats { get; set; }

        
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
			Chats = reader.ReadVector<int>();

		}
	}
}