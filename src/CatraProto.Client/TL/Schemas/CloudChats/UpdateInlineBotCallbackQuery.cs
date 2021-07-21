using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateInlineBotCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Data = 1 << 0,
			GameShortName = 1 << 1
		}

        public static int StaticConstructorId { get => -103646630; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("msg_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }

[JsonPropertyName("chat_instance")]
		public long ChatInstance { get; set; }

[JsonPropertyName("data")]
		public byte[] Data { get; set; }

[JsonPropertyName("game_short_name")]
		public string GameShortName { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = GameShortName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(MsgId);
			writer.Write(ChatInstance);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Data);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(GameShortName);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			UserId = reader.Read<int>();
			MsgId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
			ChatInstance = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Data = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				GameShortName = reader.Read<string>();
			}


		}
	}
}