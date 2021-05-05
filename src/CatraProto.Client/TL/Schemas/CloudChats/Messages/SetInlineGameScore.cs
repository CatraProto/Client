using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetInlineGameScore : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			EditMessage = 1 << 0,
			Force = 1 << 1
		}

        public static int ConstructorId { get; } = 363700068;

		public Type Type { get; init; } = typeof(SetInlineGameScore);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool EditMessage { get; set; }
		public bool Force { get; set; }
		public InputBotInlineMessageIDBase Id { get; set; }
		public InputUserBase UserId { get; set; }
		public int Score { get; set; }

		public void UpdateFlags() 
		{
			Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<InputBotInlineMessageIDBase>();
			UserId = reader.Read<InputUserBase>();
			Score = reader.Read<int>();

		}
	}
}