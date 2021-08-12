using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPhoto : PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Url = 1 << 0,
			WebpageId = 1 << 0
		}

        public static int StaticConstructorId { get => 391759200; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("photo_id")]
		public long PhotoId { get; set; }

[JsonPropertyName("caption")]
		public PageCaptionBase Caption { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("webpage_id")]
		public long? WebpageId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = WebpageId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			writer.Write(Caption);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(WebpageId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PhotoId = reader.Read<long>();
			Caption = reader.Read<PageCaptionBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Url = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				WebpageId = reader.Read<long>();
			}
		}

		public override string ToString()
		{
			return "pageBlockPhoto";
		}
	}
}