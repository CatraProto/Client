using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdateEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -483352705; }
        
[Newtonsoft.Json.JsonProperty("expires")]
		public sealed override int Expires { get; set; }


        #nullable enable
 public TermsOfServiceUpdateEmpty (int expires)
{
 Expires = expires;
 
}
#nullable disable
        internal TermsOfServiceUpdateEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "help.termsOfServiceUpdateEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}