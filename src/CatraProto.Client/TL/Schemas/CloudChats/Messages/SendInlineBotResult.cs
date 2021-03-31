using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendInlineBotResult : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 5,
			Background = 1 << 6,
			ClearDraft = 1 << 7,
			HideVia = 1 << 11,
			ReplyToMsgId = 1 << 0,
			ScheduleDate = 1 << 10
		}

        public static int ConstructorId { get; } = 570955184;

		public int Flags { get; set; }
		public bool Silent { get; set; }
		public bool Background { get; set; }
		public bool ClearDraft { get; set; }
		public bool HideVia { get; set; }
		public InputPeerBase Peer { get; set; }
		public int? ReplyToMsgId { get; set; }
		public long RandomId { get; set; }
		public long QueryId { get; set; }
		public string Id { get; set; }
		public int? ScheduleDate { get; set; }

		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HideVia ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToMsgId.Value);
			}

			writer.Write(RandomId);
			writer.Write(QueryId);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
			HideVia = FlagsHelper.IsFlagSet(Flags, 11);
			Peer = reader.Read<InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToMsgId = reader.Read<int>();
			}

			RandomId = reader.Read<long>();
			QueryId = reader.Read<long>();
			Id = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
	}
}