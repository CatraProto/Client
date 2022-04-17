using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 505969924; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("stickers")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase> Stickers { get; set; }

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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkfile = 			writer.WriteObject(File);
if(checkfile.IsError){
 return checkfile; 
}
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkstickers = 				writer.WriteVector(Stickers, false);
if(checkstickers.IsError){
 return checkstickers; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
writer.WriteInt32(TtlSeconds.Value);
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
if(tryfile.IsError){
return ReadResult<IObject>.Move(tryfile);
}
File = tryfile.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trystickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trystickers.IsError){
return ReadResult<IObject>.Move(trystickers);
}
Stickers = trystickers.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryttlSeconds = reader.ReadInt32();
if(tryttlSeconds.IsError){
return ReadResult<IObject>.Move(tryttlSeconds);
}
TtlSeconds = tryttlSeconds.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputMediaUploadedPhoto";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}