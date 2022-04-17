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
	public partial class Page : CatraProto.Client.TL.Schemas.CloudChats.PageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Part = 1 << 0,
			Rtl = 1 << 1,
			V2 = 1 << 2,
			Views = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1738178803; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("part")]
		public sealed override bool Part { get; set; }

[Newtonsoft.Json.JsonProperty("rtl")]
		public sealed override bool Rtl { get; set; }

[Newtonsoft.Json.JsonProperty("v2")]
		public sealed override bool V2 { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

[Newtonsoft.Json.JsonProperty("photos")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public sealed override int? Views { get; set; }


        #nullable enable
 public Page (string url,List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks,List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos,List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
{
 Url = url;
Blocks = blocks;
Photos = photos;
Documents = documents;
 
}
#nullable disable
        internal Page() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Part ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Rtl ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = V2 ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteString(Url);
var checkblocks = 			writer.WriteVector(Blocks, false);
if(checkblocks.IsError){
 return checkblocks; 
}
var checkphotos = 			writer.WriteVector(Photos, false);
if(checkphotos.IsError){
 return checkphotos; 
}
var checkdocuments = 			writer.WriteVector(Documents, false);
if(checkdocuments.IsError){
 return checkdocuments; 
}
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
writer.WriteInt32(Views.Value);
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
			Part = FlagsHelper.IsFlagSet(Flags, 0);
			Rtl = FlagsHelper.IsFlagSet(Flags, 1);
			V2 = FlagsHelper.IsFlagSet(Flags, 2);
			var tryurl = reader.ReadString();
if(tryurl.IsError){
return ReadResult<IObject>.Move(tryurl);
}
Url = tryurl.Value;
			var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryblocks.IsError){
return ReadResult<IObject>.Move(tryblocks);
}
Blocks = tryblocks.Value;
			var tryphotos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryphotos.IsError){
return ReadResult<IObject>.Move(tryphotos);
}
Photos = tryphotos.Value;
			var trydocuments = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trydocuments.IsError){
return ReadResult<IObject>.Move(trydocuments);
}
Documents = trydocuments.Value;
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryviews = reader.ReadInt32();
if(tryviews.IsError){
return ReadResult<IObject>.Move(tryviews);
}
Views = tryviews.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "page";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}