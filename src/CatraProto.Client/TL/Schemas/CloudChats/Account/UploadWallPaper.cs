using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UploadWallPaper : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -578472351; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }

        
        #nullable enable
 public UploadWallPaper (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file,string mimeType,CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings)
{
 File = file;
MimeType = mimeType;
Settings = settings;
 
}
#nullable disable
                
        internal UploadWallPaper() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(File);
			writer.Write(MimeType);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			MimeType = reader.Read<string>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();

		}
		
		public override string ToString()
		{
		    return "account.uploadWallPaper";
		}
	}
}