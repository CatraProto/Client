using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywordsLanguages : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1318675378; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("lang_codes")]
		public IList<string> LangCodes { get; set; }

        
        #nullable enable
 public GetEmojiKeywordsLanguages (IList<string> langCodes)
{
 LangCodes = langCodes;
 
}
#nullable disable
                
        internal GetEmojiKeywordsLanguages() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangCodes);

		}

		public void Deserialize(Reader reader)
		{
			LangCodes = reader.ReadVector<string>();

		}
		
		public override string ToString()
		{
		    return "messages.getEmojiKeywordsLanguages";
		}
	}
}