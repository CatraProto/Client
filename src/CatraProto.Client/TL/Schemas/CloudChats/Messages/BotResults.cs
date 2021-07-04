using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class BotResults : BotResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			NextOffset = 1 << 1,
			SwitchPm = 1 << 2
		}

        public static int ConstructorId { get; } = -1803769784;
		public int Flags { get; set; }
		public override bool Gallery { get; set; }
		public override long QueryId { get; set; }
		public override string NextOffset { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }
		public override int CacheTime { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SwitchPm);
			}

			writer.Write(Results);
			writer.Write(CacheTime);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SwitchPm = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase>();
			}

			Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase>();
			CacheTime = reader.Read<int>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}