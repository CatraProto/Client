using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetDifference : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			PtsTotalLimit = 1 << 0
		}

        public static int ConstructorId { get; } = 630429265;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public int Pts { get; set; }
		public int? PtsTotalLimit { get; set; }
		public int Date { get; set; }
		public int Qts { get; set; }

		public void UpdateFlags() 
		{
			Flags = PtsTotalLimit == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Pts);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PtsTotalLimit.Value);
			}

			writer.Write(Date);
			writer.Write(Qts);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PtsTotalLimit = reader.Read<int>();
			}

			Date = reader.Read<int>();
			Qts = reader.Read<int>();

		}
	}
}