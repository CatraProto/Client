using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


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

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }
		public string Query { get; set; }
		public string Offset { get; set; }

		public void UpdateFlags() 
		{
			Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Bot);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(GeoPoint);
			}

			writer.Write(Query);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			}

			Query = reader.Read<string>();
			Offset = reader.Read<string>();

		}
	}
}