using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotCallbackAnswer : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Alert = 1 << 1,
			Message = 1 << 0,
			Url = 1 << 2
		}

		public static int ConstructorId { get; } = -712043766;
		public int Flags { get; set; }
		public bool Alert { get; set; }
		public long QueryId { get; set; }
		public string Message { get; set; }
		public string Url { get; set; }
		public int CacheTime { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Message);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			writer.Write(CacheTime);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Alert = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Message = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			CacheTime = reader.Read<int>();
		}
	}
}