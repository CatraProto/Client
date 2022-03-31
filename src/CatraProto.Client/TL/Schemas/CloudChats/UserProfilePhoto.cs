using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserProfilePhoto : CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasVideo = 1 << 0,
			StrippedThumb = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2100168954; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("has_video")]
		public bool HasVideo { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public long PhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("stripped_thumb")]
		public byte[] StrippedThumb { get; set; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }


        #nullable enable
 public UserProfilePhoto (long photoId,int dcId)
{
 PhotoId = photoId;
DcId = dcId;
 
}
#nullable disable
        internal UserProfilePhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = HasVideo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = StrippedThumb == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(StrippedThumb);
			}

			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
			PhotoId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				StrippedThumb = reader.Read<byte[]>();
			}

			DcId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "userProfilePhoto";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}