using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsAllInfo : CatraProto.Client.TL.Schemas.MTProto.MsgsAllInfoBase
	{


        public static int StaticConstructorId { get => -1933520591; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("msg_ids")]
		public override IList<long> MsgIds { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public override byte[] Info { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgIds);
			writer.Write(Info);

		}

		public override void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();
			Info = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "msgs_all_info";
		}
	}
}