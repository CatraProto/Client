using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeFlashCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
	{


        public static int StaticConstructorId { get => -1425815847; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pattern")]
		public string Pattern { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pattern);

		}

		public override void Deserialize(Reader reader)
		{
			Pattern = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "auth.sentCodeTypeFlashCall";
		}
	}
}