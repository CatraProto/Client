using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShortChatMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Out = 1 << 1,
			Mentioned = 1 << 4,
			MediaUnread = 1 << 5,
			Silent = 1 << 13,
			FwdFrom = 1 << 2,
			ViaBotId = 1 << 11,
			ReplyTo = 1 << 3,
			Entities = 1 << 7,
			TtlPeriod = 1 << 25
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1299050149; }
        
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

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("from_id")]
		public long FromId { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("fwd_from")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase FwdFrom { get; set; }

[Newtonsoft.Json.JsonProperty("via_bot_id")]
		public long? ViaBotId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public int? TtlPeriod { get; set; }


        #nullable enable
 public UpdateShortChatMessage (int id,long fromId,long chatId,string message,int pts,int ptsCount,int date)
{
 Id = id;
FromId = fromId;
ChatId = chatId;
Message = message;
Pts = pts;
PtsCount = ptsCount;
Date = date;
 
}
#nullable disable
        internal UpdateShortChatMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = FwdFrom == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ViaBotId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(FromId);
			writer.Write(ChatId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Date);
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

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Entities);
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
			Id = reader.Read<int>();
			FromId = reader.Read<long>();
			ChatId = reader.Read<long>();
			Message = reader.Read<string>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Date = reader.Read<int>();
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

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				TtlPeriod = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "updateShortChatMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}