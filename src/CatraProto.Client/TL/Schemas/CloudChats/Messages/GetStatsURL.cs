using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetStatsURL : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Dark = 1 << 0
		}

		public static int ConstructorId { get; } = -2127811866;
		public int Flags { get; set; }
		public bool Dark { get; set; }
		public InputPeerBase Peer { get; set; }
		public string Params { get; set; }

		public Type Type { get; init; } = typeof(StatsURLBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Params);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputPeerBase>();
			Params = reader.Read<string>();
		}
	}
}