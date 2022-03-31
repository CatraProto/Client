using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPageEmpty : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -350980120; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }


        #nullable enable
 public WebPageEmpty (long id)
{
 Id = id;
 
}
#nullable disable
        internal WebPageEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "webPageEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}