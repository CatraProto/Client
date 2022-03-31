using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }


        #nullable enable
 public EmojiKeywordsDifference (string langCode,int fromVersion,int version,IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> keywords)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(FromVersion);
			writer.Write(Version);
			writer.Write(Keywords);

		}

		public override void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();
			Version = reader.Read<int>();
			Keywords = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase>();

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