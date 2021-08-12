using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotShippingQuery : UpdateBase
	{


        public static int StaticConstructorId { get => -523384512; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("payload")]
		public byte[] Payload { get; set; }

[JsonPropertyName("shipping_address")]
		public PostAddressBase ShippingAddress { get; set; }

        
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
			ShippingAddress = reader.Read<PostAddressBase>();
		}

		public override string ToString()
		{
			return "updateBotShippingQuery";
		}
	}
}