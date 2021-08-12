using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerSettings : UpdateBase
	{


        public static int StaticConstructorId { get => 1786671974; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("settings")]
		public PeerSettingsBase Settings { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Settings);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			Settings = reader.Read<PeerSettingsBase>();
		}

		public override string ToString()
		{
			return "updatePeerSettings";
		}
	}
}