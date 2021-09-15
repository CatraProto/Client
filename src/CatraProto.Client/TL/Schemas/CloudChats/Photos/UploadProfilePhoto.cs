using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UploadProfilePhoto : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			File = 1 << 0,
			Video = 1 << 1,
			VideoStartTs = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1980559511; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Video { get; set; }

[Newtonsoft.Json.JsonProperty("video_start_ts")]
		public double? VideoStartTs { get; set; }


		public void UpdateFlags() 
		{
			Flags = File == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(File);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Video);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(VideoStartTs);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Video = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				VideoStartTs = reader.Read<double>();
			}


		}
		
		public override string ToString()
		{
		    return "photos.uploadProfilePhoto";
		}
	}
}