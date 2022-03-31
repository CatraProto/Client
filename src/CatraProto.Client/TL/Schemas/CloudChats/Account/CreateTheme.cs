using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class CreateTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 2,
			Settings = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1697530880; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ThemeBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("slug")]
		public string Slug { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase> Settings { get; set; }

        
        #nullable enable
 public CreateTheme (string slug,string title)
{
 Slug = slug;
Title = title;
 
}
#nullable disable
                
        internal CreateTheme() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
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


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Slug = reader.Read<string>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Settings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase>();
			}


		}

		public override string ToString()
		{
		    return "account.createTheme";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}