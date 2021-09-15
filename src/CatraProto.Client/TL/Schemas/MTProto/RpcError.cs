using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcError : CatraProto.Client.TL.Schemas.MTProto.RpcErrorBase
	{


        public static int StaticConstructorId { get => 558156313; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("error_code")]
		public override int ErrorCode { get; set; }

[Newtonsoft.Json.JsonProperty("error_message")]
		public override string ErrorMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ErrorCode);
			writer.Write(ErrorMessage);

		}

		public override void Deserialize(Reader reader)
		{
			ErrorCode = reader.Read<int>();
			ErrorMessage = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "rpc_error";
		}
	}
}