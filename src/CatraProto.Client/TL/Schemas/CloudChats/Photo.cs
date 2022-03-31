using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Photo : CatraProto.Client.TL.Schemas.CloudChats.PhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasStickers = 1 << 0,
			VideoSizes = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -82216347; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("has_stickers")]
		public bool HasStickers { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("sizes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Sizes { get; set; }

[Newtonsoft.Json.JsonProperty("video_sizes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoSizes { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }


        #nullable enable
 public Photo (long id,long accessHash,byte[] fileReference,int date,IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> sizes,int dcId)
{
 Id = id;
AccessHash = accessHash;
FileReference = fileReference;
Date = date;
Sizes = sizes;
DcId = dcId;
 
}
#nullable disable
        internal Photo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = HasStickers ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = VideoSizes == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

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
			writer.Write(Sizes);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(VideoSizes);
			}

			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasStickers = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			Date = reader.Read<int>();
			Sizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				VideoSizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
			}

			DcId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "photo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}