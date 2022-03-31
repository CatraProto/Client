using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgResendAnsReq : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2045723925; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("msg_ids")]
		public IList<long> MsgIds { get; set; }

        
        #nullable enable
 public MsgResendAnsReq (IList<long> msgIds)
{
 MsgIds = msgIds;
 
}
#nullable disable
                
        internal MsgResendAnsReq() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(MsgIds);

		}

		public void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();

		}

		public override string ToString()
		{
		    return "msg_resend_ans_req";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}