using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChannelMessages : MessagesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inexact = 1 << 1,
			OffsetIdOffset = 1 << 2
		}

        public static int StaticConstructorId { get => 1682413576; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("inexact")]
		public bool Inexact { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("count")]
		public int Count { get; set; }

[JsonPropertyName("offset_id_offset")]
		public int? OffsetIdOffset { get; set; }

[JsonPropertyName("messages")]
		public IList<MessageBase> Messages { get; set; }

[JsonPropertyName("chats")]
		public IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Pts);
			writer.Write(Count);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(OffsetIdOffset.Value);
			}

			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Inexact = FlagsHelper.IsFlagSet(Flags, 1);
			Pts = reader.Read<int>();
			Count = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				OffsetIdOffset = reader.Read<int>();
			}

			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}