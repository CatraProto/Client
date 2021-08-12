using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadHistory : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 238054714; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AffectedMessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("max_id")]
		public int MaxId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MaxId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MaxId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.readHistory";
		}
	}
}