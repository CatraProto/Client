using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatAdminWithInvites : CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase
	{


        public static int StaticConstructorId { get => -219353309; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("admin_id")]
		public override long AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("invites_count")]
		public override int InvitesCount { get; set; }

[Newtonsoft.Json.JsonProperty("revoked_invites_count")]
		public override int RevokedInvitesCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(AdminId);
			writer.Write(InvitesCount);
			writer.Write(RevokedInvitesCount);

		}

		public override void Deserialize(Reader reader)
		{
			AdminId = reader.Read<long>();
			InvitesCount = reader.Read<int>();
			RevokedInvitesCount = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "chatAdminWithInvites";
		}
	}
}