using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcResult : CatraProto.Client.TL.Schemas.MTProto.RpcResultBase
	{


        public static int StaticConstructorId { get => -212046591; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("req_msg_id")]
		public sealed override long ReqMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("result")]
		public sealed override IObject Result { get; set; }


        #nullable enable
 public RpcResult (long reqMsgId,IObject result)
{
 ReqMsgId = reqMsgId;
Result = result;
 
}
#nullable disable
        internal RpcResult() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Result);

		}

		public override void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Result = reader.Read<IObject>();

		}
				
		public override string ToString()
		{
		    return "rpc_result";
		}
	}
}