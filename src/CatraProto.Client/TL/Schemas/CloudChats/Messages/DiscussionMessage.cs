using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DiscussionMessage : DiscussionMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			MaxId = 1 << 0,
			ReadInboxMaxId = 1 << 1,
			ReadOutboxMaxId = 1 << 2
		}

        public static int StaticConstructorId { get => -170029155; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

		[JsonPropertyName("messages")] public override IList<MessageBase> Messages { get; set; }

[JsonPropertyName("max_id")]
		public override int? MaxId { get; set; }

[JsonPropertyName("read_inbox_max_id")]
		public override int? ReadInboxMaxId { get; set; }

[JsonPropertyName("read_outbox_max_id")]
		public override int? ReadOutboxMaxId { get; set; }

		[JsonPropertyName("chats")] public override IList<ChatBase> Chats { get; set; }

		[JsonPropertyName("users")] public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReadInboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ReadOutboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Messages);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MaxId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ReadInboxMaxId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReadOutboxMaxId.Value);
			}

			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Messages = reader.ReadVector<MessageBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MaxId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ReadInboxMaxId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReadOutboxMaxId = reader.Read<int>();
			}

			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}

		public override string ToString()
		{
			return "messages.discussionMessage";
		}
	}
}