using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Search : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			FromId = 1 << 0,
			TopMsgId = 1 << 1
		}

		public static int ConstructorId { get; } = 204812012;
		public int Flags { get; set; }
		public InputPeerBase Peer { get; set; }
		public string Q { get; set; }
		public InputPeerBase FromId { get; set; }
		public int? TopMsgId { get; set; }
		public MessagesFilterBase Filter { get; set; }
		public int MinDate { get; set; }
		public int MaxDate { get; set; }
		public int OffsetId { get; set; }
		public int AddOffset { get; set; }
		public int Limit { get; set; }
		public int MaxId { get; set; }
		public int MinId { get; set; }
		public int Hash { get; set; }

		public Type Type { get; init; } = typeof(MessagesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Q);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FromId);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(TopMsgId.Value);
			}

			writer.Write(Filter);
			writer.Write(MinDate);
			writer.Write(MaxDate);
			writer.Write(OffsetId);
			writer.Write(AddOffset);
			writer.Write(Limit);
			writer.Write(MaxId);
			writer.Write(MinId);
			writer.Write(Hash);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<InputPeerBase>();
			Q = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				FromId = reader.Read<InputPeerBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				TopMsgId = reader.Read<int>();
			}

			Filter = reader.Read<MessagesFilterBase>();
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();
			OffsetId = reader.Read<int>();
			AddOffset = reader.Read<int>();
			Limit = reader.Read<int>();
			MaxId = reader.Read<int>();
			MinId = reader.Read<int>();
			Hash = reader.Read<int>();
		}
	}
}