using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaWebPage : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1557277184; }
        
[Newtonsoft.Json.JsonProperty("webpage")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }


        #nullable enable
 public MessageMediaWebPage (CatraProto.Client.TL.Schemas.CloudChats.WebPageBase webpage)
{
 Webpage = webpage;
 
}
#nullable disable
        internal MessageMediaWebPage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Webpage);

		}

		public override void Deserialize(Reader reader)
		{
			Webpage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>();

		}
		
		public override string ToString()
		{
		    return "messageMediaWebPage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}