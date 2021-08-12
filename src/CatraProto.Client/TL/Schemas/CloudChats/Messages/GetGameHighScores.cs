using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetGameHighScores : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -400399203; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(HighScoresBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("user_id")] public InputUserBase UserId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();
		}

		public override string ToString()
		{
			return "messages.getGameHighScores";
		}
	}
}