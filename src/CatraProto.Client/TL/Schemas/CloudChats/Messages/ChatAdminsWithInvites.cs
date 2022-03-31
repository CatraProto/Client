using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatAdminsWithInvites : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1231326505; }
        
[Newtonsoft.Json.JsonProperty("admins")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> Admins { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChatAdminsWithInvites (IList<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> admins,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Admins = admins;
Users = users;
 
}
#nullable disable
        internal ChatAdminsWithInvites() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Admins);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Admins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "messages.chatAdminsWithInvites";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}