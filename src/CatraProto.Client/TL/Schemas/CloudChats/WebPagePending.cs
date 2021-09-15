using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPagePending : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
	{


        public static int StaticConstructorId { get => -981018084; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "webPagePending";
		}
	}
}