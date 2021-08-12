using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetLocated : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Background = 1 << 1,
			SelfExpires = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -750207932; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("background")]
		public bool Background { get; set; }

		[JsonPropertyName("geo_point")] public InputGeoPointBase GeoPoint { get; set; }

[JsonPropertyName("self_expires")]
		public int? SelfExpires { get; set; }


		public void UpdateFlags() 
		{
			Flags = Background ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = SelfExpires == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(GeoPoint);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(SelfExpires.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Background = FlagsHelper.IsFlagSet(Flags, 1);
			GeoPoint = reader.Read<InputGeoPointBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				SelfExpires = reader.Read<int>();
			}
		}

		public override string ToString()
		{
			return "contacts.getLocated";
		}
	}
}