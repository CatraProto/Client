using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendVote : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 283795844; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("options")]
		public IList<byte[]> Options { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(Options);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			Options = reader.ReadVector<byte[]>();
		}

		public override string ToString()
		{
			return "messages.sendVote";
		}
	}
}