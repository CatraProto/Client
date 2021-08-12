using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Report : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1115507112; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("id")]
		public IList<int> Id { get; set; }

		[JsonPropertyName("reason")] public ReportReasonBase Reason { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(Reason);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();
			Reason = reader.Read<ReportReasonBase>();
		}

		public override string ToString()
		{
			return "messages.report";
		}
	}
}