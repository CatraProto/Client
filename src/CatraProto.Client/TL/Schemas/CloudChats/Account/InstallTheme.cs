using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InstallTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0,
			Theme = 1 << 1,
			Format = 1 << 2,
			BaseTheme = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -953697477; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("dark")]
		public bool Dark { get; set; }

[Newtonsoft.Json.JsonProperty("theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

[Newtonsoft.Json.JsonProperty("format")]
		public string Format { get; set; }

[Newtonsoft.Json.JsonProperty("base_theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }


		public void UpdateFlags() 
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Theme == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Format == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BaseTheme == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Theme);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Format);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BaseTheme);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Format = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				BaseTheme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase>();
			}


		}
		
		public override string ToString()
		{
		    return "account.installTheme";
		}
	}
}