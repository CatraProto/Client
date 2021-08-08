using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatPhoto : ChatPhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasVideo = 1 << 0
		}

        public static int StaticConstructorId { get => -770990276; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("has_video")]
		public bool HasVideo { get; set; }

[JsonPropertyName("photo_small")]
		public FileLocationBase PhotoSmall { get; set; }

[JsonPropertyName("photo_big")]
		public FileLocationBase PhotoBig { get; set; }

[JsonPropertyName("dc_id")]
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
			writer.Write(PhotoSmall);
			writer.Write(PhotoBig);
			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
			PhotoSmall = reader.Read<FileLocationBase>();
			PhotoBig = reader.Read<FileLocationBase>();
			DcId = reader.Read<int>();

		}
	}
}