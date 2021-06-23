using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class Country : CountryBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Hidden = 1 << 0,
			Name = 1 << 1
		}

		public static int ConstructorId { get; } = -1014526429;
		public int Flags { get; set; }
		public override bool Hidden { get; set; }
		public override string Iso2 { get; set; }
		public override string DefaultName { get; set; }
		public override string Name { get; set; }
		public override IList<CountryCodeBase> CountryCodes { get; set; }

		public override void UpdateFlags()
		{
			Flags = Hidden ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Name == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Iso2);
			writer.Write(DefaultName);
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Name);
			}

			writer.Write(CountryCodes);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Hidden = FlagsHelper.IsFlagSet(Flags, 0);
			Iso2 = reader.Read<string>();
			DefaultName = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Name = reader.Read<string>();
			}

			CountryCodes = reader.ReadVector<CountryCodeBase>();
		}
	}
}