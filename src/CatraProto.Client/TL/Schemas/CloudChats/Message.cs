using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

[Newtonsoft.Json.JsonProperty("from_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("peer_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("fwd_from")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase FwdFrom { get; set; }

[Newtonsoft.Json.JsonProperty("via_bot_id")]
		public long? ViaBotId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string MessageField { get; set; }

[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase Media { get; set; }

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public int? Views { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public int? Forwards { get; set; }

[Newtonsoft.Json.JsonProperty("replies")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }

[Newtonsoft.Json.JsonProperty("edit_date")]
		public int? EditDate { get; set; }

[Newtonsoft.Json.JsonProperty("post_author")]
		public string PostAuthor { get; set; }

[Newtonsoft.Json.JsonProperty("grouped_id")]
		public long? GroupedId { get; set; }

[Newtonsoft.Json.JsonProperty("reactions")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase Reactions { get; set; }

[Newtonsoft.Json.JsonProperty("restriction_reason")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase> RestrictionReason { get; set; }

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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(FromId);
			}

			writer.Write(PeerId);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(FwdFrom);
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(ViaBotId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ReplyTo);
			}

			writer.Write(Date);
			writer.Write(MessageField);
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(Media);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(ReplyMarkup);
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Entities);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(Views.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(Forwards.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
				writer.Write(Replies);
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(EditDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				writer.Write(PostAuthor);
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				writer.Write(GroupedId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 20))
			{
				writer.Write(Reactions);
			}

			if(FlagsHelper.IsFlagSet(Flags, 22))
			{
				writer.Write(RestrictionReason);
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				writer.Write(TtlPeriod.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
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
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				FwdFrom = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				ViaBotId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReplyTo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
			}

			Date = reader.Read<int>();
			MessageField = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				Views = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				Forwards = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
				Replies = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				EditDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				PostAuthor = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				GroupedId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 20))
			{
				Reactions = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 22))
			{
				RestrictionReason = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				TtlPeriod = reader.Read<int>();
			}


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