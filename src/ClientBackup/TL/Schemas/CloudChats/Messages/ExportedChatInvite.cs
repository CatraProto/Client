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
	public partial class ExportedChatInvite : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 410107472; }
        
[Newtonsoft.Json.JsonProperty("invite")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ExportedChatInvite (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Invite = invite;
Users = users;
 
}
#nullable disable
        internal ExportedChatInvite() 
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
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.exportedChatInvite";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}