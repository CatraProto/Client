using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AddChatUser : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -230206493; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("fwd_limit")]
		public int FwdLimit { get; set; }

        
        #nullable enable
 public AddChatUser (long chatId,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,int fwdLimit)
{
 ChatId = chatId;
UserId = userId;
FwdLimit = fwdLimit;
 
}
#nullable disable
                
        internal AddChatUser() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(FwdLimit);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			FwdLimit = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.addChatUser";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}