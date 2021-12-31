using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportLoginToken : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1210022402; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("api_id")]
		public int ApiId { get; set; }

[Newtonsoft.Json.JsonProperty("api_hash")]
		public string ApiHash { get; set; }

[Newtonsoft.Json.JsonProperty("except_ids")]
		public IList<long> ExceptIds { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(ExceptIds);

		}

		public void Deserialize(Reader reader)
		{
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			ExceptIds = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "auth.exportLoginToken";
		}
	}
}