using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetRecentStickers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Attached = 1 << 0
		}

        public static int ConstructorId { get; } = 1587647177;

		public int Flags { get; set; }
		public bool Attached { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{
			Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Attached = FlagsHelper.IsFlagSet(Flags, 0);
			Hash = reader.Read<int>();

		}
	}
}