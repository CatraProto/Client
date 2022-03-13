using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase
	{


        public static int StaticConstructorId { get => 1018991608; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public sealed override long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }


        #nullable enable
 public ChatParticipants (long chatId,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase> participants,int version)
{
 ChatId = chatId;
Participants = participants;
Version = version;
 
}
#nullable disable
        internal ChatParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Participants);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();
			Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
			Version = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "chatParticipants";
		}
	}
}