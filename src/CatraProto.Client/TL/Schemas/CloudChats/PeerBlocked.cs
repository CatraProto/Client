using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerBlocked : PeerBlockedBase
	{


        public static int StaticConstructorId { get => -386039788; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer_id")]
		public override PeerBase PeerId { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PeerId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			PeerId = reader.Read<PeerBase>();
			Date = reader.Read<int>();

		}
	}
}