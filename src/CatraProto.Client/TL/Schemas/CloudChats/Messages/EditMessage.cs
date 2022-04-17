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
	public partial class EditMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 1,
			Message = 1 << 11,
			Media = 1 << 14,
			ReplyMarkup = 1 << 2,
			Entities = 1 << 3,
			ScheduleDate = 1 << 15
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1224152952; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("no_webpage")]
		public bool NoWebpage { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reply_markup")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }

        
        #nullable enable
 public EditMessage (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int id)
{
 Peer = peer;
Id = id;
 
}
#nullable disable
                
        internal EditMessage() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}
writer.WriteInt32(Id);
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{

				writer.WriteString(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
var checkmedia = 				writer.WriteObject(Media);
if(checkmedia.IsError){
 return checkmedia; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkreplyMarkup = 				writer.WriteObject(ReplyMarkup);
if(checkreplyMarkup.IsError){
 return checkreplyMarkup; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkentities = 				writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
writer.WriteInt32(ScheduleDate.Value);
			}


return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var tryid = reader.ReadInt32();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				var trymessage = reader.ReadString();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
if(trymedia.IsError){
return ReadResult<IObject>.Move(trymedia);
}
Media = trymedia.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
if(tryreplyMarkup.IsError){
return ReadResult<IObject>.Move(tryreplyMarkup);
}
ReplyMarkup = tryreplyMarkup.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryentities.IsError){
return ReadResult<IObject>.Move(tryentities);
}
Entities = tryentities.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				var tryscheduleDate = reader.ReadInt32();
if(tryscheduleDate.IsError){
return ReadResult<IObject>.Move(tryscheduleDate);
}
ScheduleDate = tryscheduleDate.Value;
			}

return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.editMessage";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}