using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCall : PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			P2pAllowed = 1 << 5,
			Video = 1 << 6
		}

        public static int StaticConstructorId { get => -2025673089; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("p2p_allowed")]
		public bool P2pAllowed { get; set; }

[JsonPropertyName("video")]
		public bool Video { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("access_hash")]
		public long AccessHash { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("admin_id")]
		public int AdminId { get; set; }

[JsonPropertyName("participant_id")]
		public int ParticipantId { get; set; }

[JsonPropertyName("g_a_or_b")]
		public byte[] GAOrB { get; set; }

[JsonPropertyName("key_fingerprint")]
		public long KeyFingerprint { get; set; }

[JsonPropertyName("protocol")]
		public PhoneCallProtocolBase Protocol { get; set; }

[JsonPropertyName("connections")]
		public IList<PhoneConnectionBase> Connections { get; set; }

[JsonPropertyName("start_date")]
		public int StartDate { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = P2pAllowed ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GAOrB);
			writer.Write(KeyFingerprint);
			writer.Write(Protocol);
			writer.Write(Connections);
			writer.Write(StartDate);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			P2pAllowed = FlagsHelper.IsFlagSet(Flags, 5);
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GAOrB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
			Connections = reader.ReadVector<PhoneConnectionBase>();
			StartDate = reader.Read<int>();

		}
	}
}