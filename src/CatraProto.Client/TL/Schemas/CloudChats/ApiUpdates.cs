using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ApiUpdates : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1957577280; }
        
[Newtonsoft.Json.JsonProperty("updates")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> Updates { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("seq")]
		public int Seq { get; set; }


        #nullable enable
 public ApiUpdates (List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> updates,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,int date,int seq)
{
 Updates = updates;
Users = users;
Chats = chats;
Date = date;
Seq = seq;
 
}
#nullable disable
        internal ApiUpdates() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkupdates = 			writer.WriteVector(Updates, false);
if(checkupdates.IsError){
 return checkupdates; 
}
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}
var checkchats = 			writer.WriteVector(Chats, false);
if(checkchats.IsError){
 return checkchats; 
}
writer.WriteInt32(Date);
writer.WriteInt32(Seq);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryupdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryupdates.IsError){
return ReadResult<IObject>.Move(tryupdates);
}
Updates = tryupdates.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
			var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trychats.IsError){
return ReadResult<IObject>.Move(trychats);
}
Chats = trychats.Value;
			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
			var tryseq = reader.ReadInt32();
if(tryseq.IsError){
return ReadResult<IObject>.Move(tryseq);
}
Seq = tryseq.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updates";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}