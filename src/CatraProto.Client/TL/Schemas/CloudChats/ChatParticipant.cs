using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipant : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1070776313; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("inviter_id")]
		public long InviterId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }


        #nullable enable
 public ChatParticipant (long userId,long inviterId,int date)
{
 UserId = userId;
InviterId = inviterId;
Date = date;
 
}
#nullable disable
        internal ChatParticipant() 
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
		    return "chatParticipant";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}