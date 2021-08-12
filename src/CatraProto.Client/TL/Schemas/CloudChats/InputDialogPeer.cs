using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeer : InputDialogPeerBase
	{


        public static int StaticConstructorId { get => -55902537; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public InputPeerBase Peer { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
		}

		public override string ToString()
		{
			return "inputDialogPeer";
		}
	}
}