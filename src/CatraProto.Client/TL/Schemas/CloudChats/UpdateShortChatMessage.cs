using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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
			Entities = 1 << 7
		}

        public static int StaticConstructorId { get => 1076714939; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("out")]
		public bool Out { get; set; }

[JsonPropertyName("mentioned")]
		public bool Mentioned { get; set; }

[JsonPropertyName("media_unread")]
		public bool MediaUnread { get; set; }

[JsonPropertyName("silent")]
		public bool Silent { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("from_id")]
		public int FromId { get; set; }

[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("fwd_from")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase FwdFrom { get; set; }

[JsonPropertyName("via_bot_id")]
		public int? ViaBotId { get; set; }

[JsonPropertyName("reply_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

[JsonPropertyName("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        
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

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Out = FlagsHelper.IsFlagSet(Flags, 1);
			Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
			MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
			Silent = FlagsHelper.IsFlagSet(Flags, 13);
			Id = reader.Read<int>();
			FromId = reader.Read<int>();
			ChatId = reader.Read<int>();
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
				ViaBotId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReplyTo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
	}
}