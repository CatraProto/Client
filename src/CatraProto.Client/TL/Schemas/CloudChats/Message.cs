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
	public partial class Message : CatraProto.Client.TL.Schemas.CloudChats.MessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Out = 1 << 1,
			Mentioned = 1 << 4,
			MediaUnread = 1 << 5,
			Silent = 1 << 13,
			Post = 1 << 14,
			FromScheduled = 1 << 18,
			Legacy = 1 << 19,
			EditHide = 1 << 21,
			Pinned = 1 << 24,
			Noforwards = 1 << 26,
			FromId = 1 << 8,
			FwdFrom = 1 << 2,
			ViaBotId = 1 << 11,
			ReplyTo = 1 << 3,
			Media = 1 << 9,
			ReplyMarkup = 1 << 6,
			Entities = 1 << 7,
			Views = 1 << 10,
			Forwards = 1 << 10,
			Replies = 1 << 23,
			EditDate = 1 << 15,
			PostAuthor = 1 << 16,
			GroupedId = 1 << 17,
			Reactions = 1 << 20,
			RestrictionReason = 1 << 22,
			TtlPeriod = 1 << 25
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 940666592; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("out")]
		public bool Out { get; set; }

[Newtonsoft.Json.JsonProperty("mentioned")]
		public bool Mentioned { get; set; }

[Newtonsoft.Json.JsonProperty("media_unread")]
		public bool MediaUnread { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

[Newtonsoft.Json.JsonProperty("post")]
		public bool Post { get; set; }

[Newtonsoft.Json.JsonProperty("from_scheduled")]
		public bool FromScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("legacy")]
		public bool Legacy { get; set; }

[Newtonsoft.Json.JsonProperty("edit_hide")]
		public bool EditHide { get; set; }

[Newtonsoft.Json.JsonProperty("pinned")]
		public bool Pinned { get; set; }

