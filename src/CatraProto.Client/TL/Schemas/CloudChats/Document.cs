using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Document : CatraProto.Client.TL.Schemas.CloudChats.DocumentBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Thumbs = 1 << 0,
			VideoThumbs = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 512177195; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public int Size { get; set; }

[Newtonsoft.Json.JsonProperty("thumbs")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

[Newtonsoft.Json.JsonProperty("video_thumbs")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoThumbs { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("attributes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


        #nullable enable
 public Document (long id,long accessHash,byte[] fileReference,int date,string mimeType,int size,int dcId,IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
{
 Id = id;
AccessHash = accessHash;
FileReference = fileReference;
Date = date;
MimeType = mimeType;
Size = size;
DcId = dcId;
Attributes = attributes;
 
}
#nullable disable
        internal Document() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = VideoThumbs == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
				Thumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				VideoThumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
			}

			DcId = reader.Read<int>();
			Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();

		}
		
		public override string ToString()
		{
		    return "document";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}