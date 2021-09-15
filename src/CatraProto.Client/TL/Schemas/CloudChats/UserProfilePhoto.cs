using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserProfilePhoto : CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasVideo = 1 << 0
		}

        public static int StaticConstructorId { get => 1775479590; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("has_video")]
		public bool HasVideo { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public long PhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("photo_small")]
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase PhotoSmall { get; set; }

[Newtonsoft.Json.JsonProperty("photo_big")]
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase PhotoBig { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = HasVideo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			writer.Write(PhotoSmall);
			writer.Write(PhotoBig);
			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
			PhotoId = reader.Read<long>();
			PhotoSmall = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase>();
			PhotoBig = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase>();
			DcId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "userProfilePhoto";
		}
	}
}