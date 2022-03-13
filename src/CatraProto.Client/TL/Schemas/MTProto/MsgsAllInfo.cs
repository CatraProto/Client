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
		public sealed override IList<long> MsgIds { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public sealed override byte[] Info { get; set; }


        #nullable enable
 public MsgsAllInfo (IList<long> msgIds,byte[] info)
{
 MsgIds = msgIds;
Info = info;
 
}
#nullable disable
        internal MsgsAllInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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