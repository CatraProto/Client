using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateGeoLiveViewed : UpdateBase
	{


        public static int StaticConstructorId { get => -2027964103; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			MsgId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateGeoLiveViewed";
		}
	}
}