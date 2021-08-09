using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class CreateChannel : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Broadcast = 1 << 0,
			Megagroup = 1 << 1,
			ForImport = 1 << 3,
			GeoPoint = 1 << 2,
			Address = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1029681423; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("broadcast")]
		public bool Broadcast { get; set; }

[JsonPropertyName("megagroup")]
		public bool Megagroup { get; set; }

[JsonPropertyName("for_import")]
		public bool ForImport { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("about")]
		public string About { get; set; }

[JsonPropertyName("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

[JsonPropertyName("address")]
		public string Address { get; set; }


		public void UpdateFlags() 
		{
			Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ForImport ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Address == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(About);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(GeoPoint);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Address);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Broadcast = FlagsHelper.IsFlagSet(Flags, 0);
			Megagroup = FlagsHelper.IsFlagSet(Flags, 1);
			ForImport = FlagsHelper.IsFlagSet(Flags, 3);
			Title = reader.Read<string>();
			About = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Address = reader.Read<string>();
			}


		}
	}
}