using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Document : DocumentBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Thumbs = 1 << 0,
			VideoThumbs = 1 << 1
		}

        public static int StaticConstructorId { get => 512177195; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("access_hash")]
		public long AccessHash { get; set; }

[JsonPropertyName("file_reference")]
		public byte[] FileReference { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("mime_type")]
		public string MimeType { get; set; }

[JsonPropertyName("size")]
		public int Size { get; set; }

[JsonPropertyName("thumbs")]
		public IList<PhotoSizeBase> Thumbs { get; set; }

[JsonPropertyName("video_thumbs")]
		public IList<VideoSizeBase> VideoThumbs { get; set; }

[JsonPropertyName("dc_id")]
		public int DcId { get; set; }

[JsonPropertyName("attributes")]
		public IList<DocumentAttributeBase> Attributes { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = VideoThumbs == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(FileReference);
			writer.Write(Date);
			writer.Write(MimeType);
			writer.Write(Size);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Thumbs);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(VideoThumbs);
			}

			writer.Write(DcId);
			writer.Write(Attributes);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			Date = reader.Read<int>();
			MimeType = reader.Read<string>();
			Size = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Thumbs = reader.ReadVector<PhotoSizeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				VideoThumbs = reader.ReadVector<VideoSizeBase>();
			}

			DcId = reader.Read<int>();
			Attributes = reader.ReadVector<DocumentAttributeBase>();
		}

		public override string ToString()
		{
			return "document";
		}
	}
}