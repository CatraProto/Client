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


        public static int StaticConstructorId { get => -1886646706; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}