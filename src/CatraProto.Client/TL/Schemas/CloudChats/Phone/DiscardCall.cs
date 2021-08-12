using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class DiscardCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1295269440; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("video")]
		public bool Video { get; set; }

[JsonPropertyName("peer")]
		public InputPhoneCallBase Peer { get; set; }

[JsonPropertyName("duration")]
		public int Duration { get; set; }

[JsonPropertyName("reason")]
		public PhoneCallDiscardReasonBase Reason { get; set; }

[JsonPropertyName("connection_id")]
		public long ConnectionId { get; set; }


		public void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Duration);
			writer.Write(Reason);
			writer.Write(ConnectionId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputPhoneCallBase>();
			Duration = reader.Read<int>();
			Reason = reader.Read<PhoneCallDiscardReasonBase>();
			ConnectionId = reader.Read<long>();
		}

		public override string ToString()
		{
			return "phone.discardCall";
		}
	}
}