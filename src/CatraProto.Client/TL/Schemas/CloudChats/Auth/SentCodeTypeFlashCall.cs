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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1425815847; }
        
[Newtonsoft.Json.JsonProperty("pattern")]
		public string Pattern { get; set; }


        #nullable enable
 public SentCodeTypeFlashCall (string pattern)
{
 Pattern = pattern;
 
}
#nullable disable
        internal SentCodeTypeFlashCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}