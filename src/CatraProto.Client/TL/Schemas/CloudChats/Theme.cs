using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Theme : CatraProto.Client.TL.Schemas.CloudChats.ThemeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Default = 1 << 1,
			Document = 1 << 2,
			Settings = 1 << 3
		}

        public static int StaticConstructorId { get => 42930452; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("creator")]
		public override bool Creator { get; set; }

[JsonPropertyName("default")]
		public override bool Default { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("access_hash")]
		public override long AccessHash { get; set; }

[JsonPropertyName("slug")]
		public override string Slug { get; set; }

[JsonPropertyName("title")]
		public override string Title { get; set; }

[JsonPropertyName("document")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[JsonPropertyName("settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }

[JsonPropertyName("installs_count")]
		public override int InstallsCount { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Slug);
			writer.Write(Title);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Document);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Settings);
			}

			writer.Write(InstallsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Slug = reader.Read<string>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase>();
			}

			InstallsCount = reader.Read<int>();

		}
	}
}