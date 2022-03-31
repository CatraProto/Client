using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerDroppedRunning : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -847714938; }
        

        
        public RpcAnswerDroppedRunning() 
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
		    return "rpc_answer_dropped_running";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}