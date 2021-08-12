using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChannelFromMessage : InputChannelBase
	{


        public static int StaticConstructorId { get => 707290417; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public InputPeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ChannelId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			ChannelId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "inputChannelFromMessage";
		}
	}
}