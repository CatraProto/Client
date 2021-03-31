using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchStickerSets : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludeFeatured = 1 << 0
		}

        public static int ConstructorId { get; } = -1028140917;

		public int Flags { get; set; }
		public bool ExcludeFeatured { get; set; }
		public string Q { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{
			Flags = ExcludeFeatured ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Q);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ExcludeFeatured = FlagsHelper.IsFlagSet(Flags, 0);
			Q = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}