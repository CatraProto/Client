using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateInfo : CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase
	{


        public static int StaticConstructorId { get => 81704317; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("req_msg_id")]
		public override long ReqMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public override byte[] Info { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Info);

		}

		public override void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Info = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "msgs_state_info";
		}
	}
}