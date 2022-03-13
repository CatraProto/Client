using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportAuthorization : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -440401971; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

        
        #nullable enable
 public ExportAuthorization (int dcId)
{
 DcId = dcId;
 
}
#nullable disable
                
        internal ExportAuthorization() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(DcId);

		}

		public void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "auth.exportAuthorization";
		}
	}
}