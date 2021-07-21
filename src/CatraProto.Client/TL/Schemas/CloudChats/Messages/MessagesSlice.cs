using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessagesSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inexact = 1 << 1,
			NextRate = 1 << 0,
			OffsetIdOffset = 1 << 2
		}

        public static int StaticConstructorId { get => 978610270; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("inexact")]
		public bool Inexact { get; set; }

[JsonPropertyName("count")]
		public int Count { get; set; }

[JsonPropertyName("next_rate")]
		public int? NextRate { get; set; }

[JsonPropertyName("offset_id_offset")]
		public int? OffsetIdOffset { get; set; }

[JsonPropertyName("messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[JsonPropertyName("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = NextRate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Count);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NextRate.Value);
			}

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
			Count = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NextRate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				OffsetIdOffset = reader.Read<int>();
			}

			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}