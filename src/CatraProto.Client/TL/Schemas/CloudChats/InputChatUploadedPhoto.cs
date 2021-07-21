using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChatUploadedPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			File = 1 << 0,
			Video = 1 << 1,
			VideoStartTs = 1 << 2
		}

        public static int StaticConstructorId { get => -968723890; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[JsonPropertyName("video")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Video { get; set; }

[JsonPropertyName("video_start_ts")]
		public double? VideoStartTs { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = File == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
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

		public override void Deserialize(Reader reader)
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
	}
}