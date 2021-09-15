using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAck : CatraProto.Client.TL.Schemas.MTProto.MsgsAckBase
	{


        public static int StaticConstructorId { get => 1658238041; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("msg_ids")]
		public override IList<long> MsgIds { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgIds);

		}

		public override void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();

		}
				
		public override string ToString()
		{
		    return "msgs_ack";
		}
	}
}