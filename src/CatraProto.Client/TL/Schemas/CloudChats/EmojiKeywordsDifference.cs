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
	public partial class EmojiKeywordsDifference : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1556570557; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public sealed override string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("from_version")]
		public sealed override int FromVersion { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public sealed override int Version { get; set; }

[Newtonsoft.Json.JsonProperty("keywords")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }


        #nullable enable
 public EmojiKeywordsDifference (string langCode,int fromVersion,int version,List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> keywords)
{
 LangCode = langCode;
FromVersion = fromVersion;
Version = version;
Keywords = keywords;
 
}
#nullable disable
        internal EmojiKeywordsDifference() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteString(LangCode);
writer.WriteInt32(FromVersion);
writer.WriteInt32(Version);
var checkkeywords = 			writer.WriteVector(Keywords, false);
if(checkkeywords.IsError){
 return checkkeywords; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trylangCode = reader.ReadString();
if(trylangCode.IsError){
return ReadResult<IObject>.Move(trylangCode);
}
LangCode = trylangCode.Value;
			var tryfromVersion = reader.ReadInt32();
if(tryfromVersion.IsError){
return ReadResult<IObject>.Move(tryfromVersion);
}
FromVersion = tryfromVersion.Value;
			var tryversion = reader.ReadInt32();
if(tryversion.IsError){
return ReadResult<IObject>.Move(tryversion);
}
Version = tryversion.Value;
			var trykeywords = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trykeywords.IsError){
return ReadResult<IObject>.Move(trykeywords);
}
Keywords = trykeywords.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "emojiKeywordsDifference";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}