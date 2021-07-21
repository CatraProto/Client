using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InstallTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0,
			Format = 1 << 1,
			Theme = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 2061776695; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("dark")]
		public bool Dark { get; set; }

[JsonPropertyName("format")]
		public string Format { get; set; }

[JsonPropertyName("theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }


		public void UpdateFlags() 
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Format == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Theme == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Format);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Theme);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Format = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			}


		}
	}
}