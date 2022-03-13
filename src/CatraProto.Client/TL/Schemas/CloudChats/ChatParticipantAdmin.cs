using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase
	{


        public static int StaticConstructorId { get => -1600962725; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("inviter_id")]
		public long InviterId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }


        #nullable enable
 public ChatParticipantAdmin (long userId,long inviterId,int date)
{
 UserId = userId;
InviterId = inviterId;
Date = date;
 
}
#nullable disable
        internal ChatParticipantAdmin() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(InviterId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			InviterId = reader.Read<long>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "chatParticipantAdmin";
		}
	}
}