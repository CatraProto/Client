using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveWallPaper : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1817860919; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("wallpaper")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

[Newtonsoft.Json.JsonProperty("unsave")]
		public bool Unsave { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }

        
        #nullable enable
 public SaveWallPaper (CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper,bool unsave,CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings)
{
 Wallpaper = wallpaper;
Unsave = unsave;
Settings = settings;
 
}
#nullable disable
                
        internal SaveWallPaper() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Wallpaper);
			writer.Write(Unsave);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
			Unsave = reader.Read<bool>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();

		}
		
		public override string ToString()
		{
		    return "account.saveWallPaper";
		}
	}
}