using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Expires);
var checktermsOfService = 			writer.WriteObject(TermsOfService);
if(checktermsOfService.IsError){
 return checktermsOfService; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryexpires = reader.ReadInt32();
if(tryexpires.IsError){
return ReadResult<IObject>.Move(tryexpires);
}
Expires = tryexpires.Value;
			var trytermsOfService = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();
if(trytermsOfService.IsError){
return ReadResult<IObject>.Move(trytermsOfService);
}
TermsOfService = trytermsOfService.Value;
return new ReadResult<IObject>(this);

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