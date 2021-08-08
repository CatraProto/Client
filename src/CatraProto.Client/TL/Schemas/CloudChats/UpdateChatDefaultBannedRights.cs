using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatDefaultBannedRights : UpdateBase
	{


        public static int StaticConstructorId { get => 1421875280; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("default_banned_rights")]
		public ChatBannedRightsBase DefaultBannedRights { get; set; }

[JsonPropertyName("version")]
		public int Version { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(DefaultBannedRights);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			DefaultBannedRights = reader.Read<ChatBannedRightsBase>();
			Version = reader.Read<int>();

		}
	}
}