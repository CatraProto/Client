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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1770029977; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("p2p_allowed")]
		public bool P2pAllowed { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public long AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public long ParticipantId { get; set; }

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


        #nullable enable
 public PhoneCall (long id,long accessHash,int date,long adminId,long participantId,byte[] gAOrB,long keyFingerprint,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol,IList<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase> connections,int startDate)
{
 Id = id;
AccessHash = accessHash;
Date = date;
AdminId = adminId;
ParticipantId = participantId;
GAOrB = gAOrB;
KeyFingerprint = keyFingerprint;
Protocol = protocol;
Connections = connections;
StartDate = startDate;
 
}
#nullable disable
        internal PhoneCall() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = P2pAllowed ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			AdminId = reader.Read<long>();
			ParticipantId = reader.Read<long>();
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}