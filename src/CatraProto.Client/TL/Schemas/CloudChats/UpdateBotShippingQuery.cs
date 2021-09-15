using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotShippingQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -523384512; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("payload")]
		public byte[] Payload { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_address")]
		public CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Payload);
			writer.Write(ShippingAddress);

		}

		public override void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			UserId = reader.Read<int>();
			Payload = reader.Read<byte[]>();
			ShippingAddress = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase>();

		}
				
		public override string ToString()
		{
		    return "updateBotShippingQuery";
		}
	}
}