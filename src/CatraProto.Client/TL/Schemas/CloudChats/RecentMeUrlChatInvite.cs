using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlChatInvite : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -347535331; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("chat_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase ChatInvite { get; set; }


        #nullable enable
 public RecentMeUrlChatInvite (string url,CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase chatInvite)
{
 Url = url;
ChatInvite = chatInvite;
 
}
#nullable disable
        internal RecentMeUrlChatInvite() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(ChatInvite);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			ChatInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>();

		}
		
		public override string ToString()
		{
		    return "recentMeUrlChatInvite";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}