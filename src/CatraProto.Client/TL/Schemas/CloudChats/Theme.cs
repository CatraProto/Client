using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

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
			ForChat = 1 << 5,
			Document = 1 << 2,
			Settings = 1 << 3,
			Emoticon = 1 << 6,
			InstallsCount = 1 << 4
		}

        public static int StaticConstructorId { get => -1609668650; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("creator")]
		public override bool Creator { get; set; }

[Newtonsoft.Json.JsonProperty("default")]
		public override bool Default { get; set; }

[Newtonsoft.Json.JsonProperty("for_chat")]
		public override bool ForChat { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("slug")]
		public override string Slug { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase> Settings { get; set; }

[Newtonsoft.Json.JsonProperty("emoticon")]
		public override string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("installs_count")]
		public override int? InstallsCount { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ForChat ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Emoticon == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = InstallsCount == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

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

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(Emoticon);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(InstallsCount.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			ForChat = FlagsHelper.IsFlagSet(Flags, 5);
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
				Settings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				Emoticon = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				InstallsCount = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "theme";
		}
	}
}