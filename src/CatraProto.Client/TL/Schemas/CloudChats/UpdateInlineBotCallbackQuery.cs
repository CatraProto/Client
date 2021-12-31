using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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

        public static int StaticConstructorId { get => 1763610706; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("chat_instance")]
		public long ChatInstance { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public byte[] Data { get; set; }

[Newtonsoft.Json.JsonProperty("game_short_name")]
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
			UserId = reader.Read<long>();
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
				
		public override string ToString()
		{
		    return "updateInlineBotCallbackQuery";
		}
	}
}