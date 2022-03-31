using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateLangPackTooLong : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1180041828; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public string LangCode { get; set; }


        #nullable enable
 public UpdateLangPackTooLong (string langCode)
{
 LangCode = langCode;
 
}
#nullable disable
        internal UpdateLangPackTooLong() 
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
		    return "updateLangPackTooLong";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}