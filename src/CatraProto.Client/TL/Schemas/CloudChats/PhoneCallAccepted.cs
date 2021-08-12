using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallAccepted : PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 6
		}

        public static int StaticConstructorId { get => -1719909046; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

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

[JsonPropertyName("g_b")]
		public byte[] GB { get; set; }

[JsonPropertyName("protocol")]
		public PhoneCallProtocolBase Protocol { get; set; }

        
		public override void UpdateFlags() 
		{
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
			writer.Write(GB);
			writer.Write(Protocol);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GB = reader.Read<byte[]>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
		}

		public override string ToString()
		{
			return "phoneCallAccepted";
		}
	}
}