using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveWallPaper : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1817860919; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("wallpaper")]
		public InputWallPaperBase Wallpaper { get; set; }

[JsonPropertyName("unsave")]
		public bool Unsave { get; set; }

[JsonPropertyName("settings")]
		public WallPaperSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpaper);
			writer.Write(Unsave);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<InputWallPaperBase>();
			Unsave = reader.Read<bool>();
			Settings = reader.Read<WallPaperSettingsBase>();

		}
	}
}