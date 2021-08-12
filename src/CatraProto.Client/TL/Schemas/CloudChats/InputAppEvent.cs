using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputAppEvent : InputAppEventBase
	{


        public static int StaticConstructorId { get => 488313413; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("time")]
		public override double Time { get; set; }

[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("peer")]
		public override long Peer { get; set; }

[JsonPropertyName("data")]
		public override JSONValueBase Data { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Time);
			writer.Write(Type);
			writer.Write(Peer);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Time = reader.Read<double>();
			Type = reader.Read<string>();
			Peer = reader.Read<long>();
			Data = reader.Read<JSONValueBase>();
		}

		public override string ToString()
		{
			return "inputAppEvent";
		}
	}
}