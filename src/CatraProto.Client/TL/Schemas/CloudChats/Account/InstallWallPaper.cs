using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InstallWallPaper : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -18000023; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("wallpaper")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

[JsonPropertyName("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpaper);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();

		}
	}
}