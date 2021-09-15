using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalts : CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase
	{


        public static int StaticConstructorId { get => -1370486635; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("req_msg_id")]
		public override long ReqMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("now")]
		public override int Now { get; set; }

[Newtonsoft.Json.JsonProperty("salts")]
		public override IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Now);
			writer.Write(Salts);

		}

		public override void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Now = reader.Read<int>();
			Salts = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.TL.Schemas.MTProto.FutureSalt>(), true);

		}
				
		public override string ToString()
		{
		    return "future_salts";
		}
	}
}