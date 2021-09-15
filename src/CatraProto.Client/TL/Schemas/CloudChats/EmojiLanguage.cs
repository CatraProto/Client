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


        public static int StaticConstructorId { get => -1275374751; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public override string LangCode { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}