using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCall : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			P2pAllowed = 1 << 5,
			Video = 1 << 6
		}

        public static int StaticConstructorId { get => -2025673089; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("p2p_allowed")]
		public bool P2pAllowed { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public int AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public int ParticipantId { get; set; }

[Newtonsoft.Json.JsonProperty("g_a_or_b")]
		public byte[] GAOrB { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public long KeyFingerprint { get; set; }

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }

[Newtonsoft.Json.JsonProperty("connections")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase> Connections { get; set; }

[Newtonsoft.Json.JsonProperty("start_date")]
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
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
			Connections = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase>();
			StartDate = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "phoneCall";
		}
	}
}