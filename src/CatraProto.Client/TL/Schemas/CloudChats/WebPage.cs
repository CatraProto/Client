using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPage : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Type = 1 << 0,
			SiteName = 1 << 1,
			Title = 1 << 2,
			Description = 1 << 3,
			Photo = 1 << 4,
			EmbedUrl = 1 << 5,
			EmbedType = 1 << 5,
			EmbedWidth = 1 << 6,
			EmbedHeight = 1 << 6,
			Duration = 1 << 7,
			Author = 1 << 8,
			Document = 1 << 9,
			CachedPage = 1 << 10,
			Attributes = 1 << 12
		}

        public static int StaticConstructorId { get => -392411726; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public long Id { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("display_url")]
		public string DisplayUrl { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("type")]
		public string Type { get; set; }

[JsonPropertyName("site_name")]
		public string SiteName { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("description")]
		public string Description { get; set; }

[JsonPropertyName("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

[JsonPropertyName("embed_url")]
		public string EmbedUrl { get; set; }

[JsonPropertyName("embed_type")]
		public string EmbedType { get; set; }

[JsonPropertyName("embed_width")]
		public int? EmbedWidth { get; set; }

[JsonPropertyName("embed_height")]
		public int? EmbedHeight { get; set; }

[JsonPropertyName("duration")]
		public int? Duration { get; set; }

[JsonPropertyName("author")]
		public string Author { get; set; }

[JsonPropertyName("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[JsonPropertyName("cached_page")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageBase CachedPage { get; set; }

[JsonPropertyName("attributes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase> Attributes { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Type == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = SiteName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = EmbedUrl == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = EmbedType == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = EmbedWidth == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = EmbedHeight == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = Author == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = CachedPage == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
			Flags = Attributes == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Url);
			writer.Write(DisplayUrl);
			writer.Write(Hash);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Type);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(SiteName);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Description);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Photo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(EmbedUrl);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(EmbedType);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(EmbedWidth.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(EmbedHeight.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Duration.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(Author);
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(Document);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(CachedPage);
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				writer.Write(Attributes);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<long>();
			Url = reader.Read<string>();
			DisplayUrl = reader.Read<string>();
			Hash = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Type = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				SiteName = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Title = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Description = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				EmbedUrl = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				EmbedType = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				EmbedWidth = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				EmbedHeight = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Duration = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				Author = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				CachedPage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase>();
			}


		}
	}
}