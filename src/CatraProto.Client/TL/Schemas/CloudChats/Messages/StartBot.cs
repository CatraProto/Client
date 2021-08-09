using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StartBot : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -421563528; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("bot")] public InputUserBase Bot { get; set; }

[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("random_id")]
		public long RandomId { get; set; }

[JsonPropertyName("start_param")]
		public string StartParam { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Bot);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(StartParam);

		}

		public void Deserialize(Reader reader)
		{
			Bot = reader.Read<InputUserBase>();
			Peer = reader.Read<InputPeerBase>();
			RandomId = reader.Read<long>();
			StartParam = reader.Read<string>();

		}
	}
}