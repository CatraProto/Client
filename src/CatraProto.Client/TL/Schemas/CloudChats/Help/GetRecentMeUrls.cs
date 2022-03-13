using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetRecentMeUrls : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1036054804; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("referer")]
		public string Referer { get; set; }

        
        #nullable enable
 public GetRecentMeUrls (string referer)
{
 Referer = referer;
 
}
#nullable disable
                
        internal GetRecentMeUrls() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Referer);

		}

		public void Deserialize(Reader reader)
		{
			Referer = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "help.getRecentMeUrls";
		}
	}
}