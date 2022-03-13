using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaUploadedPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Stickers = 1 << 0,
			TtlSeconds = 1 << 1
		}

        public static int StaticConstructorId { get => 505969924; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[Newtonsoft.Json.JsonProperty("stickers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase> Stickers { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_seconds")]
		public int? TtlSeconds { get; set; }


        #nullable enable
 public InputMediaUploadedPhoto (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file)
{
 File = file;
 
}
#nullable disable
        internal InputMediaUploadedPhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Stickers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(File);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Stickers);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(TtlSeconds.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				TtlSeconds = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "inputMediaUploadedPhoto";
		}
	}
}