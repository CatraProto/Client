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
		public sealed override int ErrorCode { get; set; }

[Newtonsoft.Json.JsonProperty("error_message")]
		public sealed override string ErrorMessage { get; set; }


        #nullable enable
 public RpcError (int errorCode,string errorMessage)
{
 ErrorCode = errorCode;
ErrorMessage = errorMessage;
 
}
#nullable disable
        internal RpcError() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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