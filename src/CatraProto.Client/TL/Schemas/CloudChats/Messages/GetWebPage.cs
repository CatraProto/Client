using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPage : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 852135825; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WebPageBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public int Hash { get; set; }

        
        #nullable enable
 public GetWebPage (string url,int hash)
{
 Url = url;
Hash = hash;
 
}
#nullable disable
                
        internal GetWebPage() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Hash = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.getWebPage";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}