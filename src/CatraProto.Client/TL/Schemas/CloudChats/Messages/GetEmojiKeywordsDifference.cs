using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywordsDifference : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 352892591; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("lang_code")]
		public string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("from_version")]
		public int FromVersion { get; set; }

        
        #nullable enable
 public GetEmojiKeywordsDifference (string langCode,int fromVersion)
{
 LangCode = langCode;
FromVersion = fromVersion;
 
}
#nullable disable
                
        internal GetEmojiKeywordsDifference() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(FromVersion);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.getEmojiKeywordsDifference";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}