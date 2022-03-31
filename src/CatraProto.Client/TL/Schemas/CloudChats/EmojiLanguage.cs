using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiLanguage : CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1275374751; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public sealed override string LangCode { get; set; }


        #nullable enable
 public EmojiLanguage (string langCode)
{
 LangCode = langCode;
 
}
#nullable disable
        internal EmojiLanguage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangCode);

		}

		public override void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "emojiLanguage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}