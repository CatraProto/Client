using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class Country : CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Hidden = 1 << 0,
			Name = 1 << 1
		}

        public static int StaticConstructorId { get => -1014526429; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("hidden")]
		public override bool Hidden { get; set; }

[JsonPropertyName("iso2")]
		public override string Iso2 { get; set; }

[JsonPropertyName("default_name")]
		public override string DefaultName { get; set; }

[JsonPropertyName("name")]
		public override string Name { get; set; }

[JsonPropertyName("country_codes")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase> CountryCodes { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Hidden ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Name == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Iso2);
			writer.Write(DefaultName);
			if(FlagsHelper.IsFlagSet(Flags, 1))
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
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Name = reader.Read<string>();
			}

			CountryCodes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase>();

		}
	}
}