using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerUnknown : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1579864942; }
        

        
        public RpcAnswerUnknown() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "rpc_answer_unknown";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}