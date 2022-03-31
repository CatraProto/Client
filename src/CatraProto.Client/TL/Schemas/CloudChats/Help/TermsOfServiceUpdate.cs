using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdate : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 686618977; }
        
[Newtonsoft.Json.JsonProperty("expires")]
		public sealed override int Expires { get; set; }

[Newtonsoft.Json.JsonProperty("terms_of_service")]
		public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }


        #nullable enable
 public TermsOfServiceUpdate (int expires,CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase termsOfService)
{
 Expires = expires;
TermsOfService = termsOfService;
 
}
#nullable disable
        internal TermsOfServiceUpdate() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Expires);
			writer.Write(TermsOfService);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
			TermsOfService = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();

		}
		
		public override string ToString()
		{
		    return "help.termsOfServiceUpdate";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}