using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotInlineQuery : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Geo = 1 << 0
		}

        public static int ConstructorId { get; } = 1417832080;
		public int Flags { get; set; }
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public string Query { get; set; }
		public GeoPointBase Geo { get; set; }
		public string Offset { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Query);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Geo);
			}

			writer.Write(Offset);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			UserId = reader.Read<int>();
			Query = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Geo = reader.Read<GeoPointBase>();
			}

			Offset = reader.Read<string>();

		}
	}
}