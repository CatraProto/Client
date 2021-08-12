using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UploadWallPaper : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -578472351; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(WallPaperBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("file")]
		public InputFileBase File { get; set; }

[JsonPropertyName("mime_type")]
		public string MimeType { get; set; }

[JsonPropertyName("settings")]
		public WallPaperSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(File);
			writer.Write(MimeType);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			File = reader.Read<InputFileBase>();
			MimeType = reader.Read<string>();
			Settings = reader.Read<WallPaperSettingsBase>();
		}

		public override string ToString()
		{
			return "account.uploadWallPaper";
		}
	}
}