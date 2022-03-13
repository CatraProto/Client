using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UploadTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Thumb = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 473805619; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.DocumentBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[Newtonsoft.Json.JsonProperty("thumb")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Thumb { get; set; }

[Newtonsoft.Json.JsonProperty("file_name")]
		public string FileName { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public string MimeType { get; set; }

        
        #nullable enable
 public UploadTheme (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file,string fileName,string mimeType)
{
 File = file;
FileName = fileName;
MimeType = mimeType;
 
}
#nullable disable
                
        internal UploadTheme() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(File);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Thumb);
			}

			writer.Write(FileName);
			writer.Write(MimeType);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			}

			FileName = reader.Read<string>();
			MimeType = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "account.uploadTheme";
		}
	}
}