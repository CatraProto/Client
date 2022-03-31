using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLanguages : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1120311183; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("lang_pack")]
		public string LangPack { get; set; }

        
        #nullable enable
 public GetLanguages (string langPack)
{
 LangPack = langPack;
 
}
#nullable disable
                
        internal GetLanguages() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(LangPack);

		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "langpack.getLanguages";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}