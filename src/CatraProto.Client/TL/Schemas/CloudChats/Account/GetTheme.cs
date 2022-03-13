using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTheme : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1919060949; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ThemeBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("format")]
		public string Format { get; set; }

[Newtonsoft.Json.JsonProperty("theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

[Newtonsoft.Json.JsonProperty("document_id")]
		public long DocumentId { get; set; }

        
        #nullable enable
 public GetTheme (string format,CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme,long documentId)
{
 Format = format;
Theme = theme;
DocumentId = documentId;
 
}
#nullable disable
                
        internal GetTheme() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Format);
			writer.Write(Theme);
			writer.Write(DocumentId);

		}

		public void Deserialize(Reader reader)
		{
			Format = reader.Read<string>();
			Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			DocumentId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "account.getTheme";
		}
	}
}