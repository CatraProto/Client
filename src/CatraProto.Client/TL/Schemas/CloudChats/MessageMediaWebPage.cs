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


        public static int StaticConstructorId { get => -1557277184; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("webpage")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}