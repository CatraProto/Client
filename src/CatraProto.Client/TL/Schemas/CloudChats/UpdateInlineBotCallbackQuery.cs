using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateInlineBotCallbackQuery : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Data = 1 << 0,
			GameShortName = 1 << 1
		}

        public static int ConstructorId { get; } = -103646630;
		public int Flags { get; set; }
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public InputBotInlineMessageIDBase MsgId { get; set; }
		public long ChatInstance { get; set; }
		public byte[] Data { get; set; }
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
			MsgId = reader.Read<InputBotInlineMessageIDBase>();
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