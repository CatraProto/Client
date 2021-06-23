using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetInlineBotResults : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			GeoPoint = 1 << 0
		}

		public static int ConstructorId { get; } = 1364105629;
		public int Flags { get; set; }
		public InputUserBase Bot { get; set; }
		public InputPeerBase Peer { get; set; }
		public InputGeoPointBase GeoPoint { get; set; }
		public string Query { get; set; }
		public string Offset { get; set; }

		public Type Type { get; init; } = typeof(BotResultsBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Bot);
			writer.Write(Peer);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(GeoPoint);
			}

			writer.Write(Query);
			writer.Write(Offset);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Bot = reader.Read<InputUserBase>();
			Peer = reader.Read<InputPeerBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				GeoPoint = reader.Read<InputGeoPointBase>();
			}

			Query = reader.Read<string>();
			Offset = reader.Read<string>();
		}
	}
}