using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerLocated : UpdateBase
	{


        public static int StaticConstructorId { get => -1263546448; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peers")]
		public IList<PeerLocatedBase> Peers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peers);

		}

		public override void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<PeerLocatedBase>();

		}
	}
}