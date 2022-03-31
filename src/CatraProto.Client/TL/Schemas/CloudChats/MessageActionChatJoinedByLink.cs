using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatJoinedByLink : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 51520707; }
        
[Newtonsoft.Json.JsonProperty("inviter_id")]
		public long InviterId { get; set; }


        #nullable enable
 public MessageActionChatJoinedByLink (long inviterId)
{
 InviterId = inviterId;
 
}
#nullable disable
        internal MessageActionChatJoinedByLink() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(InviterId);

		}

		public override void Deserialize(Reader reader)
		{
			InviterId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionChatJoinedByLink";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}