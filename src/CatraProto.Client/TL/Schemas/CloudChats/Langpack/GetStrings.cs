using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetStrings : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -269862909; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("lang_pack")]
		public string LangPack { get; set; }

[Newtonsoft.Json.JsonProperty("lang_code")]
		public string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("keys")]
		public IList<string> Keys { get; set; }

        
        #nullable enable
 public GetStrings (string langPack,string langCode,IList<string> keys)
{
 LangPack = langPack;
LangCode = langCode;
Keys = keys;
 
}
#nullable disable
                
        internal GetStrings() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangPack);
			writer.Write(LangCode);
			writer.Write(Keys);

		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
			Keys = reader.ReadVector<string>();

		}
		
		public override string ToString()
		{
		    return "langpack.getStrings";
		}
	}
}