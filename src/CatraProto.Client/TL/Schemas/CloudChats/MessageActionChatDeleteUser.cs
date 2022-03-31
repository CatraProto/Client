using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatDeleteUser : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1539362612; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public MessageActionChatDeleteUser (long userId)
{
 UserId = userId;
 
}
#nullable disable
        internal MessageActionChatDeleteUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionChatDeleteUser";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}