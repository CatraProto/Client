using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class BotCallbackAnswer : BotCallbackAnswerBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Alert = 1 << 1,
			HasUrl = 1 << 3,
			NativeUi = 1 << 4,
			Message = 1 << 0,
			Url = 1 << 2
		}

        public static int ConstructorId { get; } = 911761060;
		public int Flags { get; set; }
		public override bool Alert { get; set; }
		public override bool HasUrl { get; set; }
		public override bool NativeUi { get; set; }
		public override string Message { get; set; }
		public override string Url { get; set; }
		public override int CacheTime { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = HasUrl ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = NativeUi ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			writer.Write(CacheTime);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Alert = FlagsHelper.IsFlagSet(Flags, 1);
			HasUrl = FlagsHelper.IsFlagSet(Flags, 3);
			NativeUi = FlagsHelper.IsFlagSet(Flags, 4);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			CacheTime = reader.Read<int>();

		}
	}
}