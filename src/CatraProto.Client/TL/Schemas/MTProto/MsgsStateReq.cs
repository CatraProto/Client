using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateReq : MsgsStateReqBase
	{


        public static int StaticConstructorId { get => -630588590; }
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

		public override string ToString()
		{
			return "msgs_state_req";
		}
	}
}