using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePinnedChannelMessages : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pinned = 1 << 0
		}

        public static int ConstructorId { get; } = -2054649973;
		public int Flags { get; set; }
		public bool Pinned { get; set; }
		public int ChannelId { get; set; }
		public IList<int> Messages { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			writer.Write(Messages);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pinned = FlagsHelper.IsFlagSet(Flags, 0);
			ChannelId = reader.Read<int>();
			Messages = reader.ReadVector<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}