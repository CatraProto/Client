using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneConnection : PhoneConnectionBase
	{


        public static int StaticConstructorId { get => -1655957568; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("ip")]
		public override string Ip { get; set; }

[JsonPropertyName("ipv6")]
		public override string Ipv6 { get; set; }

[JsonPropertyName("port")]
		public override int Port { get; set; }

[JsonPropertyName("peer_tag")]
		public byte[] PeerTag { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Ip);
			writer.Write(Ipv6);
			writer.Write(Port);
			writer.Write(PeerTag);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Ip = reader.Read<string>();
			Ipv6 = reader.Read<string>();
			Port = reader.Read<int>();
			PeerTag = reader.Read<byte[]>();

		}
	}
}