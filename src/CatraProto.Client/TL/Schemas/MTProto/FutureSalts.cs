using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.ObjectDeserializers;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalts : FutureSaltsBase
	{


        public static int StaticConstructorId { get => -1370486635; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("req_msg_id")]
		public override long ReqMsgId { get; set; }

[JsonPropertyName("now")]
		public override int Now { get; set; }

[JsonPropertyName("salts")]
		public override IList<FutureSalt> Salts { get; set; }

        
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
			Salts = reader.ReadVector(new NakedObjectVectorDeserializer<FutureSalt>(), true);

		}
	}
}