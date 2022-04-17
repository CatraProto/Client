using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgResendReq : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2105940488; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("msg_ids")]
		public List<long> MsgIds { get; set; }

        
        #nullable enable
 public MsgResendReq (List<long> msgIds)
{
 MsgIds = msgIds;
 
}
#nullable disable
                
        internal MsgResendReq() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteVector(MsgIds, false);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trymsgIds = reader.ReadVector<long>(ParserTypes.Int64);
if(trymsgIds.IsError){
return ReadResult<IObject>.Move(trymsgIds);
}
MsgIds = trymsgIds.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "msg_resend_req";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}