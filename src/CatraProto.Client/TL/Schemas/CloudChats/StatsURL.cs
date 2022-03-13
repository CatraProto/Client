using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsURL : CatraProto.Client.TL.Schemas.CloudChats.StatsURLBase
	{


        public static int StaticConstructorId { get => 1202287072; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }


        #nullable enable
 public StatsURL (string url)
{
 Url = url;
 
}
#nullable disable
        internal StatsURL() 
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
		    return "statsURL";
		}
	}
}