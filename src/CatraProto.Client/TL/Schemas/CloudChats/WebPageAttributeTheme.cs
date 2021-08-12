using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPageAttributeTheme : WebPageAttributeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Documents = 1 << 0,
			Settings = 1 << 1
		}

        public static int StaticConstructorId { get => 1421174295; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("documents")]
		public override IList<DocumentBase> Documents { get; set; }

[JsonPropertyName("settings")]
		public override ThemeSettingsBase Settings { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Documents == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Documents);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Settings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Documents = reader.ReadVector<DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Settings = reader.Read<ThemeSettingsBase>();
			}
		}

		public override string ToString()
		{
			return "webPageAttributeTheme";
		}
	}
}