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


        public static int StaticConstructorId { get => 686618977; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("expires")]
		public override int Expires { get; set; }

[Newtonsoft.Json.JsonProperty("terms_of_service")]
		public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}