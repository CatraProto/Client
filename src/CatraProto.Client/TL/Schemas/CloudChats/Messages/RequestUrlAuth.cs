using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RequestUrlAuth : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -482388461; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UrlAuthResultBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("button_id")]
		public int ButtonId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ButtonId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			ButtonId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.requestUrlAuth";
		}
	}
}