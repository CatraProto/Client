using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UrlAuthResultAccepted : CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1886646706; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }


        #nullable enable
 public UrlAuthResultAccepted (string url)
{
 Url = url;
 
}
#nullable disable
        internal UrlAuthResultAccepted() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "urlAuthResultAccepted";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}