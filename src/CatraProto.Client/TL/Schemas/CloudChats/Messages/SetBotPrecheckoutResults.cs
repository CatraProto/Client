using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotPrecheckoutResults : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Success = 1 << 1,
			Error = 1 << 0
		}

        public static int ConstructorId { get; } = 163765653;

		public Type Type { get; init; } = typeof(SetBotPrecheckoutResults);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Success { get; set; }
		public long QueryId { get; set; }
		public string Error { get; set; }

		public void UpdateFlags() 
		{
			Flags = Success ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Error);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Success = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Error = reader.Read<string>();
			}


		}
	}
}