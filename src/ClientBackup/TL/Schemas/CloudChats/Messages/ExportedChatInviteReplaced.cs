using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ExportedChatInviteReplaced : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 572915951; }
        
[Newtonsoft.Json.JsonProperty("invite")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

[Newtonsoft.Json.JsonProperty("new_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase NewInvite { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ExportedChatInviteReplaced (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite,CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase newInvite,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Invite = invite;
NewInvite = newInvite;
Users = users;
 
}
#nullable disable
        internal ExportedChatInviteReplaced() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkinvite = 			writer.WriteObject(Invite);
if(checkinvite.IsError){
 return checkinvite; 
}
var checknewInvite = 			writer.WriteObject(NewInvite);
if(checknewInvite.IsError){
 return checknewInvite; 
}
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
if(tryinvite.IsError){
return ReadResult<IObject>.Move(tryinvite);
}
Invite = tryinvite.Value;
			var trynewInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
if(trynewInvite.IsError){
return ReadResult<IObject>.Move(trynewInvite);
}
NewInvite = trynewInvite.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.exportedChatInviteReplaced";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}