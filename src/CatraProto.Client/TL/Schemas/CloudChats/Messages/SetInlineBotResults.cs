using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetInlineBotResults : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			Private = 1 << 1,
			NextOffset = 1 << 2,
			SwitchPm = 1 << 3
		}

        public static int ConstructorId { get; } = -346119674;

		public Type Type { get; init; } = typeof(SetInlineBotResults);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Gallery { get; set; }
		public bool Private { get; set; }
		public long QueryId { get; set; }
		public IList<InputBotInlineResultBase> Results { get; set; }
		public int CacheTime { get; set; }
		public string NextOffset { get; set; }
		public InlineBotSwitchPMBase SwitchPm { get; set; }

		public void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Private ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(Results);
			writer.Write(CacheTime);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(SwitchPm);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			Private = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			Results = reader.ReadVector<InputBotInlineResultBase>();
			CacheTime = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				SwitchPm = reader.Read<InlineBotSwitchPMBase>();
			}


		}
	}
}