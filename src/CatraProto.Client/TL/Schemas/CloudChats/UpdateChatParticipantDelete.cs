using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatParticipantDelete : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -483443337; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }


        #nullable enable
 public UpdateChatParticipantDelete (long chatId,long userId,int version)
{
 ChatId = chatId;
UserId = userId;
Version = version;
 
}
#nullable disable
        internal UpdateChatParticipantDelete() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();
			UserId = reader.Read<long>();
			Version = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateChatParticipantDelete";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}