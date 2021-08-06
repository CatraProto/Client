using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgResendReq : CatraProto.Client.TL.Schemas.MTProto.MsgResendReqBase
	{


        public static int StaticConstructorId { get => 2105940488; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_ids")]
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
	}
}