[Newtonsoft.Json.JsonProperty("noforwards")]
		public bool Noforwards { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("from_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("peer_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("fwd_from")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase FwdFrom { get; set; }

[Newtonsoft.Json.JsonProperty("via_bot_id")]
		public long? ViaBotId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reply_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string MessageField { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase Media { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reply_markup")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public int? Views { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public int? Forwards { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("replies")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }

[Newtonsoft.Json.JsonProperty("edit_date")]
		public int? EditDate { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("post_author")]
		public string PostAuthor { get; set; }

[Newtonsoft.Json.JsonProperty("grouped_id")]
		public long? GroupedId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reactions")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase Reactions { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("restriction_reason")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase> RestrictionReason { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public int? TtlPeriod { get; set; }


        #nullable enable
 public Message (int id,CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId,int date,string messageField)
{
 Id = id;
PeerId = peerId;
Date = date;
MessageField = messageField;
 
}
#nullable disable
        internal Message() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = Post ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
			Flags = FromScheduled ? FlagsHelper.SetFlag(Flags, 18) : FlagsHelper.UnsetFlag(Flags, 18);
			Flags = Legacy ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
			Flags = EditHide ? FlagsHelper.SetFlag(Flags, 21) : FlagsHelper.UnsetFlag(Flags, 21);
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
			Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 26) : FlagsHelper.UnsetFlag(Flags, 26);
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
			Flags = FwdFrom == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ViaBotId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
			Flags = Forwards == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
			Flags = Replies == null ? FlagsHelper.UnsetFlag(Flags, 23) : FlagsHelper.SetFlag(Flags, 23);
			Flags = EditDate == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
			Flags = PostAuthor == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
			Flags = GroupedId == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
			Flags = Reactions == null ? FlagsHelper.UnsetFlag(Flags, 20) : FlagsHelper.SetFlag(Flags, 20);
			Flags = RestrictionReason == null ? FlagsHelper.UnsetFlag(Flags, 22) : FlagsHelper.SetFlag(Flags, 22);
			Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt32(Id);
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
var checkfromId = 				writer.WriteObject(FromId);
if(checkfromId.IsError){
 return checkfromId; 
}
			}

var checkpeerId = 			writer.WriteObject(PeerId);
if(checkpeerId.IsError){
 return checkpeerId; 
}
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkfwdFrom = 				writer.WriteObject(FwdFrom);
if(checkfwdFrom.IsError){
 return checkfwdFrom; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
writer.WriteInt64(ViaBotId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkreplyTo = 				writer.WriteObject(ReplyTo);
if(checkreplyTo.IsError){
 return checkreplyTo; 
}
			}

writer.WriteInt32(Date);

			writer.WriteString(MessageField);
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
var checkmedia = 				writer.WriteObject(Media);
if(checkmedia.IsError){
 return checkmedia; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
var checkreplyMarkup = 				writer.WriteObject(ReplyMarkup);
if(checkreplyMarkup.IsError){
 return checkreplyMarkup; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
var checkentities = 				writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
writer.WriteInt32(Views.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
writer.WriteInt32(Forwards.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
var checkreplies = 				writer.WriteObject(Replies);
if(checkreplies.IsError){
 return checkreplies; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
writer.WriteInt32(EditDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{

				writer.WriteString(PostAuthor);
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
writer.WriteInt64(GroupedId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 20))
			{
var checkreactions = 				writer.WriteObject(Reactions);
if(checkreactions.IsError){
 return checkreactions; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 22))
			{
var checkrestrictionReason = 				writer.WriteVector(RestrictionReason, false);
if(checkrestrictionReason.IsError){
 return checkrestrictionReason; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
writer.WriteInt32(TtlPeriod.Value);
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Out = FlagsHelper.IsFlagSet(Flags, 1);
			Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
			MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
			Silent = FlagsHelper.IsFlagSet(Flags, 13);
			Post = FlagsHelper.IsFlagSet(Flags, 14);
			FromScheduled = FlagsHelper.IsFlagSet(Flags, 18);
			Legacy = FlagsHelper.IsFlagSet(Flags, 19);
			EditHide = FlagsHelper.IsFlagSet(Flags, 21);
			Pinned = FlagsHelper.IsFlagSet(Flags, 24);
			Noforwards = FlagsHelper.IsFlagSet(Flags, 26);
			var tryid = reader.ReadInt32();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(tryfromId.IsError){
return ReadResult<IObject>.Move(tryfromId);
}
FromId = tryfromId.Value;
			}

			var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(trypeerId.IsError){
return ReadResult<IObject>.Move(trypeerId);
}
PeerId = trypeerId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryfwdFrom = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase>();
if(tryfwdFrom.IsError){
return ReadResult<IObject>.Move(tryfwdFrom);
}
FwdFrom = tryfwdFrom.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				var tryviaBotId = reader.ReadInt64();
if(tryviaBotId.IsError){
return ReadResult<IObject>.Move(tryviaBotId);
}
ViaBotId = tryviaBotId.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryreplyTo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
if(tryreplyTo.IsError){
return ReadResult<IObject>.Move(tryreplyTo);
}
ReplyTo = tryreplyTo.Value;
			}

			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
			var trymessageField = reader.ReadString();
if(trymessageField.IsError){
return ReadResult<IObject>.Move(trymessageField);
}
MessageField = trymessageField.Value;
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
if(trymedia.IsError){
return ReadResult<IObject>.Move(trymedia);
}
Media = trymedia.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
if(tryreplyMarkup.IsError){
return ReadResult<IObject>.Move(tryreplyMarkup);
}
ReplyMarkup = tryreplyMarkup.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryentities.IsError){
return ReadResult<IObject>.Move(tryentities);
}
Entities = tryentities.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				var tryviews = reader.ReadInt32();
if(tryviews.IsError){
return ReadResult<IObject>.Move(tryviews);
}
Views = tryviews.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				var tryforwards = reader.ReadInt32();
if(tryforwards.IsError){
return ReadResult<IObject>.Move(tryforwards);
}
Forwards = tryforwards.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
				var tryreplies = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase>();
if(tryreplies.IsError){
return ReadResult<IObject>.Move(tryreplies);
}
Replies = tryreplies.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				var tryeditDate = reader.ReadInt32();
if(tryeditDate.IsError){
return ReadResult<IObject>.Move(tryeditDate);
}
EditDate = tryeditDate.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				var trypostAuthor = reader.ReadString();
if(trypostAuthor.IsError){
return ReadResult<IObject>.Move(trypostAuthor);
}
PostAuthor = trypostAuthor.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				var trygroupedId = reader.ReadInt64();
if(trygroupedId.IsError){
return ReadResult<IObject>.Move(trygroupedId);
}
GroupedId = trygroupedId.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 20))
			{
				var tryreactions = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase>();
if(tryreactions.IsError){
return ReadResult<IObject>.Move(tryreactions);
}
Reactions = tryreactions.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 22))
			{
				var tryrestrictionReason = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryrestrictionReason.IsError){
return ReadResult<IObject>.Move(tryrestrictionReason);
}
RestrictionReason = tryrestrictionReason.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				var tryttlPeriod = reader.ReadInt32();
if(tryttlPeriod.IsError){
return ReadResult<IObject>.Move(tryttlPeriod);
}
TtlPeriod = tryttlPeriod.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "message";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}