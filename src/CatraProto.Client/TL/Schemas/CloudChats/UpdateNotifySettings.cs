using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNotifySettings : UpdateBase
	{


        public static int StaticConstructorId { get => -1094555409; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public NotifyPeerBase Peer { get; set; }

[JsonPropertyName("notify_settings")]
		public PeerNotifySettingsBase NotifySettings { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(NotifySettings);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<NotifyPeerBase>();
			NotifySettings = reader.Read<PeerNotifySettingsBase>();
		}

		public override string ToString()
		{
			return "updateNotifySettings";
		}
	}
}