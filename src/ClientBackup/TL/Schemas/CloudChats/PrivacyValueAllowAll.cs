using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyValueAllowAll : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1698855810; }
        

        
        public PrivacyValueAllowAll() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "privacyValueAllowAll";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}